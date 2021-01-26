using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
  public delegate string delegate_params(params object[] thamso);
    public abstract class  Menu
    {
        public List<Nuoc> listNuoc = new List<Nuoc>();
        public List<Khach> listKhach = new List<Khach>();
        public Dictionary<string, DateTime> dicNgayBatDau = new Dictionary<string, DateTime>();
        public Dictionary<string, DateTime> dicNgayKetThuc = new Dictionary<string, DateTime>();
        public Dictionary<string, double> soTienGiam = new Dictionary<string, double>();
        public string maGiamGia { get; set; }
        public Menu() { }
        public Menu(List<Nuoc> listNuoc, List<Khach> listKhach, string maGiamGia)
        {
            foreach (Nuoc nuoc in listNuoc) { this.listNuoc.Add(new Nuoc(nuoc)); }
            foreach (Khach khach in listKhach) { this.listKhach.Add(new Khach(khach)); }
            this.maGiamGia = maGiamGia;
        }
        public Menu(Menu Menu)
        {
            foreach (Nuoc nuoc in Menu.listNuoc) { this.listNuoc.Add(new Nuoc(nuoc)); }
            foreach (Khach khach in Menu.listKhach) { this.listKhach.Add(new Khach(khach)); }
            this.maGiamGia = Menu.maGiamGia;
        }
        public virtual string checkKhoiTaoMenu(params object[] thamso)
        {
            return "khong la menu dat biet theo mua";
        }
        public delegate void thayDoi(int ma, Dictionary<int,object> list,params object[]thamso);
        public event thayDoi thayDoiMenu;
        public abstract object ketHopNuocUong(int maNuocTrongKho1, int maNuocTrongKho2, params object[] thamso);
        public abstract void kiemTraNgayVaThayDoiGia(DateTime ngayhomnay, params object[] thamso);
        public void thayDoiThanhPhanNuoc(int maNuocTrongKho, Dictionary<int,object> list, params object[] thamso)
        {
            if (maNuocTrongKho < this.listNuoc.Count)
            {
                if (list.ContainsKey(0) && (string)list[0] != null)
                    this.listNuoc[maNuocTrongKho].idNuoc = (string)list[0];
                if (list.ContainsKey(1) && (string)list[1] != null)
                    this.listNuoc[maNuocTrongKho].nameNuoc = (string)list[1];
                if (list.ContainsKey(2) && (double)list[2] != 0)
                    this.listNuoc[maNuocTrongKho].price = (double)list[2];
                if (list.ContainsKey(7) && (int)list[7] != 0)
                    this.listNuoc[maNuocTrongKho].soLuongBan = (int)list[7];
                if (list.ContainsKey(8))
                    this.listNuoc[maNuocTrongKho].kieuNuocNay = (kieuNuoc)(int)list[8];
            }
        }
        public void thayDoiThanhPhanKhach(int maSoKhach, Dictionary<int,object> list, params object[] thamso)
        {
            if (thamso.Length == 0)
            {
                if (maSoKhach < this.listKhach.Count)
                {
                    if (list.ContainsKey(3) && (string)list[3] != null)
                        this.listKhach[maSoKhach].anhKhach = (string)list[3];
                    if (list.ContainsKey(4) && (string)list[4] != null)
                        this.listKhach[maSoKhach].tenKhach = (string)list[4];
                    if (list.ContainsKey(9) && (int)list[9] == 0)
                        this.listKhach[maSoKhach].maSoKhach = maSoKhach;
                }
            }
            else {
                if ((int)thamso[0] < this.listKhach.Count)
                {
                    if (list.ContainsKey(3) && (string)list[3] != null)
                        this.listKhach[(int)thamso[0]].anhKhach = (string)list[3];
                    if (list.ContainsKey(4) && (string)list[4] != null)
                        this.listKhach[(int)thamso[0]].tenKhach = (string)list[4];
                    if (list.ContainsKey(9) && (int)list[9] == 0)
                        this.listKhach[(int)thamso[0]].maSoKhach = maSoKhach;
                }
            }
        }
        public void xoaThanhPhanNuoc(int maNuocTrongKho, Dictionary<int, object> list, params object[] thamso)
        {
            if (list.ContainsKey(1) && (int)list[1] == 0&&this.listNuoc.Count > maNuocTrongKho)
            { this.listNuoc.Remove(this.listNuoc[maNuocTrongKho]); }
            else if(this.listNuoc.Count > maNuocTrongKho)
            {
                if (list.ContainsKey(0) && (int)list[0] == 0)
                    this.listNuoc[maNuocTrongKho].idNuoc = null;
                if (list.ContainsKey(2) && (int)list[2] == 0)
                    this.listNuoc[maNuocTrongKho].price = 0;
                if (list.ContainsKey(7) && (int)list[7] == 0)
                    this.listNuoc[maNuocTrongKho].soLuongBan = (int)list[7];
                if (list.ContainsKey(8) && (int)list[8] == 0)
                    this.listNuoc[maNuocTrongKho].kieuNuocNay =(kieuNuoc)0;
            }
        }
        public void doXoaNuoc_Khach()
        { int i;
            for(i=0;i<this.listNuoc.Count;i++)
            { if (this.listNuoc[i].nameNuoc == null) this.listNuoc.Remove(this.listNuoc[i]); }
            for (i = 0; i < this.listKhach.Count; i++)
            { if (this.listKhach[i].tenKhach == null) this.listKhach.Remove(this.listKhach[i]); }
        }
        public void xoaThanhPhanKhach(int maSoKhach, Dictionary<int, object> list, params object[] thamso)
        {
            if (thamso.Length == 0)
            {
                if (list.ContainsKey(3) && (int)list[3] == 0)
                    this.listKhach[maSoKhach].anhKhach = null;
                if (list.ContainsKey(4) && (int)list[4] == 0)
                    this.listKhach[maSoKhach].tenKhach = null;
                if (list.ContainsKey(9) && (int)list[9] == 0)
                    this.listKhach[maSoKhach].maSoKhach = 0;
            }
            else
            {
                if (list.ContainsKey(3) && (int)list[3] == 0)
                    this.listKhach[(int)thamso[0]].anhKhach = null;
                if (list.ContainsKey(4) && (int)list[4] == 0)
                    this.listKhach[(int)thamso[0]].tenKhach = null;
                if (list.ContainsKey(9) && (int)list[9] == 0)
                    this.listKhach[(int)thamso[0]].maSoKhach = 0;
            }

        }
        public object showMeNu()
        {
            object ketQua="";
            foreach (Nuoc nuoc in this.listNuoc)
            {
                ketQua += (string)nuoc.showNuoc();
            };
            foreach (Khach khach in this.listKhach)
            {
                ketQua += (string)khach.showKhach();
            }
            return ketQua;
        }
        public void thayDoiTopping(int maNuocTrongKho, List<string> list, params object[] thamso) 
        {
            int i = 0;
            while (i != list.Count )
            { this.listNuoc[maNuocTrongKho].toppings.Add((string)list[i]);i++; }
        }
        public object thayDoi_TimKiemTrongMenuVaShowThayDoi(int maNuocTrongKho,int maSoKhach,Dictionary<int,object>  list, params object[] thamso) 
        {
            object i="",a="";
            if (maNuocTrongKho > this.listNuoc.Count) this.listNuoc.Add(new Nuoc());
            else if (maSoKhach > this.listKhach.Count) this.listKhach.Add(new Khach());
            if (maNuocTrongKho != -1&&maSoKhach==-1)
                thayDoiMenu?.Invoke(maNuocTrongKho, list);
            else if (maSoKhach != -1&&maNuocTrongKho==-1) 
                thayDoiMenu?.Invoke(maSoKhach, list);
            else if(maNuocTrongKho != -1 && maSoKhach != -1) 
                thayDoiMenu?.Invoke(maNuocTrongKho, list, maSoKhach);
            this.maGiamGia = (string)list[6];
            if (maNuocTrongKho != -1)
            {
                if (this.listNuoc.Count > maNuocTrongKho)
                    i = this.listNuoc[maNuocTrongKho].showNuoc();
                else i = "Da xoa nuoc co ma: " + maNuocTrongKho;
            }
            if (maSoKhach != -1)
            {
                if (this.listKhach.Count > maSoKhach)
                    a = (string)i + "\n" + this.listKhach[maSoKhach].showKhach();
                else a = "Da xoa khach co ma: " + maSoKhach;
            }
            else a = i;
            return a;
        }
        

    }
}
