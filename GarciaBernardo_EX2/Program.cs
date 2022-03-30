using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarciaBernardo_EX2
{
    internal class Program
    {
        static Estudiante[] estudiantes = {
                new Estudiante(123, "Jose Costas", "ISI", 4),
                new Estudiante(234, "Carla Mendez", "ISI", 2),
                new Estudiante(345, "Lony Lopez", "IBI", 8),
                new Estudiante(456, "Elio Sierra", "ISI", 3),
                new Estudiante(567, "Jorge Andrade", "IBI", 8),
                new Estudiante(678, "Erika Herbas", "IEL", 5),
                new Estudiante(789, "Marco Ignacio", "ISI", 3),
                new Estudiante(890, "Jose Heredia", "IBI", 6),
                new Estudiante(901, "Ingrid Asis", "IEL", 5),
                new Estudiante(012, "Abel Illanes", "MED", 1), };

        static Carrera[] carreras = {

                new Carrera("ISI", "Ingenieria de Sistemas Informáticos", "DirISI"),
                new Carrera("IBI", "Ingenieria Biomedica", "DirIBI"),
                new Carrera("IEL", "Ingenieria Electronica", "DirIEL"),
                new Carrera("MED", "Medicina", "DirMED") };

        static Materia[] materias = {
                new Materia("PRO4","Programacion IV",4),
                new Materia("PRO3","Programacion III",3),
                new Materia("EDD","Estructura de datos",3),
                new Materia("CMP1","Computación",1),
                new Materia("CIR3","Circuitos III",5),
                new Materia("PRO1b","Programacion I",8),
                new Materia("CIR4","Circuitos IV",6),
                new Materia("PRO2","Programacion II",2),
                new Materia("PRO1a","Programacion I",1),
                new Materia("CAL2","Calculo II",2)};

        static Est_Mat[] estMaterias = {
            new Est_Mat(123, "PRO3"),
            new Est_Mat(123, "PRO4"),
            new Est_Mat(123, "EDD"),
            new Est_Mat(123, "CAL2"),
            new Est_Mat(234, "PRO1a"),
            new Est_Mat(234, "PRO2"),
            new Est_Mat(345, "PRO1b"),
            new Est_Mat(345, "CIR4"),
            new Est_Mat(456, "EDD"),
            new Est_Mat(456, "PRO2"),
            new Est_Mat(567, "PRO1b"),
            new Est_Mat(678, "CIR3"),
            new Est_Mat(678, "PRO4"),
            new Est_Mat(789, "EDD"),
            new Est_Mat(789, "PRO1a"),
            new Est_Mat(789, "CAL2"),
            new Est_Mat(890, "CIR4"),
            new Est_Mat(890, "PRO3"),
            new Est_Mat(901, "CIR3"),
            new Est_Mat(012, "CMP1") };     

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Evaluación Unidad 2 - Bernardo Garcia");

            //ejercicio1("DirMED");
            //ejercicio2();
            //ejercicio3();
            //ejercicio4("Programacion I");

            Console.ReadKey();
        }

        static void ejercicio1(string director)
        {
            Console.WriteLine("1. Dado el nombre de un director de carrera, mostrar los nombres de estudiantes que estudian esa carrera.\n");

            var lstEstudiantesDirector = from d in carreras
                                         join e in estudiantes
                                         on d.CodCarrera equals e.CodCarrera
                                         where d.NomDirector == director
                                         select new { nomEstudiante = e.NomEst, nomCarrera = d.NomCarrera };

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Director: " + director);
            foreach (var item in lstEstudiantesDirector)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item.nomEstudiante + " - " + item.nomCarrera);
            }
        }

        static void ejercicio2()
        {
            Console.WriteLine("2. Mostrar los nombres de estudiantes por cada materia.\n");

            var lstEstMateria = from em in estMaterias
                                join e in estudiantes
                                on em.CI equals e.CI
                                join m in materias
                                on em.IdMateria equals m.CodMateria
                                orderby em.IdMateria
                                group e by m.NomMateria;

            foreach (var item in lstEstMateria)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Materia: " + item.Key);
                foreach (var e in item)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  " + e.CI + " - " + e.NomEst);
                }
            }

            //Es¿xisten dos grupos de Progamacion 1, en mi salida no estoy mostrando la diferencia de grupos, si no que lo junta en una sola materia.
        }

        static void ejercicio3()
        {
            Console.WriteLine("3. Mostrar el nombre de cada carrera junto a los nombres de sus respectivos estudiantes.\n");

            var lstEstCarreras = from c in carreras
                                join e in estudiantes
                                on c.CodCarrera equals e.CodCarrera
                                orderby c.NomCarrera
                                group e by c.NomCarrera;

            foreach (var item in lstEstCarreras)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Carreras: " + item.Key);
                foreach (var e in item)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  " + e.CI + " - " + e.NomEst);
                }
            }
        }

        static void ejercicio4(string materia)
        {
            Console.WriteLine("4. Dado el nombre de una materia mostrar los nombres de estudiantes inscritos en ella.\n");

            var lstMateria = from e in estudiantes
                                         join em in estMaterias
                                         on e.CI equals em.CI
                                         join m in materias
                                         on em.IdMateria equals m.CodMateria
                                         join c in carreras
                                         on e.CodCarrera equals c.CodCarrera
                                         where m.NomMateria == materia
                                         select new { ci = e.CI ,nomEstudiante = e.NomEst, nomCarrera = c.NomCarrera };

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Materia: " + materia);
            foreach (var item in lstMateria)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item.ci + " - " + item.nomEstudiante + " de la carrera " + item.nomCarrera);
            }
        }
    }
}
