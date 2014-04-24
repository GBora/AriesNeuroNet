using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.InputOutput;

namespace AriesNeuroNet.FireRules
{
    public class SumFireRule : FireRuleBase
    {

        public double threshold { get; set; }
        


        public override double fireNeuron(List<NeuronPort> inputs, NeuronPort bias)
        {
            double sum = 0;

            foreach (NeuronPort input in inputs)
            {
                sum += input.weightedReading;
            }

            sum += bias.weightedReading;

            return sum;
        }


                #region constructor

        public SumFireRule(double threshold)
        {

            this.threshold = threshold;
        }

        #endregion

        public override string ToString()
        {
            return "Sum Firing Rule Bias (comes from the neuron) " + " Threshold(Internal) : " + this.threshold;
        }
    }
}
