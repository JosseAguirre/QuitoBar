using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBares1.Data
{
    public class Bar
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public float latitud { get; set; }
        public float longitud { get; set; }
        public string descripcion { get; set; }
    }
}
