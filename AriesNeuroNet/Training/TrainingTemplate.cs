using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriesNeuroNet.Training
{
    public class TrainingTemplate
    {
        public List<TrainingRow> rows { get; set; }
        public string label;

        public TrainingTemplate()
            : this("Anonymous training template", new List<TrainingRow>())
        {

        }


        public TrainingTemplate(string label)
            : this(label, new List<TrainingRow>())
        {

        }

        public TrainingTemplate(string label, List<TrainingRow> rows)
        {
            this.label = label;
            this.rows = rows;
        }

        public void addTrainingRow(TrainingRow tr)
        {
            this.rows.Add(tr);
        }
    }
}
