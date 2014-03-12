using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Neurons;
using AriesNeuroNet.InputOutput;
using AriesNeuroNet.Network;
using AriesNeuroNet.Training;

namespace NetworkTest
{
    class NetworkTest
    {
        static void Main(string[] args)
        {
            Neuron neuron = new Neuron("AND-Neuron",0,10);   
            neuron.addNewInput("input1",0, 0 );
            neuron.addNewInput("input2", 0, 0);
            PerceptronNetwork pn = new PerceptronNetwork(neuron);

            TrainingTemplate andTemplate = new TrainingTemplate("AND Template");
            andTemplate.addTrainingRow(new TrainingRow(new List<double> { 0, 0 }, new List<double> { 0 }));
            andTemplate.addTrainingRow(new TrainingRow(new List<double> { 0, 1 }, new List<double> { 0 }));
            andTemplate.addTrainingRow(new TrainingRow(new List<double> { 1, 0 }, new List<double> { 0 }));
            andTemplate.addTrainingRow(new TrainingRow(new List<double> { 1, 1 }, new List<double> { 0 }));

            Console.WriteLine("After 100 generations error is " + pn.train(andTemplate, 1000));

        }
    }
}
