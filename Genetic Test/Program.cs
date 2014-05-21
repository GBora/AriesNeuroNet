using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Neurons;
using AriesNeuroNet.InputOutput;
using AriesNeuroNet.Network;
using AriesNeuroNet.Training;
using AriesNeuroNet.FireRules;
using AForge.Genetic;
using AForge.Math.Random;

namespace Genetic_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleArrayChromosome weightValues = new DoubleArrayChromosome(new WeightRandomGenerator(),  new WeightRandomGenerator(), new WeightRandomGenerator(),6);
            //DoubleArrayChromosome weightValues = new DoubleArrayChromosome(AForge.Genetic.DoubleArrayChromosome.Generate(), new WeightRandomGenerator(), new WeightRandomGenerator(), 6);
            Population weightPop = new Population(40, weightValues, new AriesFF(), new EliteSelection());
            int counter = 0;
            while (counter < 100 )
            {
                weightPop.RunEpoch();
                counter++;
            }
            Console.ReadKey();
        }
    }
}
