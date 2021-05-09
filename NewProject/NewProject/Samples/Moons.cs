using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyCatalog.Samples
{
    public class Moons : List
    {
       
        private string moonName;
        static int instances = 0;

     
        public Moons(string moonName)
        {
            this.moonName = moonName;

            instances++;
        }

    
        public string MoonName
        {
            get { return this.moonName; }
        }

   
        public static int GetActiveInstances()
        {
            return instances;
        }
        int List.GetActiveInstances()
        {
            return Moons.GetActiveInstances();
        }

        public string GetInnerList(string view)
        {
            return "";
        }


        public override string ToString()
        {
            return this.moonName;
        }

    }
}
