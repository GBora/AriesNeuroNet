using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.InputOutput;
using AriesNeuroNet.FireRules;

namespace AriesNeuroNet.Neuron
{
    public abstract class NeuronBase
    {
        // The random is for initializing the ranodw weights when needed
        private Random rand = new Random();

        // The input is only a list of ports
        public List<NeuronPort> inputs;
        public int maxWeight { get; set; }
        public int minWeight { get; set; }

        // The output is also a port
        public NeuronPort output;
 

        public string label { get; set; }
        public FireRuleBase fireRule { get; set; }

        // Start of methods

        public virtual void randomizeWeights()
        {
            foreach (NeuronPort input in this.inputs)
            {
                double tempWeight = this.minWeight + (rand.NextDouble() * (this.maxWeight - this.minWeight));
                input.weight = tempWeight;
            }
        }

        public virtual void fireNeuron()
        {
            throw new NotImplementedException();
        }

        public virtual void setInputValues(List<double> inputValues)
        {
            throw new NotImplementedException();
        }

        #region Functions for adding new inputs and output
        public void addNewInput(string label, double weight, double reading)
        {
            this.inputs.Add(new NeuronPort(weight, reading, label));
        }

        public void addNewInput(string label)
        {
            // need to search so that you can't add a neuron twice
            double tempWeight = this.minWeight + (rand.NextDouble() * (this.maxWeight - this.minWeight));
            this.inputs.Add(new NeuronPort(tempWeight, 0, label));
        }

        public void addnewOuput(string label, double weight, double reading)
        {
            this.output = new NeuronPort(weight, reading, label);
        }

        #endregion

        #region toString method
        public override string ToString()
        {
            string report = "";

            report += "Neuron: " + this.label + "\n";

            report += "Min weight allowed: " + this.minWeight + "\n";

            report += "Max weight allowed: " + this.maxWeight + "\n";

            report += "Inputs: \n";

            foreach (NeuronPort input in this.inputs)
            {
                report += input.ToString();
                report += "\n";
            }

            report += "Output: \n";
            report += this.output.ToString();
            report += "\n";

            report += this.fireRule.ToString();

            return report;
        }

        #endregion
    }
}
