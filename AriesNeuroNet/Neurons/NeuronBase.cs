using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.InputOutput;
using AriesNeuroNet.FireRules;

namespace AriesNeuroNet.Neurons
{
    public abstract class NeuronBase
    {
        // The random is for initializing the random weights when needed
        private Random rand = new Random();

        // The input is only a list of ports
        public List<NeuronPort> inputs;
        public double maxWeight { get; set; }
        public double minWeight { get; set; }

        // The output is also a port
        public NeuronPort output;

        // The bias is also a port
        public NeuronPort bias;

        //The nodeDelta for backtracking
        public double nodeDelta;

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
            for (int i = 0; i < this.inputs.Count; i++)
            {
                if (i < inputValues.Count && inputValues[i] != null)
                {
                    this.inputs[i].reading = inputValues[i];
                }
                else
                {
                    // Checks if input has a reading and if not sets it at 0 
                    if (this.inputs[i].reading == null)
                    {
                        this.inputs[i].reading = 0;
                    }
                }
            }
        }

        public virtual double getWeightedReading()
        {
            double sum = 0;

            for (int i = 0; i < this.inputs.Count; i++)
            {
                sum += this.inputs[i].weightedReading;
            }

            sum += this.bias.weightedReading;

                return sum;
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
