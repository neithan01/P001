using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GeoLocalizarModel
    {
        public string calle { get; set; }
        public string numero { get; set; }
        public string condado { get; set; }
        public string código_postal { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
    }
}
