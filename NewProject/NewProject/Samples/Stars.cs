using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GalaxyCatalog.Samples
{
    public class Stars : List
    {
    
        private string starName;
        private char starClass;
        private float starMass;
        private float starSize;
        private int starTemp;
        private float starLuminosity;
        public List<Planets> Planets;
        static int instances = 0;

      
        public Stars(string starName, float starMass, float starSize, int starTemp, float starLuminosity)
        {
            this.starName = starName;
            this.starMass = starMass;
            this.starSize = starSize;
            this.starTemp = starTemp;
            this.starLuminosity = starLuminosity;
            this.starClass = calcStarClass(starTemp, starLuminosity, starMass, (starSize / 2));

            this.Planets = new List<Planets>();

            instances++;
        }




        public string StarName
        {
            get { return this.starName; }
        }

        public char StarClass
        {
            get { return this.starClass; }
        }

        public int StarTemp
        {
            get { return this.starTemp; }
        }
        //methods
        private char calcStarClass(int starTemp, float starLuminosity, float starMass, float starSize)
        {   
            StarsType st = new StarsType();
            return st.getStarClass(starTemp, starLuminosity, starMass, starSize);
        }

        // add planet
        public void addPlanet(Planets p)
        {
            this.Planets.Add(p);

            //sorting after Add
            this.Planets = this.Planets.OrderBy(p => p.PlanetName).ToList();

        }

        public static int GetActiveInstances()
        {
            return instances;
        }
        int List.GetActiveInstances()
        {
            return Stars.GetActiveInstances();
        }

        public string GetInnerList(string view)
        {
            StringBuilder result = new StringBuilder();

            if (this.Planets.Count > 0)
            {
                switch (view)
                {
                    case "commas":
                        string strTmp = string.Empty;

                        foreach (Planets p in this.Planets)
                        {
                            strTmp += p.PlanetName + ", ";
                        }

                        result.Append($"{ strTmp } ");
                        break;

                    case "full":
                        foreach (Planets p in this.Planets)
                        {
                            result.Append($"\n{p.ToString() } \n");
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
            result.Append($"   - Name: {this.starName} \n");
            result.Append($"    - Class: {this.starClass} ({this.starMass}, {this.starSize}, {this.starTemp}, {this.starLuminosity}) \n");
            result.Append($"    - Planets: ");
            result.Append($"{ this.GetInnerList("full") }");

            return result.ToString();

        }


    }
}
