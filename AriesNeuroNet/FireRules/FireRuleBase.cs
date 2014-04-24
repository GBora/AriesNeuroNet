using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.InputOutput;

namespace AriesNeuroNet.FireRules
{
    public abstract class FireRuleBase
    {
        public double threshold { get; set; }

        public virtual double fireNeuron(List<NeuronPort> neuronInputs, NeuronPort bias)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Base Fire Rule";
        }

        public virtual double fireNeuronDerivative(List<NeuronPort> inputs, NeuronPort bias)
        {
            throw new NotImplementedException();
        }
    }
}
