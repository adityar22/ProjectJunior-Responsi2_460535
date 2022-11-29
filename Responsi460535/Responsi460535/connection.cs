using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Npgsql;

namespace Responsi460535
{
    public class connection
    {
        public static NpgsqlConnection conn;
        private string connstring = "Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=Res460535";

        public void getConn()
        {
            conn = new NpgsqlConnection(connstring);
        }
    }
}
