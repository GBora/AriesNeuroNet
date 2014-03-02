using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.InputOutput;

namespace AriesNeuroNet.FireRules
{
    public abstract class FireRuleBase
    {
        public virtual double fireNeuron(List<NeuronPort> neuronInputs)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Base Fire Rule";
        }
    }
}
