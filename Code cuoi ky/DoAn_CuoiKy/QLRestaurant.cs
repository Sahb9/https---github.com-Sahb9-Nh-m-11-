using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public abstract class QL
    {
    }
    public enum Name
    {
        City,
        Local,
        Normal
    }
    public class QLRestaurant : QL
    {
        public Name tenCuaHang { set; get; }
        public List<HoaDon> Bill { set; get; }
        public List<maQR> Ma { set; get; }
        public string ID { set; get; }
        public Type typeData { set; get; }
        public string Ten { set; get; }
        public double tongNuocBanRa { set; get; }
        public double tongNuocNhapVe { set; get; }
        public double loiNhuan { set; get; }
        public QLRestaurant()
        {
            Bill = new List<HoaDon>();
            Ma = new List<maQR>();
        }
        ~QLRestaurant() { }
        public QLRestaurant(List<HoaDon> Bill, List<maQR> Ma, string ma, Type data, string ten, double sl, double sl1, double loi)
        {
            this.Bill = new List<HoaDon>();
            foreach (HoaDon a in Bill)
                this.Bill.Add(new HoaDon(a));
            this.Ma = new List<maQR>();
            foreach (maQR a in Ma)
                this.Ma.Add(new maQR(a));
            this.ID = ma;
            this.typeData = data;
            this.Ten = ten;
            this.tongNuocBanRa = sl;
            this.tongNuocNhapVe = sl1;
            this.loiNhuan = loi;
        }
        public QLRestaurant(QLRestaurant QL)
        {
            this.Bill = QL.Bill;
            for (int i = 0; i < Bill.Count; i++)
                this.Bill.Add(new HoaDon(QL.Bill[i]));
            this.Ma = QL.Ma;
            for (int i = 0; i < Ma.Count; i++)
                this.Ma.Add(new maQR(QL.Ma[i]));
            this.ID = QL.ID;
            this.typeData = QL.typeData;
            this.Ten = QL.Ten;
            this.tongNuocBanRa = QL.tongNuocBanRa;
            this.tongNuocNhapVe = QL.tongNuocNhapVe;
            this.loiNhuan = QL.loiNhuan;
        }
        public string chooseTen()
        {
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey();          // chon lai ten table
                if (k.Key == ConsoleKey.D1)
                    this.tenCuaHang = Name.City;
                else if (k.Key == ConsoleKey.D2)
                    this.tenCuaHang = Name.Local;
                else if (k.Key == ConsoleKey.D3)
                    this.tenCuaHang = Name.Normal;
            } while (k.Key != ConsoleKey.Escape && k.Key != ConsoleKey.D1 && k.Key != ConsoleKey.D3 && k.Key != ConsoleKey.D2);   //Chọn phim ESC để thoát
            return "\nTen nha hang la: Nha Hang." + this.tenCuaHang.ToString();
        }
        static void danhSachTop(Khach tt, List<Menu> Menu, string a, int maxa, int dem)
        {
            for (int i = 0; i < tt.myDrink.Count; i++)
            {
                if (tt.myDrink[i].nameNuoc != a)
                    for (int j = 0; j < tt.myDrink.Count; j++)
                    {
                        if (tt.myDrink[i].nameNuoc == tt.myDrink[j].nameNuoc)
                        {
                            dem++;
                            if (maxa < dem)
                            {
                                a = tt.myDrink[i].nameNuoc;
                                maxa = dem;
                            }
                        }
                    }
                dem = 0;
            }
            for (int j = 0; j < Menu[0].listNuoc.Count; j++)
            {
                if (a == Menu[0].listNuoc[j].nameNuoc)
                    maxa += Menu[0].listNuoc[j].soLuongBan;
            }
        }
        public string demSoLuong(Khach tt, List<Menu> Menu)
        {
            string a = "";
            string flo = "";
            int maxa = 0, dem = 0;
            danhSachTop(tt, Menu, a, maxa, dem);

            flo += ("BANG XEP HANG NUOC UONG YEU THICH\nTOP 1: " + a + "-- so luong: \n");
            danhSachTop(tt, Menu, a, maxa, dem);
            flo += ("TOP 2: " + a + "-- so luong: \n");
            danhSachTop(tt, Menu, a, maxa, dem);
            flo += ("TOP 3: " + a + "-- so luong: \n");
            return flo;
            /*double demsoluongban = 0;
            double demsoluongnhap = 0;
            for (int i = 0; i < DSNU.Count; i++)
            {
                demsoluongban += DSNU[i].soLuongBan;
            }
            for (int i = 0; i < DSNU.Count; i++)
            {
                demsoluongnhap += DSNU[i].soLuongTrongKho;
            }
            this.tongNuocBanRa = demsoluongban;
            this.tongNuocNhapVe = demsoluongnhap;
            */
        }
        /*
        public string updateKho(params object[] thamso)
        {
            int k = (int)thamso[0];
            int l = (int)thamso[1];
            // this.soLuong = this.soLuong - k;
            this.loiNhuan += l;
            return string.Format("Update kho thanh cong !!!\nSo luong (New):{0}\n Loi nhuan: ", this.loiNhuan);
        }
        public void update(params object [] thamso)
        {
            delegateRun?.Invoke((int)thamso[0]);
        }
        public delegate void delegateQL(params object[] thamso);
        public event delegateQL delegateRun;
        //
        public string showBangXepHang(params object[] thamso)
        {
            return string.Format("Loai nuoc uong yeu thich (<3)\n" +
                "Top 1: {0} - {3}\nTop 2: {1} -{4}\nTop 3: {2} - {5}", //cap nhat them so luong san pham dung top 1,2,3
                (string)thamso[0], (string)thamso[1], (string)thamso[2]);
        }
        public string capnhatNguyenLieu(params object[] thamso) //2 cach cap nhat -Cach 1: cap nhat tu dong (xem xet cac so luong trong kho (vd <3) nhap tay x them hang loat vao /Cach 2: cap nhat tung cai bang tay)
        {
           // for (int i = 0; i < DSNU.Count; i++)
             //   if (DSNU[i].soLuongTrongKho <= 3) DSNU[i].soLuongTrongKho = int.Parse(Console.ReadLine());
            return "cap nhat thanh cong";
        }
        */
    }
}
