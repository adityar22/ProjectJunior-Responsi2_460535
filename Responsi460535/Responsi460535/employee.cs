using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsi460535
{
    public class employee: departemen
    {
        private string id_karyawan;
        private string nama;

        public string Id_karyawan { get => id_karyawan; set => id_karyawan = value; }
        public string Nama { get => nama; set => nama = value; }
    }
}
