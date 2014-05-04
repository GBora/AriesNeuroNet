using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Training;

namespace AriesNeuroNet.Network
{
    public class SimpleNetwork: NetworkBase
    {
        public Layer inputLayer;
        public Layer hiddenLayer;
        public Layer outputLayer;

        public NetworkTrainer trainer = new NetworkTrainer();

        public double train(TrainingTemplate trainingTemplate, int extMaxGenerations, ErrorHistory errorProg)
        {
            return 0;
        }
    }
}
