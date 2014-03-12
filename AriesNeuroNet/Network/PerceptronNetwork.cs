using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Neurons;
using AriesNeuroNet.Training;

namespace AriesNeuroNet.Network
{
    public class PerceptronNetwork : NetworkBase
    {
        Neuron perceptron { get; set; }

        public PerceptronTrainer trainingMethod;


        public PerceptronNetwork(Neuron aNeuron)
        {
            this.perceptron = aNeuron;
        }

        public double train(TrainingTemplate trainingTemplate, int extmaxGenerations)
        {
            //This is simple but the ideea is suposed to be that in larger networks here I do a foreach over the neurons
            double error =  this.trainingMethod.trainNetwork(trainingTemplate, this.perceptron, extmaxGenerations);
            return error;
        }
    }
}
