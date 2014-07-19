using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Neurons;
using AriesNeuroNet.InputOutput;
using AriesNeuroNet.Network;
using AriesNeuroNet.Training;
using AriesNeuroNet.FireRules;

namespace Genetic_Test
{
    public class NNSim
    {
        TrainingTemplate xor_template;

        Neuron input1Neuron;
        Neuron input2Neuron;
        Neuron hidden1Neuron;
        Neuron hidden2Neuron;
        Neuron outputNeuron;

        double[] errors;

        /// <summary>
        /// The constructor
        /// </summary>
        public NNSim()
        {
            this.xor_template = new TrainingTemplate();
            xor_template.addTrainingRow(new TrainingRow(new List<double> { 0, 0 }, new List<double> { 0 }));
            xor_template.addTrainingRow(new TrainingRow(new List<double> { 0, 1 }, new List<double> { 1 }));
            xor_template.addTrainingRow(new TrainingRow(new List<double> { 1, 0 }, new List<double> { 1 }));
            xor_template.addTrainingRow(new TrainingRow(new List<double> { 1, 1 }, new List<double> { 0 }));

            this.input1Neuron = new Neuron("input1", 0, 1);
            this.input2Neuron = new Neuron("input2", 0, 1);

            this.hidden1Neuron = new Neuron("hidden1", 0, 1);
            this.hidden2Neuron = new Neuron("hidden2", 0, 1);

            this.outputNeuron = new Neuron("output", 0, 1);

            input1Neuron.fireRule = new SigmoidFireRule();
            input2Neuron.fireRule = new SigmoidFireRule();

            hidden1Neuron.fireRule = new SigmoidFireRule();
            hidden1Neuron.fireRule = new SigmoidFireRule();

            outputNeuron.fireRule = new SigmoidFireRule();

            input1Neuron.addNewInput("network_in_1", 1, 1);
            input2Neuron.addNewInput("network_in_2", 1, 1);

            hidden1Neuron.inputs.Add(input1Neuron.output);
            hidden1Neuron.inputs.Add(input2Neuron.output);

            hidden2Neuron.inputs.Add(input1Neuron.output);
            hidden2Neuron.inputs.Add(input2Neuron.output);

            outputNeuron.inputs.Add(hidden1Neuron.output);
            outputNeuron.inputs.Add(hidden2Neuron.output);

            errors = new double[4];
        }


        public double getError(double[] weights)
        {
            //set the weights

            hidden1Neuron.inputs[0].weight = weights[0];
            hidden1Neuron.inputs[1].weight = weights[1];

            hidden2Neuron.inputs[0].weight = weights[2];
            hidden2Neuron.inputs[1].weight = weights[3];

            outputNeuron.inputs[0].weight = weights[4];
            outputNeuron.inputs[1].weight = weights[5];

            for (int i = 0; i < xor_template.rows.Count; i++)
            {
                TrainingRow row = xor_template.rows[i];

                input1Neuron.inputs[0].reading = row.inputs[0];
                input2Neuron.inputs[0].reading = row.inputs[1];


                input1Neuron.fireNeuron();
                input2Neuron.fireNeuron();
                hidden1Neuron.fireNeuron();
                hidden2Neuron.fireNeuron();
                outputNeuron.fireNeuron();

                errors[i] = row.outputs[0] - outputNeuron.output.weightedReading;
            }

            double sumError = 0;
            for (int i = 0; i < errors.Length; i++)
            {
                if (errors[i] > 0)
                {
                    sumError += errors[i];
                }
                else
                {
                    sumError += errors[i] * -1;
                }
                
            }
                return sumError;
        }
    }
}
