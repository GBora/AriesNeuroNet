using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Neurons;

namespace AriesNeuroNet.Network
{
    public class Layer
    {
        public List<Neuron> neurons;

        /// <summary>
        /// The constructor for a layer
        /// </summary>
        /// <param name="neurons">A list of neurons which will fillout the layer</param>
        public Layer(List<Neuron> neurons)
        {
            this.neurons = neurons;
        }
        /// <summary>
        /// A constructor which generates a empty list of neurons for the layer
        /// </summary>
        public Layer()
            : this(new List<Neuron>())
        {

        }
    }


}
