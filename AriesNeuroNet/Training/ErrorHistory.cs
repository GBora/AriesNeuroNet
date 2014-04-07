using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriesNeuroNet.Training
{
    public class ErrorHistory
    {
        public List<double> errorPoints;

        public ErrorHistory()
        {
            this.errorPoints = new List<double>();
        }

        public override string ToString()
        {
            string result = "This is the error history: \n";

            foreach (double error in this.errorPoints)
            {
                result += error.ToString() + "\n";
            }

            return result;
        }
    }
}
