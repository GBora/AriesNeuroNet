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
    public class Program
    {
        static void Main(string[] args)
        {
            

            DoubleArrayChromosome weightValues = new DoubleArrayChromosome(new WeightRandomGenerator(),  new WeightRandomGenerator(), new WeightRandomGenerator(),6);
            Population weightPop = new Population(40, weightValues, new AriesFF(), new EliteSelection());
            int counter = 0;
            bool stopEvo = false;
            AriesFF fintessEval = new AriesFF();
            double error = 0;
            while (!stopEvo)
            {
                weightPop.RunEpoch();
                counter++;
                IChromosome best = weightPop.BestChromosome;
                error = fintessEval.Evaluate(best);
                stopEvo = counter > 1000 || error < 0.12;
            }
            Console.WriteLine("Stopped after " + counter.ToString());
            DoubleArrayChromosome solution = (DoubleArrayChromosome)weightPop.BestChromosome;
            Console.WriteLine(solution.ToString());
            Console.ReadKey();
        }
    }
}
