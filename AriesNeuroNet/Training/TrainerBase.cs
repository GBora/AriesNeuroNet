using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Neurons;

namespace AriesNeuroNet.Training
{
    public abstract class TrainerBase
    {
        public double learningRate;

        public virtual double TrainNetwork(TrainingTemplate trainingTemplate, NeuronBase neuron, int maxGenerations)
        {
            throw new NotImplementedException();
        }
    }
}
