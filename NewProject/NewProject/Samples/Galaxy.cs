using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GalaxyCatalog.Samples
{
    public enum GalaxyTypes
    { elliptical, lenticular, spiral, irregular }

    public class Galaxy : List
    {
        
        private string galaxyName;

        private GalaxyTypes type;

        private float age;

        private char ageSize; 

        static int instances = 0;

        public List<Stars> Stars;

       
        public Galaxy(string galaxyName, List<Stars> s)
        {
            this.galaxyName = galaxyName;
            this.Stars = s;

            instances++;
        }

        public Galaxy(string galaxyName, GalaxyTypes type, float age, char ageSize)
        {
            this.galaxyName = galaxyName;
            this.type = type;
            this.age = age;
            this.ageSize = ageSize;

            this.Stars = new List<Stars>();

            instances++;
        }


       
        public string GalaxyName
        {
            get { return this.galaxyName; }
        }

        public void addStar(Stars s)
        {
            this.Stars.Add(s);

            this.Stars = this.Stars.OrderBy(x => x.StarTemp).ToList();
        }

        public static int GetActiveInstances()
        {
            return instances;
        }

        int List.GetActiveInstances()
        {
            return Galaxy.GetActiveInstances();
        }


        public void printCounts()
        {
            Console.WriteLine($"All Galaxies: {instances}");
        }


        public string GetInnerList(string view)
        {
            StringBuilder result = new StringBuilder();

            if (this.Stars.Count > 0)
            {
                switch (view)
                {
                    case "commas":
                        string strTmp = string.Empty;

                        foreach (Stars s in this.Stars)
                        {
                            strTmp += s.StarName + ", ";
                        }
                        result.Append($"{ strTmp } ");
                        break;

                    case "full":
                        result.Append("\n");
                        foreach (Stars s in this.Stars)
                        {
                            result.Append($"{s.ToString()} ");
                            result.Append("\n");
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
            result.Append($"--- Data for {this.galaxyName} galaxy --- \n");
            result.Append($"Type: {this.type} \n");
            result.Append($"Age: {this.age}{this.ageSize} \n");
            result.Append($"Stars: ");
            result.Append($"{ this.GetInnerList("full") } \n");
            result.Append($"\n--- End of data for {this.galaxyName} galaxy ---\n");

            return result.ToString();
        }

    }
}
