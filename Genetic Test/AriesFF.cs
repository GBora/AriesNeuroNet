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

namespace Genetic_Test
{
    public class AriesFF : IFitnessFunction
    {
        NNSim xorSim = new NNSim();

        public double Evaluate(IChromosome chromosome)
        {
            DoubleArrayChromosome doubleChromosome = (DoubleArrayChromosome)chromosome;

            string[] s_genes = doubleChromosome.ToString().Split();
            double[] d_genes = new double[s_genes.Length];
            double sum = 0;

            for (int i = 0; i < d_genes.Length; i++)
            {
                d_genes[i] = Double.Parse(s_genes[i]);
                
            }

            double error = xorSim.getError(d_genes);
            if (error == 0)
            {
                return 0;
            }
            else
            {
                return 1 / xorSim.getError(d_genes);
            }

        }
    }
}
