using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GalaxyCatalog.Samples
{

    public class Planets : List
    {
     
        private string planetName;
        private string planetType;
        private bool life;
        List<Moons> Moons;
        static int instances = 0;


        public Planets(string planetName, string planetType, bool life)
        {

            if (PlanetTypeCheck(planetType) != "none")
            {
                this.planetName = planetName;
                this.planetType = PlanetTypeCheck(planetType);
                this.life = life;

                this.Moons = new List<Moons>();

                instances++;
            }
            else
            {
                Console.WriteLine("Input Error! Planet not Found!");
            }
        }

   
        public string PlanetName { get { return this.planetName; } }


        private string PlanetTypeCheck(string pt)
        {

            string[] planetTypesList = { "terrestrial", 
                                         "giant planet",
                                         "ice giant",
                                         "mesoplanet", 
                                         "mini-neptune", 
                                         "planetar", 
                                         "super-earth", 
                                         "super-jupiter",
                                         "sub-earth" };

            if (Array.Exists(planetTypesList, ele => ele == pt))
            {
                return pt;
            }
            else
            {
                Console.WriteLine($" Planet type value does not meet the requirements! \n" +
                    $" Please re-enter by specifying one of the following: " + String.Join(",", planetTypesList));
                return "none";
            }
        }



        public void addMoon(Moons m)
        {
            this.Moons.Add(m);

        }

        public static int GetActiveInstances()
        {
            return instances;
        }

        int List.GetActiveInstances()
        {
            return Planets.GetActiveInstances();
        }


        public string GetInnerList(string view)
        {
            StringBuilder result = new StringBuilder();

            if (this.Moons.Count > 0)
            {
                switch (view)
                {
                    case "commas":

                        result.Append($"{ String.Join(", ", this.Moons) }");

                        break;

                    case "full":
                        foreach (Moons m in this.Moons)
                        {
                            result.Append($"\n           \u25a0 {m.ToString() }");
                        }
                        break;
                }
            }
            else
            {
                if (view == "full") { result.Append("none"); }
            }

            return result.ToString();
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"      \u25cb Name: {planetName} \n");

            result.Append($"        Type: {planetType} \n");

            result.Append($"        Support life: {(life ? "yes" : "no")} \n");

            result.Append($"        Moons: ");

            result.Append($"{ this.GetInnerList("full") }");

            return result.ToString();
        }


    } 
}
