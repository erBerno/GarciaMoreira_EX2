using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarciaBernardo_EX2
{
    class Carrera
    {
        public string CodCarrera { get; set; }
        public string NomCarrera { get; set; }
        public string NomDirector { get; set; }

        public Carrera(string cod, string nom, string nomd)
        {
            CodCarrera = cod;
            NomCarrera = nom;
            NomDirector = nomd;
        }
    }
}
