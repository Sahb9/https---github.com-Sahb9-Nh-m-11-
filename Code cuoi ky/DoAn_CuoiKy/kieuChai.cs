using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CuoiKy
{
    public class KieuChai : Nuoc
    {
        public static string lacChai (params Dictionary<string,object>[]thamso)
        {
            string dc = (string)thamso[0]["dc"];
            int sl = (int)thamso[0]["sl"];
            return "b4: Bartender lac chai nhua tai:  " + dc + " - " + sl + "lan \n";

        }
    }
}
