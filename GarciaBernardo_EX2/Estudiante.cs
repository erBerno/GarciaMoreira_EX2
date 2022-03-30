using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarciaBernardo_EX2
{
    class Estudiante
    {
        public int CI { get; set; }
        public string NomEst { get; set; }
        public string CodCarrera { get; set; }
        public int Semestre { get; set; }

        public Estudiante(int ci, string nom, string cod, int s)
        {
            CI = ci;
            NomEst = nom;
            CodCarrera = cod;
            Semestre = s;
        }
    }
}
