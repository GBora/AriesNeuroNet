using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriesNeuroNet.Training
{
    public class TrainingRow
    {
        public List<double> inputs { get; set; }
        public List<double> outputs { get; set; }

        public TrainingRow(List<double> inputs, List<double> outputs)
        {
            this.inputs = inputs;
            this.outputs = outputs;
        }
    }
}
