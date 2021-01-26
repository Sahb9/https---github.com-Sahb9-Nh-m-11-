using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public enum kieuNuoc
    {
        Dang_Ban,
        Qua_Tang
    }
    public enum typeShape
    {
        kieuLon,
        kieuChai,
        KieuThuyTinh
    }
    public class Nuoc
    {
       
        public kieuNuoc kieuNuocNay;
        public int maNuocTrongKho { get; set; }
        public string idNuoc { get; set; }
        public string nameNuoc { get; set; }
        public double price { get; set; }
        public int soLuongBan { get; set; }
        public int soLuongTrongKho { get; set; }
        public typeShape Type { get; set; }
        public List<string> toppings = new List<string>();
        public Nuoc() { this.soLuongTrongKho = 12; }
        public Nuoc(int maNuocTrongKho, kieuNuoc kieuNuoc, string idNuoc, string nameNuoc, double price, int soLuongBan, int soLuongTrongKho,typeShape type)
        {
            this.kieuNuocNay = kieuNuoc;
            this.maNuocTrongKho = maNuocTrongKho;
            this.idNuoc = idNuoc;
            this.price = price;
            this.soLuongBan = soLuongBan;
            this.soLuongTrongKho = soLuongTrongKho;
            this.Type = Type;
        }
        public Nuoc(Nuoc Nuoc)
        {
            this.kieuNuocNay = Nuoc.kieuNuocNay;
            this.maNuocTrongKho = Nuoc.maNuocTrongKho;
            this.idNuoc = Nuoc.idNuoc;
            this.nameNuoc = Nuoc.nameNuoc;
            this.price = Nuoc.price;
            this.soLuongBan = Nuoc.soLuongBan;
            this.soLuongTrongKho = Nuoc.soLuongTrongKho;
            this.Type = Nuoc.Type;
        }
        public static Nuoc operator +(Nuoc nuoc1, Nuoc nuoc2)
        {
            Nuoc nuocKetQua = nuoc1;
            nuocKetQua.maNuocTrongKho = 0;
            nuocKetQua.idNuoc = nuoc1.idNuoc + "-" + nuoc2.idNuoc;
            nuocKetQua.nameNuoc += nuoc1.nameNuoc + "-" + nuoc2.nameNuoc;
            nuocKetQua.price = (nuoc1.price + nuoc2.price) / 2;
            nuocKetQua.soLuongBan = 0;
            return nuocKetQua;
        }
        public string InThongtin()
        {
            return "Name nuoc: " + this.nameNuoc + "\n";
        }
        public string Xuat(List<Menu> Menu,int i,int x,string y)
        {
            y = "";x = 1;
            for (int j = 0; j < Menu[i].listNuoc.Count; j++)
            {
               y+=(x++ + "--" + "|" + Menu[i].listNuoc[j].nameNuoc + "\n");
            }
            return y;
        }       
        public object showNuoc()
        {
            return "\nID Nuoc: " + (object)this.idNuoc + "\n" +
                "Kieu nuoc: " + (object)this.kieuNuocNay + "\n" +
                "Name nuoc: " + (object)this.nameNuoc + "\n" +
                "Gia nuoc: " + (object)this.price + "\n" +
                "Soluong ban: " + (object)(this.soLuongBan) + "\n";
        }
        public string b1()
        {
            return "B1: bartender chuan bi nguyen lieu \n";
        }
        public string b2()
        {
            return "B2: khoi dong\n";
        }
        public virtual string b3(delegatekynang kynang, params Dictionary<string, object>[] thamso)
        {
            return kynang(thamso);
        }
        public delegate string delegatekynang(params Dictionary<string, object>[] thamso);
        public string b4()
        {
            return "B4: Dua nuoc cho khach hang\n";
        }
        public string b5()
        {
            return "B5: Ket thuc ! Hoan tat trinh dien ...\n";
        }
        public string show(delegatekynang kynang, params Dictionary<string, object>[] thamso)
        {
            string flo = b1() + b2() + b3(kynang, thamso) + b4() + b5();
            onfinished?.Invoke(flo);
            return flo;
        }
        public delegate void onfinish(object result);
        public event onfinish onfinished;
    }
}
