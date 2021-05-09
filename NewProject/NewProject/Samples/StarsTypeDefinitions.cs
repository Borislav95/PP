using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyCatalog.Samples
{
    public class StarsTypeDefinitions
    {

        int kMin, kMax;

        float mMin, mMax;

        float lMin, lMax;

        float rMin, rMax;

        char typeName;


        public StarsTypeDefinitions(char typeName,
            int kMin,
            int kMax,
            float lMin,
            float lMax,
            float mMin,
            float mMax,
            float rMin,
            float rMax)
        {
            this.typeName = typeName;

            this.kMin = kMin;

            this.kMax = kMax;

            this.mMin = mMin;

            this.mMax = mMax;

            this.lMin = lMin;

            this.lMax = lMax;

            this.rMin = rMin;

            this.rMax = rMax;
        }

        public char TypeName
        {
            get { return this.typeName; }
        }
        public int KMin
        {
            get { return this.kMin; }
        }
        public int KMax
        {
            get { return this.kMax; }
        }
        public float MMin
        {
            get { return this.mMin; }
        }
        public float MMax
        {
            get { return this.mMax; }
        }
        public float LMin
        {
            get { return this.lMin; }
        }

        public float LMax
        {
            get { return this.lMax; }
        }
        public float RMin
        {
            get { return this.rMin; }
        }
        public float RMax
        {
            get { return this.rMax; }
        }
    }

}
