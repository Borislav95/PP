using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GalaxyCatalog.Samples
{
    public class GalaxyLog
    {
        public List<Galaxy> Galaxies;

        public GalaxyLog()
        {
            this.Galaxies = new List<Galaxy>();
        }

        public void printGalaxies()
        {
            Console.WriteLine("-----------List of all researched galaxies-----------");
            foreach (Galaxy GL in this.Galaxies)
            {
                Console.WriteLine($"{GL.GalaxyName} ");
            }
            Console.WriteLine("-----------End of galaxies list-----------\n");

        }

        public void printStars()
        {
            string str;

            Console.WriteLine("-----------List of all researched Stars-----------");
            foreach (Galaxy GL in this.Galaxies)
            {
                str = GL.GetInnerList("commas");

                if (!string.IsNullOrEmpty(str))
                {
                    Console.Write(str);
                }

            }
            Console.WriteLine("");
            Console.WriteLine("-----------End of stars list-----------\n");

        }

        public void printPlanets()
        {
            string str;

            Console.WriteLine("--- List of all researched Planets ---");
            foreach (Galaxy GL in this.Galaxies)
            {
                foreach (Stars s in GL.Stars)
                {
                    str = s.GetInnerList("commas");

                    if (!string.IsNullOrEmpty(str))
                    {
                        Console.Write(str);
                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine("-----------End of Planets list-----------\n");

        }

        public void printMoons()
        {
            string str = string.Empty;

            Console.WriteLine("-----------List of all researched Moons-----------");
            foreach (Galaxy GL in this.Galaxies)
            {
                foreach (Stars s in GL.Stars)
                {
                    foreach (Planets p in s.Planets)
                    {
                        str = p.GetInnerList("commas");

                        if (!string.IsNullOrEmpty(str))
                        {
                            Console.Write(str + ", ");
                        }

                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine("-----------End of Moons list-----------\n");

        }



        public void printStat()
        {
            Console.WriteLine("-----------Stats-----------");

            Console.WriteLine($"Galaxies: {Galaxy.GetActiveInstances() }");

            Console.WriteLine($"Stars: {Stars.GetActiveInstances() }");

            Console.WriteLine($"Planets: {Planets.GetActiveInstances() }");

            Console.WriteLine($"Moons: {Moons.GetActiveInstances() }");

            Console.WriteLine("-----------End of stats-----------\n");


        }

    }
}
