﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Neurons;
using AriesNeuroNet.InputOutput;
using AriesNeuroNet.FireRules;

namespace AriesNeuroNet.Neurons
{
    public class Neuron : NeuronBase
    {
        #region Constructors
        public Neuron(string label, int minWeight, int maxWeight)
        {
            this.minWeight = minWeight;
            this.maxWeight = maxWeight;
            this.label = label;
            this.fireRule = new SumFireRule(0);
            this.inputs = new List<NeuronPort>();
            this.output = new NeuronPort(1,0,(this.label + "-Output"));
            this.bias = new NeuronPort(1, 0, (this.label + "-Bias"));
        }
        #endregion

        public override void fireNeuron()
        {
            this.output.reading = this.fireRule.fireNeuron(this.inputs, this.bias);
        }
    }
}
