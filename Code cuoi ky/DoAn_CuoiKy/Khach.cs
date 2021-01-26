using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public class Khach
    {
        public string tenKhach { get; set; }
        public int maSoKhach { get; set; }
        public string anhKhach { get; set; }
        public List<Nuoc> myDrink { set; get; }
        public Khach() 
        {
            this.myDrink = new List<Nuoc>();
        }
        public Khach(string tenKhach, int maSoKhach, string anhKhach)
        {
            this.tenKhach = tenKhach;
            this.maSoKhach = maSoKhach;
            this.anhKhach = anhKhach;
        }
        public Khach(Khach Khach)
        {
            this.tenKhach = Khach.tenKhach;
            this.maSoKhach = Khach.maSoKhach;
            this.anhKhach = Khach.anhKhach;
        }       
        public void xuLiDuLieuList(List<Menu> Menu,int i)
        {
            for (int j = 0; j < Menu[i].listNuoc.Count; j++)
            {
                if (Menu[i].listNuoc[j].nameNuoc == null)
                {
                    Menu[i].listNuoc.RemoveAt(j);
                    j--;
                }
            }
            for (int j = 0; j < Menu[i].listKhach.Count; j++)
            {
                if (Menu[i].listKhach[j].tenKhach == null)
                {
                    Menu[i].listKhach.RemoveAt(j);
                    j--;
                }
            }
        }       
        public string showKhach()
        { 
                return "\nAnh khach: "+this.anhKhach + "\nTen khach: " +
            this.tenKhach + "\nMa so khach: " +
            this.maSoKhach + "\n";
        }
    }
}
