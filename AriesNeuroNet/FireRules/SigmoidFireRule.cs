using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.InputOutput;

namespace AriesNeuroNet.FireRules
{
    public class SigmoidFireRule : FireRuleBase
    {
        public override double fireNeuron(List<NeuronPort> inputs, NeuronPort bias)
        {
            double sum = 0;

            
            foreach (NeuronPort input in inputs)
            {
                sum += 1 / (1 + Math.Exp(input.weightedReading * -1));
            }

            //sum += 1 / (1 + Math.Exp(bias.weightedReading *-1));
            return sum;
        }

        double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(x * -1));
        }

        public override double fireNeuronDerivative(List<NeuronPort> inputs, NeuronPort bias)
        {
            double sum = 0;


            foreach (NeuronPort input in inputs)
            {
                double s = Sigmoid(input.weightedReading);
                sum += (s * (1 -s));
            }

            //sum += 1 / (1 + Math.Exp(bias.weightedReading *-1));
            return sum;
        }

    }
}
