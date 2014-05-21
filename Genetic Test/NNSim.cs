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
    class NNSim
    {
        TrainingTemplate xor_template;

        Neuron input1Neuron;
        Neuron input2Neuron;
        Neuron hidden1Neuron;
        Neuron hidden2Neuron;
        Neuron outputNeuron;

        /// <summary>
        /// The constructor
        /// </summary>
        NNSim()
        {
            TrainingTemplate xor_template = new TrainingTemplate();
            xor_template.addTrainingRow(new TrainingRow(new List<double> { 0, 0 }, new List<double> { 0 }));
            xor_template.addTrainingRow(new TrainingRow(new List<double> { 0, 1 }, new List<double> { 1 }));
            xor_template.addTrainingRow(new TrainingRow(new List<double> { 1, 0 }, new List<double> { 1 }));
            xor_template.addTrainingRow(new TrainingRow(new List<double> { 1, 1 }, new List<double> { 0 }));

            Neuron input1Neuron = new Neuron("input1", 0, 1);
            Neuron input2Neuron = new Neuron("input2", 0, 1);

            Neuron hidden1Neuron = new Neuron("hidden1", 0, 1);
            Neuron hidden2Neuron = new Neuron("hidden2", 0, 1);

            Neuron outputNeuron = new Neuron("output", 0, 1);

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
        }


        public double getError(double[] weights)
        {
            return 0;
        }
    }
}
