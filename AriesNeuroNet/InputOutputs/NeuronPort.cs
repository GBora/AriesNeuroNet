using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriesNeuroNet.InputOutput
{
    public class NeuronPort
    {
        public double reading { get; set; }

        public double weight { get; set; }

        public string label { get; set; }

        public double weightedReading { get { return this.reading * this.weight; } }

        public bool isInhibitor()
        {
            return this.weight < 0;
        }

        public bool isFired()
        {
            return (this.reading > 0);
        }

        public NeuronPort(double weight, double reading, string label)
        {
            this.label = label;
            this.weight = weight;
            this.reading = reading;
        }

        public NeuronPort(double weight, double reading)
            : this(weight, reading, "default")
        {

        }

        public NeuronPort(double weight)
            : this(weight, 0, "default")
        {

        }

        public NeuronPort()
            : this(1, 0, "default")
        {

        }

        public override string ToString()
        {
            return "Port: " + label + " weight: " + weight + " reading: " + reading + " weighted reading " + weightedReading;
        }

    }
}
