using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public class HoaDon
    {
        public string location { set; get; }
        public string kho { set; get; }
        public string voucher { set; get; }
        public List<string> ds = new List<string>();        // danh sách lưu hóa đơn
        //khởi tạo mặc định
        public HoaDon()
        {
            this.location = "tai cho";
            this.kho = "on-site";
            this.voucher = "Chua co ";
        }
        public HoaDon(string location, string kho, string voucher)
        {
            this.location = location;
            this.kho = kho;
            this.voucher = voucher;
        }
        public HoaDon(HoaDon HoaDon)
        {
            this.location = HoaDon.location;
            this.kho = HoaDon.kho;
            this.voucher = HoaDon.voucher;
        }
        //D1: Xữ lí dữ liệu
        public string xuLyDuLieu(params object[] thamso)
        {
            return "Xu ly du lieu";
        }


        public string upDate(params object[] thamso)
        {
            return "Da Update theo yeu cau";
        }

        //E2: Sử dụng điểm tích lũy Mã QR 
        public int diemTichLuy(params object[] thamso)
        {
            maQR a = new maQR();
            return a.diemTichLuy;
        }
        //E3: Tính tiền ship (bỏ qua nếu thanh toán off)
        //on là online


        //E4: Sử dụng ưu đãi (theo lễ,tết,dịp đặt biệt,… phương thức này sau này sẽ được cập nhật phát triển thêm)

        //E5: Xuất hóa đơn
        //Lưu string hóa đơn 
        //1 menu có nhiều nước 
        public string xuatHoaDon(Khach a)
        {

            string result = "abc";
            for (int i = 0; i < a.myDrink.Count; i++)
            {
                this.ds.Add(a.myDrink[i].nameNuoc + "  " + a.myDrink[i].soLuongBan + "  " + a.myDrink[i].price);
            }
            for (int i = 0; i < this.ds.Count; i++)
            {
                result += ds[i] + "\n";
            }
            return result;
        }

        //E7: Update điểm tích lũy xuống Mã QR
        public double tongDonGia(Khach a)
        {
            double tong = 0;
            for (int i = 0; i < a.myDrink.Count; i++)
            {
                tong += a.myDrink[i].price;
            }
            return tong;
        }
        public double updateDiem(Khach a)
        {
            if (tongDonGia(a) >= 500000)
            {
                return tongDonGia(a) / 10000 + 20;
            }
            else if (tongDonGia(a) >= 200000)
            {
                return tongDonGia(a) / 10000 + 10;
            }
            else if (tongDonGia(a) >= 100000)
            {
                return tongDonGia(a) / 10000 + 5;
            }
            else
                return tongDonGia(a) / 10000;
        }
        public string kiemTraDaTa(params object[] thamso)                   //thui , để tui về ktx r stream tiếp nha 
        {
            return "Kiem tra data ";
        }

        public string xulyHoaDon(Khach kh, params object[] thamso)
        {
            string result = "";
            result += this.xuLyDuLieu(thamso) + "\n";
            result += this.kiemTraDaTa(thamso) + "\n";
            result += this.diemTichLuy(thamso) + "\n";
            result += this.updateDiem(kh) + "\n";

            return result;
        }
        public string capnhatdiemtichluy(maQR maqr, Khach kh)
        {
            maqr.diemTichLuy = (int)this.updateDiem(kh);
            return "Da cap nhat diem tich luy len maqr\n";
        }
        public string checkLevel(maQR maqr, Khach kh)         //kiem tra diem tich luy de nang Cap level maQR
        {
            Level Cap = maqr.levelQR;
            double diem = this.updateDiem(kh);
            if (diem > 80)
            {
                Cap = Level.Diamond;
            }
            else if (diem > 75)
            {
                Cap = Level.Diamond;
            }
            else if (diem > 50)
            {
                Cap = Level.Gold;
            }
            else if (diem > 25)
            {
                Cap = Level.Silver;
            }
            return String.Format("Diem tich luy hien tai: {0} - Level QR : {1}\n", diem, Cap);
        }
        public delegate string UpdateDiem(maQR maqr, Khach kh);
        public event UpdateDiem ktDiem;
        public string luaChonPhuongThucKiemtra(UpdateDiem a, maQR maqr, Khach kh)
        {
            return a(maqr, kh);
        }
        public object thucThiKiemTra(UpdateDiem a, maQR maqr, Khach kh)
        {
            string result = luaChonPhuongThucKiemtra(a, maqr, kh) + ktDiem?.Invoke(maqr, kh);
            return result;
        }
        public delegate string UpdateShip(Dictionary<string, object>[] thamso);
        public event UpdateShip shiphang;
        public string luachontienship(UpdateShip a, params Dictionary<string, object>[] thamso)
        {

            return a(thamso);
        }
        public object thucThiShiphang(UpdateShip a, params Dictionary<string, object>[] thamso)     //object trả về 1 cái hộp rỗng, trả về kiểu tổng quát
        {

            string result = "";
            result = luachontienship(a, thamso) + shiphang?.Invoke(thamso);
            return result + this.upDate(thamso);
        }

        public static string Chonship_on(Dictionary<string, object>[] thamso)
        {
            Random rnd = new Random();

            string so = (string)thamso[0]["on"];
            return "Tinh Tien " + so + "line" + "\n Phi Van chuyen: " + rnd.Next(15000, 30000);
        }
        public static string Chonship_off(Dictionary<string, object>[] thamso)
        {
            string so = (string)thamso[0]["off"];
            return "Tinh Tien " + so + "line" + " mien phi";
        }
    }
}