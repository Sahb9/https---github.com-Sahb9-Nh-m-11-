using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public class LamViecTrenMenuMuaGiangSinh : Menu
    {
        public LamViecTrenMenuMuaGiangSinh() { }
        public LamViecTrenMenuMuaGiangSinh(Dictionary<string, DateTime> dicNgayKetThuc, Dictionary<string, DateTime> dicNgayBatDau, Dictionary<string, double> soTienGiam)
        {
            this.dicNgayBatDau = dicNgayBatDau;
            this.dicNgayKetThuc = dicNgayKetThuc;
            this.soTienGiam = soTienGiam;
        }
        public LamViecTrenMenuMuaGiangSinh(LamViecTrenMenuMuaGiangSinh lamViecTrenMenuMuaGiangSinh)
        {
            this.soTienGiam = lamViecTrenMenuMuaGiangSinh.soTienGiam;
            this.dicNgayBatDau = lamViecTrenMenuMuaGiangSinh.dicNgayBatDau;
            this.dicNgayKetThuc = lamViecTrenMenuMuaGiangSinh.dicNgayKetThuc;
        }
        public override object ketHopNuocUong(int maNuocTrongKho1, int maNuocTrongKho2, params object[] thamso)
        {
            int i = this.listNuoc.Count ;
            this.listNuoc.Add(new Nuoc(this.listNuoc[maNuocTrongKho1] + this.listNuoc[maNuocTrongKho2]));
            this.listNuoc[i].maNuocTrongKho = i;
            return i;
        }
        public override string checkKhoiTaoMenu(params object[] thamso)
        {
            return "Menu Khoi Tao Khong Bi Loi, day la menu mua giang sinh";
        }
        public override void kiemTraNgayVaThayDoiGia(DateTime ngayhomnay, params object[] thamso)
        {
            string tenSuKien = "";
            foreach (KeyValuePair<string, DateTime> ngay in dicNgayBatDau)
            {
                if (ngay.Value <= ngayhomnay)
                {
                    tenSuKien = ngay.Key;
                    if (this.dicNgayKetThuc[tenSuKien] >= ngayhomnay)
                    {

                        this.thayDoiTienNuocVaoNgayDaDinh(tenSuKien);
                        break;
                    }
                }
            }
        }
        private void thayDoiTienNuocVaoNgayDaDinh(string tenSuKien, params object[] thamso)
        {
            if (this.soTienGiam.ContainsKey(tenSuKien) && this.soTienGiam[tenSuKien] != 0)
                foreach (Nuoc nuoc in listNuoc)
                {
                    nuoc.price *= 100 / this.soTienGiam[tenSuKien];
                }
        }
    }
}
