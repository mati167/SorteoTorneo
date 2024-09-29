using SorteoTorneo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sorteador
{
    public class Funciones
    {
        public List<Cancion> Reader(string json)
        {
            return JsonSerializer.Deserialize<List<Cancion>>(json);
        }
    }


}
