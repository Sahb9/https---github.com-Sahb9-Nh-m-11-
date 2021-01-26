using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public struct cauTuc
    {
        //
    }
    class Program
    {
        static ConsoleKeyInfo Key;
        static Dictionary<int, object> Dic = new Dictionary<int, object>();
        static int maNuocTrongKho = 0, maSoKhach = 0;
        static DateTime DateTime;
        static List<Menu> Menu = new List<Menu>();
        static int i = 0, a = 0;
        static maQR ma = new maQR();
        static QLRestaurant nhaHang = new QLRestaurant();
        static string[] string_rand = { "Rufus", "Bear", "Dakota", "Fido", "Vanya", "Samuel", "Koani", "Volodya", "Prince", "Yiska" };
        static string y = "rong";
        static int x = 1;
        static bool kiemTra()
        {
            a = maSoKhach;
            if (Menu[i].listKhach.Count < a)
            {
                return false;
            }
            a = maNuocTrongKho;
            if (Menu[i].listNuoc.Count < a)
            {
                return false;
            }
            return true;
        }
        static void deleteDicForChangeMenu()
        {
            if (Dic.ContainsKey(0))
                Dic.Remove(0);
            if (Dic.ContainsKey(1))
                Dic.Remove(1);
            if (Dic.ContainsKey(2))
                Dic.Remove(2);
            if (Dic.ContainsKey(3))
                Dic.Remove(3);
            if (Dic.ContainsKey(4))
                Dic.Remove(4);
            if (Dic.ContainsKey(5))
                Dic.Remove(5);
            if (Dic.ContainsKey(6))
                Dic.Remove(6);
            if (Dic.ContainsKey(7))
                Dic.Remove(7);
            if (Dic.ContainsKey(8))
                Dic.Remove(8);
            if (Dic.ContainsKey(12))
                Dic.Remove(12);
        }
        static void addDicForChangeMenu()
        {
            Dic.Add(0, "");
            Dic.Add(1, "");
            Dic.Add(2, "");
            Dic.Add(3, "");
            Dic.Add(4, "");
            Dic.Add(5, "");
            Dic.Add(6, "");
            Dic.Add(7, "");
            Dic.Add(8, "");
        }
        static void thayDoi_XemMenu()
        {
            int solan = 0;
            Console.Write("Press 0: De chon thay doi thanh phan nuoc\nPress 1| Thay doi thanh phan khach\n" +
              "Press 2| Xoa thanh phan nuoc Menu \nPress 3| De xoa thanh phan khach Menu \nPress 4| De them thanh phan nuoc, khach\n" +
              "Press 5| Xoa thanh phan nuoc, khach\nPress 6| Show nuoc,khach\nPress 7| Thay doi topping\n" +
              "Press 8| Ket hop nuoc da co trong menu\nPress 9| Check xem dang la menu gi\n" +
              "LUU Y KHI THEM MA NUOC HAY MA KHACH THI MA NUOC HAY MA KHACH <= "
              + Menu[i].listNuoc.Count + "( cho nuoc)hay " + Menu[i].listKhach.Count + "( cho khach) + 1\n" +
              "lua chon la: ");
            Dic.Add(12, 0); addDicForChangeMenu();
            Key = Console.ReadKey(true);
            if (Key.Key == ConsoleKey.D0)
            {
                Menu[i].thayDoiMenu += Menu[i].thayDoiThanhPhanNuoc;
                Console.Write("nhap so lan muon thuc hien: "); solan = int.Parse(Console.ReadLine());
                while (solan > 0)
                {
                    thayDoiNuoc();
                    Console.Write("nhap ma so nuoc"); maNuocTrongKho = int.Parse(Console.ReadLine());
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].thayDoiThanhPhanNuoc;
            }
            else if (Key.Key == ConsoleKey.D1)
            {
                Menu[i].thayDoiMenu += Menu[i].thayDoiThanhPhanKhach;
                Console.Write("nhap so lan muon thuc hien: "); solan = int.Parse(Console.ReadLine());
                while (solan > 0)
                {
                    thayDoiKhach();
                    Console.Write("nhap ma so khach"); maSoKhach = int.Parse(Console.ReadLine());
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].thayDoiThanhPhanKhach;
            }
            else if (Key.Key == ConsoleKey.D2)
            {
                Menu[i].thayDoiMenu += Menu[i].xoaThanhPhanNuoc;
                Console.Write("nhap so lan muon thuc hien: "); solan = int.Parse(Console.ReadLine());
                while (solan > 0)
                {
                    xoaNuoc();
                    Console.Write("nhap ma so nuoc"); maNuocTrongKho = int.Parse(Console.ReadLine());
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].xoaThanhPhanNuoc;
            }
            else if (Key.Key == ConsoleKey.D3)
            {
                Menu[i].thayDoiMenu += Menu[i].xoaThanhPhanKhach;
                Console.Write("nhap so lan muon thuc hien: "); solan = int.Parse(Console.ReadLine());
                while (solan > 0)
                {
                    xoaKhach();
                    Console.Write("nhap ma so khach"); maSoKhach = int.Parse(Console.ReadLine());
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].xoaThanhPhanKhach;
            }
            else if (Key.Key == ConsoleKey.D4)
            {
                Menu[i].thayDoiMenu += Menu[i].thayDoiThanhPhanNuoc;
                Menu[i].thayDoiMenu += Menu[i].thayDoiThanhPhanKhach;
                Console.Write("nhap so lan muon thuc hien: "); solan = int.Parse(Console.ReadLine());
                while (solan > 0)
                {
                    thayDoiNuoc();
                    Console.Write("nhap ma so nuoc"); maNuocTrongKho = int.Parse(Console.ReadLine());
                    thayDoiKhach();
                    Console.Write("nhap ma so khach"); maSoKhach = int.Parse(Console.ReadLine());
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].thayDoiThanhPhanKhach;
                Menu[i].thayDoiMenu -= Menu[i].thayDoiThanhPhanNuoc;
            }
            else if (Key.Key == ConsoleKey.D5)
            {
                Menu[i].thayDoiMenu += Menu[i].xoaThanhPhanNuoc;
                Menu[i].thayDoiMenu += Menu[i].xoaThanhPhanKhach;
                Console.Write("nhap so lan muon thuc hien: "); solan = int.Parse(Console.ReadLine());
                while (solan > 0)
                {
                    xoaNuoc();
                    Console.Write("nhap ma so nuoc"); maNuocTrongKho = int.Parse(Console.ReadLine());
                    xoaKhach();
                    Console.Write("nhap ma so khach"); maSoKhach = int.Parse(Console.ReadLine());
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].xoaThanhPhanNuoc;
                Menu[i].thayDoiMenu -= Menu[i].xoaThanhPhanKhach;
            }
            else if (Key.Key == ConsoleKey.D6)
            {
                Console.Write("nhap ma so nuoc"); maNuocTrongKho = int.Parse(Console.ReadLine());
                Console.Write("nhap ma so khach"); maSoKhach = int.Parse(Console.ReadLine());
                if (kiemTra())
                    Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
            }
            else if (Key.Key == ConsoleKey.D7)
            {
                Console.Write("nhap ma so nuoc"); maNuocTrongKho = int.Parse(Console.ReadLine()); Console.WriteLine(maNuocTrongKho);
                thayDoiToppingNuoc();
            }
            else if (Key.Key == ConsoleKey.D8) ketHopNuocTrongMenuDaCo();

            deleteDicForChangeMenu();
        }
        static void thayDoiToppingNuoc()
        {
            List<string> list = new List<string>();
            Console.Write("nhap ma nuoc: "); maNuocTrongKho = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("nhap topping thu " + list.Count + " ");
                list.Add(Console.ReadLine());
                Console.WriteLine("nhan esc de thoat");
                Key = Console.ReadKey(true);
            } while (Key.Key != ConsoleKey.Escape);
            Menu[i].thayDoiTopping(maNuocTrongKho, list);
        }
        static void thayDoiKhach()
        {
            Console.Write("nhap anh khach: ");
            Dic[3] = Console.ReadLine();
            Console.Write("nhap ten khach: ");
            Dic[4] = Console.ReadLine();
            Console.Write("nhap ma so khach( kieu so nguyen): ");
            int i = 0; i = int.Parse(Console.ReadLine());
            Dic[9] = i;
        }
        static void thayDoiNuoc()
        {
            Console.Write("nhap id nuoc:");
            Dic[0] = Console.ReadLine();
            Console.Write("nhap ten nuoc: ");
            Dic[1] = Console.ReadLine();
            Console.Write("nhap gia nuoc(so thuc): ");
            double f = 0; f = double.Parse(Console.ReadLine());
            Dic[2] = f;
            Console.Write("nhap so luong ban(so nguyen): ");
            int i = 0; i = int.Parse(Console.ReadLine());
            Dic[7] = i;
            Console.Write("nhap kieu nuoc nay: ");
            Dic[8] = Console.ReadLine();
        }
        static void xoaNuoc()
        {
            Console.Write("chi nhap 0(xoa) hay 1(khong xoa)\nxoa nuoc khong:");
            Dic[0] = int.Parse(Console.ReadLine());
            Console.Write("xoa ten nuoc khong: ");
            Dic[1] = int.Parse(Console.ReadLine());
            Console.Write("xoa gia nuoc khong ");
            Dic[2] = int.Parse(Console.ReadLine());
            Console.Write("xoa so luong ban khong: ");
            Dic[7] = int.Parse(Console.ReadLine());
            Console.Write("xoa kieu nuoc nay khong: ");
            Dic[8] = int.Parse(Console.ReadLine());
        }
        static void xoaKhach()
        {
            Console.Write("xoa anh khach khong: ");
            Dic[3] = int.Parse(Console.ReadLine());
            Console.Write("xoa ten khach khong: ");
            Dic[4] = int.Parse(Console.ReadLine());
            Console.Write("xoa ma so khach khong: ");
            Dic[9] = int.Parse(Console.ReadLine());
        }
        static void thayDoi_XemMenu_Rand()
        {
            int solan = 0; var in_rand = new Random();
            Console.Write("Press 0| Thiet lap Menu nuoc uong\nPress 1|  Thiet lap danh sach khach\n" +
               "Press 2| Xoa thanh phan nuoc Menu \nPress 3| De xoa thanh phan khach trong danh sach \nPress 4| De them thanh phan nuoc, khach\n" +
               "Press 5| Xoa thanh phan nuoc, khach\nPress 6| Xuat thong tin nuoc,khach\nPress 7| Thay doi topping\n" +
               "Press 8| Ket hop nuoc da co trong menu\nPress 9| Check xem dang la menu gi\n" +
               "LUU Y KHI THEM MA NUOC HAY MA KHACH THI MA NUOC HAY MA KHACH <= "
               + Menu[i].listNuoc.Count + "( cho nuoc)hay " + Menu[i].listKhach.Count + "( cho khach) + 1\n" +
               "lua chon la: ");
            Dic.Add(12, 0); addDicForChangeMenu();
            Key = Console.ReadKey(true); Console.WriteLine(Key.KeyChar + "\n");
            if (Key.Key == ConsoleKey.D0)
            {
                Menu[i].thayDoiMenu += Menu[i].thayDoiThanhPhanNuoc;
                Console.Write("nhap so lan muon thuc hien: "); solan = in_rand.Next(1, 10); Console.WriteLine(solan + "\n");
                while (solan > 0)
                {
                    thayDoiNuoc_Rand();
                    Console.Write("nhap ma so nuoc"); maNuocTrongKho = in_rand.Next(1, 10); Console.WriteLine(maNuocTrongKho);
                    if (kiemTra())
                        Console.WriteLine("ban da thay doi thanh: \n" + Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, -1, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].thayDoiThanhPhanNuoc;
            }
            else if (Key.Key == ConsoleKey.D1)
            {
                Menu[i].thayDoiMenu += Menu[i].thayDoiThanhPhanKhach;
                Console.Write("nhap so lan muon thuc hien: "); solan = in_rand.Next(1, 10); Console.WriteLine(solan + "\n");
                while (solan > 0)
                {
                    thayDoiKhach_Rand();
                    Console.Write("nhap ma so khach"); maSoKhach = in_rand.Next(1, 10); Console.WriteLine(maSoKhach + "\n");
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(-1, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].thayDoiThanhPhanKhach;
            }
            else if (Key.Key == ConsoleKey.D2)
            {
                Menu[i].thayDoiMenu += Menu[i].xoaThanhPhanNuoc;
                Console.Write("nhap so lan muon thuc hien: "); solan = in_rand.Next(1, 10); Console.WriteLine(solan + "\n");
                while (solan > 0)
                {
                    xoaNuoc_Rand();
                    Console.Write("\nnhap ma so nuoc"); maNuocTrongKho = in_rand.Next(1, 10); Console.WriteLine(maNuocTrongKho);
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, -1, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].xoaThanhPhanNuoc;
            }
            else if (Key.Key == ConsoleKey.D3)
            {
                Menu[i].thayDoiMenu += Menu[i].xoaThanhPhanKhach;
                Console.Write("nhap so lan muon thuc hien: "); solan = in_rand.Next(1, 10); Console.WriteLine(solan + "\n");
                while (solan > 0)
                {
                    xoaKhach_Rand();
                    Console.Write("\nnhap ma so khach"); maSoKhach = in_rand.Next(1, 10); Console.WriteLine(maSoKhach);
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(-1, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].xoaThanhPhanKhach;
            }
            else if (Key.Key == ConsoleKey.D4)
            {
                Menu[i].thayDoiMenu += Menu[i].thayDoiThanhPhanNuoc;
                Menu[i].thayDoiMenu += Menu[i].thayDoiThanhPhanKhach;
                Console.Write("nhap so lan muon thuc hien: "); solan = in_rand.Next(1, 10); Console.WriteLine(solan + "\n");
                while (solan > 0)
                {
                    thayDoiNuoc_Rand();
                    Console.Write("nhap ma so nuoc"); maNuocTrongKho = in_rand.Next(1, 10); Console.WriteLine(maNuocTrongKho);
                    thayDoiKhach_Rand();
                    Console.Write("nhap ma so khach"); maSoKhach = in_rand.Next(1, 10); Console.WriteLine(maSoKhach);
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].thayDoiThanhPhanKhach;
                Menu[i].thayDoiMenu -= Menu[i].thayDoiThanhPhanNuoc;
            }
            else if (Key.Key == ConsoleKey.D5)
            {
                Menu[i].thayDoiMenu += Menu[i].xoaThanhPhanNuoc;
                Menu[i].thayDoiMenu += Menu[i].xoaThanhPhanKhach;
                Console.Write("nhap so lan muon thuc hien: "); solan = in_rand.Next(1, 10); Console.WriteLine(solan + "\n");
                while (solan > 0)
                {
                    xoaNuoc_Rand();
                    Console.Write("nhap ma so nuoc"); maNuocTrongKho = in_rand.Next(1, 10); Console.WriteLine(maNuocTrongKho);
                    xoaKhach_Rand();
                    Console.Write("nhap ma so khach"); maSoKhach = in_rand.Next(1, 10); Console.WriteLine(maSoKhach);
                    if (kiemTra())
                        Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
                    solan--;
                }
                Menu[i].thayDoiMenu -= Menu[i].xoaThanhPhanNuoc;
                Menu[i].thayDoiMenu -= Menu[i].xoaThanhPhanKhach;
            }
            else if (Key.Key == ConsoleKey.D6)
            {
                Console.Write("nhap ma so nuoc"); maNuocTrongKho = in_rand.Next(1, 10); Console.WriteLine(maNuocTrongKho);
                Console.Write("nhap ma so khach"); maSoKhach = in_rand.Next(1, 10); Console.WriteLine(maSoKhach);
                if (kiemTra())
                    Console.WriteLine(Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi(maNuocTrongKho, maSoKhach, Dic));
            }
            else if (Key.Key == ConsoleKey.D7)
            {
                Console.Write("nhap ma so nuoc"); maNuocTrongKho = in_rand.Next(1, 10); Console.WriteLine(maNuocTrongKho);
                thayDoiToppingNuoc_Rand();
            }
            else if (Key.Key == ConsoleKey.D8) ketHopNuocTrongMenuDaCo();
            else if (Key.Key == ConsoleKey.D9)
            {
                Console.WriteLine(Menu[i].checkKhoiTaoMenu());
            }
            deleteDicForChangeMenu();
        }
        static void thayDoiToppingNuoc_Rand()
        {
            var in_rand = new Random();
            int mIndex = in_rand.Next(string_rand.Length);
            List<string> list = new List<string>();
            Console.Write("nhap ma nuoc: "); maNuocTrongKho = in_rand.Next(1, 10);
            do
            {
                Console.Write("nhap topping thu " + list.Count + " ");
                list.Add(string_rand[mIndex]);
                Console.WriteLine("nhan esc de thoat");
                Key = Console.ReadKey(true);
            } while (Key.Key != ConsoleKey.Escape);
            Menu[i].thayDoiTopping(maNuocTrongKho, list);
        }
        static void thayDoiKhach_Rand()
        {
            var in_rand = new Random();
            int mIndex = in_rand.Next(string_rand.Length);
            Console.Write("nhap anh khach: ");
            Dic[3] = string_rand[mIndex] + maSoKhach; Console.WriteLine(Dic[3]);
            Console.Write("nhap ten khach: ");
            Dic[4] = string_rand[mIndex] + maSoKhach; Console.WriteLine(Dic[4]);
            Console.Write("nhap ma so khach( kieu so nguyen): ");
            int i = 0; i = in_rand.Next(1, 10); Console.WriteLine(i);
            Dic[9] = i;
        }
        static void thayDoiNuoc_Rand()
        {
            var in_rand = new Random();
            int mIndex = in_rand.Next(string_rand.Length);
            List<string> list = new List<string>();
            Console.Write("nhap id nuoc:");
            Dic[0] = string_rand[mIndex] + maNuocTrongKho; Console.WriteLine(Dic[0]);
            Console.Write("nhap ten nuoc: ");
            Dic[1] = string_rand[mIndex] + maNuocTrongKho; Console.WriteLine(Dic[1]);
            Console.Write("nhap gia nuoc(so thuc): ");
            double f = 0; f = in_rand.NextDouble() * 10;
            Dic[2] = f; Console.WriteLine(Dic[2]);
            Console.Write("nhap so luong ban(so nguyen): ");
            int i = 0; i = in_rand.Next(1, 10);
            Dic[7] = i; Console.WriteLine(Dic[7]);
            Console.Write("nhap kieu nuoc nay: ");
            Dic[8] = in_rand.Next(2); Console.WriteLine(Dic[8] + "\n");
        }
        static void xoaNuoc_Rand()
        {
            var in_rand = new Random();
            Console.Write("chi nhap 0(xoa) hay 1(khong xoa)\nxoa nuoc khong:");
            Dic[0] = in_rand.Next(2); Console.WriteLine(Dic[0]);
            Console.Write("xoa ten nuoc khong: ");
            Dic[1] = in_rand.Next(2); Console.WriteLine(Dic[1]);
            Console.Write("xoa gia nuoc khong ");
            Dic[2] = in_rand.Next(2); Console.WriteLine(Dic[2]);
            Console.Write("xoa so luong ban khong: ");
            Dic[7] = in_rand.Next(2); Console.WriteLine(Dic[7]);
            Console.Write("xoa kieu nuoc nay khong: ");
            Dic[8] = in_rand.Next(2); Console.WriteLine(Dic[8]);
        }
        static void xoaKhach_Rand()
        {
            var in_rand = new Random();
            Console.Write("xoa anh khach khong: ");
            Dic[3] = in_rand.Next(2); Console.WriteLine(Dic[3]);
            Console.Write("xoa ten khach khong: ");
            Dic[4] = in_rand.Next(2); Console.WriteLine(Dic[4]);
            Console.Write("xoa ma so khach khong: ");
            Dic[9] = in_rand.Next(2); Console.WriteLine(Dic[9]);
        }
        static void addMenuNuoc_Khach_Rand()
        {
            for (int a = 0; a < 10; a++)
                Menu[i].listNuoc.Add(new Nuoc());
            for (int a = 0; a < 10; a++)
                Menu[i].listKhach.Add(new Khach());
        }
        static void ketHopNuocTrongMenuDaCo()
        {
            if (Menu[i].listNuoc.Count >= 2)
            {
                Console.Write("chon ma nuoc dau tien: "); maNuocTrongKho = int.Parse(Console.ReadLine());
                Console.Write("chan ma nuoc thu hai: ");
                int maNuocTrongKho2 = int.Parse(Console.ReadLine());
                Console.WriteLine("nuoc vua ket hop duoc" + (string)Menu[i].thayDoi_TimKiemTrongMenuVaShowThayDoi((int)Menu[i].ketHopNuocUong(maNuocTrongKho, maNuocTrongKho2), -1, Dic));
            }
        }
        static void thayDoiGiaTrongNgay()
        {
            DateTime = DateTime.Today;
            if (Menu[i].dicNgayBatDau.Count == 0)
                Console.WriteLine("khong co thay doi gia trong ngay");
            else
            {
                Menu[i].kiemTraNgayVaThayDoiGia(DateTime);
            }
        }
        static void addNgayLeHoi()
        {
            string ten;
            Console.Write("nhap so lan muon thuc hien: "); int solan = int.Parse(Console.ReadLine());
            while (solan > 0)
            {
                Console.Write("chon ten le hoi: "); ten = Console.ReadLine();
                if (Menu[i].dicNgayBatDau.ContainsKey(ten)) { Console.WriteLine("ten le hoi bi trung vui long chon lai"); continue; }
                Console.Write("chon ngay bat dau: ");
                Menu[i].dicNgayBatDau.Add(ten, DateTime.Parse(Console.ReadLine()));
                Console.Write("chon ngay ket thuc: ");
                Menu[i].dicNgayKetThuc.Add(ten, DateTime.Parse(Console.ReadLine()));
                Console.Write("chon phan tram giam: ");
                Menu[i].soTienGiam.Add(ten, double.Parse(Console.ReadLine()));
                solan--;
            }
        }
        static void khoiTao(int j)
        {
            var in_rand = new Random();
            int y = 0, z = 0, b = 0;
            string a = "";
            int solan = 1; ;
            if (j != 1) solan = in_rand.Next(2, 6);
            Console.WriteLine("So lan thuc hien: " + solan);
            while (solan >= 1)
            {
                maQR ma = new maQR();
                int mIndex = in_rand.Next(string_rand.Length);
                Console.Write("\nNhap ten khach: ");
                if (j != 1) a = string_rand[mIndex];
                else a = Console.ReadLine(); Console.WriteLine(a);
                Console.Write("Nhap ma khach: ");
                if (j != 1) b = in_rand.Next(0, 10);
                else b = int.Parse(Console.ReadLine()); Console.WriteLine(b);
                Console.Write("Nhap diem tich luy : ");
                if (j != 1) y = in_rand.Next(1, 99);
                else y = int.Parse(Console.ReadLine()); Console.WriteLine(b);
                Console.Write("Nhap cap do level (1|Basic,2|Silvel,3|Gold,4|Pladium,5|Diamond): ");
                if (j != 1) z = in_rand.Next(1, 5);
                else z = int.Parse(Console.ReadLine()); Console.WriteLine(z); Console.WriteLine((Level)z - 1);
                ma.nhap(a, b, y, z);
                //Console.WriteLine(ma.xuat());
                nhaHang.Ma.Add(ma);
                solan--;
            }
        }
        static void luaChonKhach()
        {
            for (int j = 0; j < nhaHang.Ma.Count; j++)
            {
                Console.Write("  |" + x++ + " Ten: " + nhaHang.Ma[j].tenKhachHang + "\n");
            }
            x = int.Parse(Console.ReadLine());
            for (int j = 0; j < nhaHang.Ma.Count; j++)
            {
                if (j == x - 1)
                    Console.WriteLine(nhaHang.Ma[j].xuat());
            }
        }
        static void luachon()
        {
            Console.WriteLine("");
            if (Key.Key == ConsoleKey.D0)
                Console.WriteLine("Lua chon la: " + 0);
            else if (Key.Key == ConsoleKey.D1)
                Console.WriteLine("Lua chon la: " + 1);
            else if (Key.Key == ConsoleKey.D2)
                Console.WriteLine("Lua chon la: " + 2);
            else if (Key.Key == ConsoleKey.D3)
                Console.WriteLine("Lua chon la: " + 3);
        }
        static void kiemTraInfo(int j, string y)
        {
            if (j != 1)
            {
                Console.Write("Nhap ten khach hang: ");
                y = Console.ReadLine();
            }
            else
                luachon();
            int o = 1;
            IEnumerable<maQR> ltQuery =     //dung LinQ 
                from c in nhaHang.Ma
                where c.tenKhachHang == y
                select c;
            foreach (maQR a in ltQuery)
                if (a != null)
                {
                    Console.WriteLine("Ton Tai!!!\n" + a.xuat());
                    o = 0;
                }
            if (o == 1)
                Console.WriteLine("** ban muon dk maQR khong **\nPress 1| Yes -- Press other| No");
            Key = Console.ReadKey();
            luachon();
            if (Key.Key == ConsoleKey.D1)
                khoiTao(1);
        }
        static void ketHopMaQR()
        {
            if (nhaHang.Ma.Count >= 2)
            {
                x = 1;
                for (int j = 0; j < nhaHang.Ma.Count; j++)
                {
                    Console.Write("  |" + x++ + " Ten: " + nhaHang.Ma[j].tenKhachHang + "\n");
                }
                Console.Write("chon ten khang hang 1: "); x = int.Parse(Console.ReadLine()); maQR Ma1 = nhaHang.Ma[x - 1];
                Console.Write("chon ten khach hang 2: "); x = int.Parse(Console.ReadLine()); maQR Ma2 = nhaHang.Ma[x - 1];
                maQR Ma3 = Ma1 + Ma2;
                nhaHang.Ma.Add(Ma3);
                nhaHang.Ma.Remove(Ma1);
                nhaHang.Ma.Remove(Ma2);
                Console.WriteLine("Ma QR vua ket hop duoc: " + Ma3.xuat());
            }
        }
        static void thietLapMaQR()
        {
            Console.WriteLine("\nTHIET LAP DANH SACH MA QR\n-------------\nPress 0| Thiet lap danh sach Ma QR\nPress 1| Them Ma QR vao danh sach\n" + "Press 2| Xoa Ma QR trong danh sach " +
                "\nPress 3| Cap nhat Ma QR trong danh sach \nPress 4| Xuat danh sach Ma QR\n" + "Press 5| Nhap ten khach hang truy xuat thong tin\n" +
                "Press 6| Ket hop Ma QR (danh cho cap doi)\nPress 7| Nhap ten khach hang de xoa Ma QR\n");
            Key = Console.ReadKey(true);
            if (Key.Key == ConsoleKey.D0)
            {
                luachon();
                if (nhaHang.Ma.Count != 0) // thiet lap danh sach Ma QR neu da ton tai thi xoa du lieu va lam lai
                {
                    int j = 0;
                    do
                    {
                        nhaHang.Ma.RemoveAt(j);
                    } while (nhaHang.Ma.Count != 0);
                }
                khoiTao(0);
            }
            else if (Key.Key == ConsoleKey.D1)
            {
                luachon();
                khoiTao(0); //them Ma QR
            }
            else if (Key.Key == ConsoleKey.D2)
            {
                luachon();
                luaChonKhach();
                Console.WriteLine(nhaHang.Ma[i].deleteQR(nhaHang, x - 1));
            }
            else if (Key.Key == ConsoleKey.D3)
            {
                luachon();
                luaChonKhach();

                Console.WriteLine("Press 0| Sua ten            -- Press 1| Sua ma\n" +
                                  "Press 2| Sua Diem tich luy  -- Press 3| Sua Level (1|Basic,2|Silvel,3|Gold,4|Pladium,5|Diamond)");
                do
                {
                    Console.Write("Nhap lua chon: "); Key = Console.ReadKey(); luachon(); if (Key.Key == ConsoleKey.Escape) break; else Console.Write("\nNhap: ");
                    Console.WriteLine(nhaHang.Ma[x - 1].updateInFo(Key));
                } while (Key.Key != ConsoleKey.Escape);
            }
            else if (Key.Key == ConsoleKey.D4)
            {
                luachon();
                Console.Write("Danh sach ma QR\n_____");
                foreach (maQR a in nhaHang.Ma)
                    Console.Write(a.xuat());
            }
            else if (Key.Key == ConsoleKey.D5)
            {
                luachon();
                kiemTraInfo(0, "");
            }
            else if (Key.Key == ConsoleKey.D6)
            {
                luachon();
                ketHopMaQR();
            }
            else if (Key.Key == ConsoleKey.D7)
            {
                luachon(); Console.Write("Nhap ten: ");
                y = Console.ReadLine();
                luachon();
                int o = 1;
                for (int j = 0; j < nhaHang.Ma.Count; j++)
                    if (nhaHang.Ma[j].tenKhachHang == y)
                    {
                        nhaHang.Ma.RemoveAt(j);
                        Console.WriteLine("Xoa hoan tat");
                        o = 0; break;
                    }
                if (o == 1) Console.WriteLine("Khong ton tai");

            }
        }
        static void gameshow(Khach tt, List<Nuoc> myDrink)
        {
            int j = 1;
            Console.WriteLine("\nAll Drink Order:");
            foreach (Nuoc a in tt.myDrink) Console.Write(j++ + "--| " + a.nameNuoc + "  ");
            Console.Write("chon nuoc uong xem trinh dien: "); j = int.Parse(Console.ReadLine());
            Console.WriteLine("\nStart game:\n");
            if (tt.myDrink[j - 1].GetType() == typeof(kieuLon))
            {
                Console.Write("Nhap dia diem: "); y = Console.ReadLine();
                Console.Write("\nNhap so lan: "); j = int.Parse(Console.ReadLine());
                Nuoc.delegatekynang uythac = new Nuoc.delegatekynang(kieuLon.xoayLon);
                Dictionary<string, object> thamso = new Dictionary<string, object>()
                { {"dc",y},{ "sl",j} };
                tt.myDrink[i].onfinished += Program_onfinished2;
                string flo = tt.myDrink[i].show(uythac, thamso);
            }
            else if (tt.myDrink[j - 1].GetType() == typeof(KieuChai))
            {
                Console.Write("Nhap dia diem: "); y = Console.ReadLine();
                Console.Write("\nNhap so lan: "); j = int.Parse(Console.ReadLine());
                Nuoc.delegatekynang uythac = new Nuoc.delegatekynang(KieuChai.lacChai);
                Dictionary<string, object> thamso = new Dictionary<string, object>()
                { {"dc",y},{ "sl",j} };
                tt.myDrink[i].onfinished += Program_onfinished2;
                string flo = tt.myDrink[i].show(uythac, thamso);
            }
            else if (tt.myDrink[j - 1].GetType() == typeof(kieuThuyTinh))
            {
                Console.Write("Nhap dia diem: "); y = Console.ReadLine();
                Console.Write("\nNhap so mau: "); j = int.Parse(Console.ReadLine());
                Nuoc.delegatekynang uythac = new Nuoc.delegatekynang(kieuThuyTinh.trangTri);
                Dictionary<string, object> thamso = new Dictionary<string, object>()
                { {"dc",y},{ "mau",j} };
                tt.myDrink[i].onfinished += Program_onfinished2;
                string flo = tt.myDrink[i].show(uythac, thamso);
            }
        }

        private static void Program_onfinished2(object result)
        {
            Console.WriteLine("Trinh dien xong");
            Console.WriteLine("ket qua:\n");
            Console.WriteLine(result);
        }
        static void showNhaHang(QLRestaurant nhaHang, HoaDon hoaDon, Khach kh, maQR ma)
        {
            //b1 chon ten nha hang         
            Console.Write("CHON NHA HANG !!!\nPress 1 |Nha Hang.City     Press 2 |Nha Hang.Local  \n");
            Console.WriteLine("Press 3 |Nha Hang.Normar      ( ESC de thoat!!!)");
            Console.WriteLine(nhaHang.chooseTen());
            //b2 tuong tac voi menu
            do
            {
                Console.WriteLine("So luong khach: " + Menu[i].listKhach.Count);
                thayDoi_XemMenu_Rand();
                Key = Console.ReadKey(true);
            } while (Key.Key != ConsoleKey.Escape);
            /*
            //b3 tuong tac voi Ma QR (doi voi nha hang.city) --> event             
            Console.WriteLine("1"+nhaHang.tenCuaHang);
            Console.WriteLine("2" + (Name)0);
            if (nhaHang.tenCuaHang == (Name)0)
            {
                nhaHang.Ma[i].onfinished += Program_onfinished;
                string flo = nhaHang.Ma[i].show();
            }
            */
            do
            {
                thietLapMaQR();
                Key = Console.ReadKey();
            } while (Key.Key != ConsoleKey.Escape);
            //b3 chi dinh khach chon menu
            Khach tt = new Khach();
            tt.xuLiDuLieuList(Menu, i);
            int x = 1, z = 1; string y = "rong";
            for (int j = 0; j < Menu[i].listKhach.Count; j++)
            {
                if (Menu[i].listKhach[j].tenKhach != null)
                    Console.Write("  |" + x++ + " Ten: " + Menu[i].listKhach[j].tenKhach + "\n");
            }
            do
            {
                z = int.Parse(Console.ReadLine());
                if (z >= 0 && z <= x)
                {
                    tt.anhKhach = Menu[i].listKhach[z - 1].anhKhach;
                    tt.tenKhach = Menu[i].listKhach[z - 1].tenKhach;
                    tt.maSoKhach = Menu[i].listKhach[z - 1].maSoKhach;
                }
            } while (z < 0 && z > x);

            Console.WriteLine("\n Ten khach hang: " + y);
            //b4 KIEM TRA MA QR (event) -- neu ten nha hang la nhahang.city thi se co chuc nang maQR
            if (nhaHang.tenCuaHang == (Name)0)
            {

                Console.WriteLine("Kiem tra ma QR ");
                /*
                 nhaHang.Ma[i].onfinished += Program_onfinished1;
                 string flo = nhaHang.Ma[i].show();
                */
                kiemTraInfo(1, y);
            }
            //b5. Khach hang chon thuc uong trong Menu
            // Console.WriteLine(nhaHang.demSoLuong(tt, Menu));
            Console.WriteLine("\n THUC DON MENU \n******************");

            //b5 chon thuc uong tu menu
            x = 1;
            for (int j = 0; j < Menu[i].listNuoc.Count; j++)
            {
                Console.Write(x++ + "--" + "|" + Menu[i].listNuoc[j].nameNuoc + "\n");
            }
            do
            {
                Console.Write("Moi chon nuoc uong: ");
                x = int.Parse(Console.ReadLine());
                if ((x >= 0) && (x <= Menu[i].listNuoc.Count))
                {
                    Console.WriteLine("\nPress 0| dung trong lon\nPress 1| dung trong chai\nPress 2| dung trong chai thuy tinh ");
                    Key = Console.ReadKey();
                    if (Key.Key == ConsoleKey.D0)
                    {
                        tt.myDrink.Insert(i, new kieuLon());
                        tt.myDrink[x - 1].Type = typeShape.kieuLon;
                        Console.WriteLine("ten nuoc: " + Menu[i].listNuoc[x - 1].nameNuoc);
                        tt.myDrink[i].nameNuoc = Menu[i].listNuoc[x - 1].nameNuoc;
                    }
                    else if (Key.Key == ConsoleKey.D1)
                    {
                        tt.myDrink.Insert(i, new KieuChai());
                        tt.myDrink[x - 1].Type = typeShape.kieuChai;
                        Console.WriteLine("ten nuoc: " + Menu[i].listNuoc[x - 1].nameNuoc);
                        tt.myDrink[i].nameNuoc = Menu[i].listNuoc[x - 1].nameNuoc;
                    }
                    else if (Key.Key == ConsoleKey.D2)
                    {
                        tt.myDrink.Insert(i, new kieuThuyTinh());
                        tt.myDrink[x - 1].Type = typeShape.KieuThuyTinh;
                        Console.WriteLine("ten nuoc: " + Menu[i].listNuoc[x - 1].nameNuoc);
                        tt.myDrink[i].nameNuoc = Menu[i].listNuoc[x - 1].nameNuoc;
                    }
                }
                else
                    Console.WriteLine("Vui long nhap lai !!!");
                Console.WriteLine("Nhan ESC to exit"); Key = Console.ReadKey();
            } while (Key.Key != ConsoleKey.Escape);
            Console.WriteLine("\nNumber drinks Order: " + tt.myDrink.Count);
            Console.WriteLine(tt.showKhach() + "\nCac loai nuoc da goi: ");
            foreach (Nuoc a in tt.myDrink) Console.Write("  |Name: " + a.nameNuoc);
            //b6 show trinh dien
            if (tt.myDrink.Count != 0)
            {
                do
                {
                    Console.WriteLine("\nPress 1| Game show bartender  ---- Press other| to exit");
                    Key = Console.ReadKey();
                    if (Key.Key == ConsoleKey.D1) gameshow(tt, tt.myDrink);
                    else break;
                } while (Key.Key != ConsoleKey.Escape);
            }
            Console.Clear();
            //b7 thanh toan
            minhHoaChucNangThanhToan(hoaDon, kh, ma);
            //b8 xuat bang top cac loai nuoc uong (top1,top2,top3) -- event doi voi nha hang.city
            //  Console.WriteLine(nhaHang.demSoLuong(tt, Menu));
        }
        static void minhHoaChucNangThanhToan(HoaDon a, Khach kh, maQR ma)
        {
            xulyhoadon(a, kh);
            Console.WriteLine("==================================================");
            xulyTienShip(a);
            Console.WriteLine("==================================================");
            xuat(a, kh);
            Console.WriteLine("==================================================");
            KiemtraDiem(a, kh, ma);
            Console.WriteLine("==================================================");
            capnhatdiem(a, kh, ma);
        }
        //Minh Họa chức năng Thanh toán
        static void test1()
        {
            var in_rand = new Random();
            string[] ds_tt = { "Nha hang lmao ", "KFC", "lotteria", "Texaschicken" };
            string[] ds_kho = { "kho1", "kho2", "kho3" };
            string[] voucher = { "Co", "Khong" };
            int mIndex = in_rand.Next(ds_tt.Length);
            //Console.WriteLine(ds_tt[mIndex]);
            HoaDon a = new HoaDon();
            Console.WriteLine(a.kho + " - " + a.location + " - " + a.voucher);
            Console.WriteLine();

            HoaDon b = new HoaDon(ds_kho[in_rand.Next(ds_kho.Length)], ds_tt[in_rand.Next(ds_tt.Length)], voucher[in_rand.Next(voucher.Length)]);
            Console.WriteLine(b.kho + " - " + b.location + " - " + b.voucher);
        }
        static public void xuat(HoaDon a, Khach kh)
        {
            Console.WriteLine(a.xuatHoaDon(kh));
        }
        static void xulyhoadon(HoaDon a, Khach kh)
        {
            Console.WriteLine("Xu ly thong tin hoa don");
            Console.WriteLine(a.xulyHoaDon(kh, ""));
        }
        static void xulyTienShip(HoaDon a)
        {
            Console.WriteLine("Tính tien ship online hay offline");
            Dictionary<string, object> thamso = new Dictionary<string, object>();
            thamso.Add("on", "on");
            a.shiphang += A_shiphang;
            string result = (string)a.thucThiShiphang(HoaDon.Chonship_on, thamso);
            Console.WriteLine(result);
        }

        private static string A_shiphang(params Dictionary<string, object>[] thamso)
        {
            return "\nTinh Tien da xong \n";
        }
        static void KiemtraDiem(HoaDon a, Khach kh, maQR ma)
        {

            a.ktDiem += A_ktDiem;
            string result = (string)a.thucThiKiemTra(a.checkLevel, ma, kh);
            Console.WriteLine(result);
        }
        static void capnhatdiem(HoaDon a, Khach kh, maQR ma)
        {
            a.ktDiem += A_ktDiemtichluy;
            a.capnhatdiemtichluy(ma, kh);
            string result = (string)a.thucThiKiemTra(a.capnhatdiemtichluy, ma, kh);
            Console.WriteLine(result);
        }

        private static string A_ktDiemtichluy(maQR maqr, Khach kh)
        {
            return "Kiem tra cap nhat diem tich luy hoan tat";
        }
        private static string A_ktDiem(maQR maqr, Khach kh)
        {
            return "Kiem tra diem tich luy hoan tat \n";
        }
        static void Main(string[] args)
        {
            Menu.Add(new LamViecTrenMenuMuaGiangSinh());
            HoaDon a = new HoaDon();
            Khach kh = new Khach();
            maQR ma = new maQR();
            ConsoleKeyInfo Key;
            Console.WriteLine("Press 1| thay doi menu --- Press 2| thay doi le hoi nha hang --- Press esc| thoat\n" +
                "Press 3|show nuoc, khach cua menu");
            do
            {
                Key = Console.ReadKey(true);
                if (Key.Key == ConsoleKey.D1)
                    do
                    {
                        addMenuNuoc_Khach_Rand();
                        showNhaHang(nhaHang, a, kh, ma);
                        Key = Console.ReadKey(true);
                    } while (Key.Key != ConsoleKey.Escape);
                Menu[i].doXoaNuoc_Khach();
                if (Key.Key == ConsoleKey.D2)
                {
                    Console.WriteLine("Press 1| Them ngay le hoi  --- Press 2| Thay doi gia trong ngay --- Press esc| thoat"); Key = Console.ReadKey(true);
                    if (Key.Key == ConsoleKey.D1)
                    {
                        addNgayLeHoi();
                        Console.WriteLine("\n" + Menu[i].showMeNu());
                    }
                    if (Key.Key == ConsoleKey.D2) thayDoiGiaTrongNgay();
                }
                if (Key.Key == ConsoleKey.D3)
                {
                    addMenuNuoc_Khach_Rand();
                    Console.WriteLine(Menu[i].showMeNu());
                }
            } while (Key.Key != ConsoleKey.Escape);
        }
    }
}
