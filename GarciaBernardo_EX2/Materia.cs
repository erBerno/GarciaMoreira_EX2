using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarciaBernardo_EX2
{
    class Materia
    {
        public string CodMateria { get; set; }
        public string NomMateria { get; set; }
        public int Semestre { get; set; }

        public Materia(string codMateria, string nomMateria, int semestre)
        {
            CodMateria = codMateria;
            NomMateria = nomMateria;
            Semestre = semestre;
        }
    }
}
