using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Genetic;
using AForge.Math.Random;

namespace Genetic_Test
{
    class WeightRandomGenerator : IRandomNumberGenerator
    {
        int seed;
        float mean;
        float variance;

        Random rand = new Random();

        public float Mean
        {
            get { throw new NotImplementedException(); }
        }

        public float Next()
        {
            return (float)rand.NextDouble();
        }

        public void SetSeed(int seed)
        {
            this.seed = seed;
            rand = new Random(this.seed);
        }

        public float Variance
        {
            get { throw new NotImplementedException(); }
        }
    }
}
