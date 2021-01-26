using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public class kieuThuyTinh : Nuoc
    {
        
        public static string trangTri(params Dictionary<string, object>[] thamso)
        {
            string dc = (string)thamso[0]["dc"];
            int sl = (int)thamso[0]["mau"];
            return "b4: Bartender trang tri thuy tinh tai:  " + dc + " - voi " + sl + " mau \n";

        }
    }
}
