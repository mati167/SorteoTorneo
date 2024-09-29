using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteoTorneo
{
    public class Cancion
    {
        public string cancion { get; set; }
        public string banda { get; set; }

    }
    public class Grupo
    {
        public List<Cancion> temas { get; set; }
        public int grupo {  get; set; }
    }
}
