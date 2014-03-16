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
        public double offset { get; set; }


        public override double fireNeuron(List<NeuronPort> inputs)
        {
            double sum = 0;

            foreach (NeuronPort input in inputs)
            {
                sum += input.weightedReading;
            }

            sum += offset;

            return sum;
        }


                #region constructor

        public SumFireRule(double offset, double threshold)
        {
            this.offset = offset;
            this.threshold = threshold;
        }

        #endregion

        public override string ToString()
        {
            return "Sum Firing Rule Offset: " + this.offset + " Threshold(Internal) : " + this.threshold;
        }
    }
}
