using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.InputOutput;

namespace AriesNeuroNet.FireRules
{
    class SinglePoleFR : FireRuleBase
    {
        public double threshold { get; set; }
        public double offset { get; set; }

        //Start of Methods

        public override double fireNeuron(List<NeuronPort> inputs, NeuronPort bias)
        {
            double sum = 0;

            foreach (NeuronPort input in inputs)
            {
                sum += input.weightedReading;
            }

            sum += offset;

            if (sum > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #region constructor

        public SinglePoleFR(double offset, double threshold)
        {
            this.offset = offset;
            this.threshold = threshold;
        }

        #endregion



        public override string ToString()
        {
            return "Single Pole Firing Rule Offset: " + this.offset + " Threshold(Internal) : " + this.threshold;
        }
    }
}
