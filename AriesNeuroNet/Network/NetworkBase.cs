using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Training;

namespace AriesNeuroNet.Network
{
    public abstract class NetworkBase
    {
        public string label { get; set; }

        public TrainerBase trainingMethod { get; set; }
    }
}
