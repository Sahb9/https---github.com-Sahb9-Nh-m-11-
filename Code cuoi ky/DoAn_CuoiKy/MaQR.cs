using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public abstract class QR
    {
    }
    public enum Level
    {
        Basic,
        Silver,
        Gold,
        Platinum,
        Diamond
    }
    public class maQR
    {
        public int maKhachHang { set; get; }
        public string tenKhachHang { set; get; }
        public int diemTichLuy { set; get; }
        // public double Discout { set; get; }
        public Level levelQR { set; get; }
        public maQR()
        {
            this.tenKhachHang = "null";
            this.maKhachHang = 0;
            this.levelQR = Level.Basic;
            this.diemTichLuy = 0;
        }
        public maQR(int ma, string ten, int diem, Level Cap)
        {
            this.maKhachHang = ma;
            this.tenKhachHang = ten;
            this.diemTichLuy = diem;
            this.levelQR = Cap;
        }
        public maQR(maQR maso)
        {
            this.maKhachHang = maso.maKhachHang;
            this.tenKhachHang = maso.tenKhachHang;
            this.diemTichLuy = maso.diemTichLuy;
            this.levelQR = maso.levelQR;
        }
        public void nhap(params object [] thamso)
        {
            tenKhachHang = (string)thamso[0];
            this.tenKhachHang = tenKhachHang;
            maKhachHang = (int)thamso[1];
            this.maKhachHang = maKhachHang;
            diemTichLuy = (int)thamso[2];
            this.diemTichLuy = diemTichLuy;
            int y = (int)thamso[3];
            this.levelQR = (Level)y;           
        }
        public string xuat()
        {
            return ("\n\nTen khach hang: " + this.tenKhachHang + "\nMa khach hang: " +this.maKhachHang +
               "\nDiem tich luy: " + this.diemTichLuy + "\nCap Ma QR: " + this.levelQR.ToString());
        }
        public string deleteQR(QLRestaurant nhaHang, params object[] thamso) //co 2 cach: xoa bang tim maQR (co the nhap maQR khong ton tai)| xoa bang vi tri (tao menu vi tri maQR)
        {
            int x = (int)thamso[0];
            nhaHang.Ma.RemoveAt(x);
            if (x >= 0)
                return "Xoa thong tin ma QR thanh cong";
            else
                return "Khong ton tai";
        }
        public static maQR operator +(maQR Ma1, maQR Ma2)
        {
            QLRestaurant nhaHang=new QLRestaurant();
            maQR Ma3 = new maQR() ;
            Ma3.tenKhachHang = Ma1.tenKhachHang + " - " + Ma2.tenKhachHang;
            Ma3.maKhachHang = Ma1.maKhachHang +  Ma2.maKhachHang;
            Ma3.diemTichLuy = (Ma1.diemTichLuy + Ma2.diemTichLuy)/2;
            if ((int)Ma1.levelQR >= (int)Ma2.levelQR)
                Ma3.levelQR = Ma1.levelQR + 1;
            else
                Ma3.levelQR = Ma2.levelQR + 1;
            if ((int)Ma3.levelQR == 5) Ma3.levelQR = Ma3.levelQR - 1;
            nhaHang.Ma.Add(Ma3);
            return Ma3;
        }
        public string updateInFo(ConsoleKeyInfo Key) //update thong tin khach
        {
            string y = "";
            int j = 0;
                if (Key.Key == ConsoleKey.D0)
                {
                    y = Console.ReadLine();
                    this.tenKhachHang = y;
                }
                else if (Key.Key == ConsoleKey.D1)
                {
                     j = int.Parse(Console.ReadLine());
                    this.maKhachHang = j;
                }
                else if (Key.Key == ConsoleKey.D2)
                {
                     j = int.Parse(Console.ReadLine());
                    this.diemTichLuy = j;
                }
                else if (Key.Key == ConsoleKey.D3)
                {
                     j = int.Parse(Console.ReadLine());
                    this.levelQR = (Level)j-1;
                }
            return "Changed successful";
        }        
        public string checkLevel(params object[] thamso)         //kiem tra diem tich luy de nang Cap level maQR
        {
            int Diem = (int)thamso[0];
            Level Cap = (Level)thamso[1];
            if (Cap == Level.Basic)
            {
                if (Diem >= 15)
                    Cap++;
                Diem %= 15;
            }
            else if (Cap == Level.Silver)
            {
                if (Diem >= 25)
                    Cap++;
                Diem %= 25;
            }
            else if (Cap == Level.Silver)
            {
                if (Diem >= 50)
                    Cap++;
                Diem %= 50;
            }
            else if (Cap == Level.Silver)
            {
                if (Diem >= 75)
                    Cap++;
                Diem %= 75;
            }
            else if (Cap == Level.Silver)
            {
                if (Diem >= 80)
                    Cap++;
                Diem %= 80;
            }
            return String.Format("Diem tich luy hien tai: {0} - Level QR : {1}", Diem, Cap);
        }
    }
}
/*
    level basic     15 diem thang Cap 
    level silve     25 diem thang Cap 
    level gold      50 diem thang Cap 
    level platanium 75 diem thang Cap 
    level diamond   80 diem thang Cap 
    

Cap nhat chuc nang them --- Continue++

public string show()
        {
            string flo = "Tuong tac voi danh sach Ma QR hoan thanh\n";
            onfinished?.Invoke(flo);
            return flo;
        }
        public virtual string ChucNangQR(delegatekynang kynang, params object[] thamso) //co 2 phuong thuc update: update thong tin khach | update thong tin diem tich luy, level maQR
        {
            return kynang(thamso);
        }
        public delegate string delegatekynang(params object[] thamso);
        public delegate void onfinish(object result);
        public event onfinish onfinished;
 */

