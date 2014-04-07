using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AriesNeuroNet.Neurons;
using AriesNeuroNet.InputOutput;
using AriesNeuroNet.Network;
using AriesNeuroNet.Training;

namespace GUI_Test
{
    public partial class Form1 : Form
    {
        public Neuron neuron;
        public List<TrainingTemplate> templatesList;
        public TrainingTemplate chosenTemplate = null;

        public Form1()
        {
            InitializeComponent();

            
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            neuron = new Neuron("AND-Neuron", 0, 2);
            neuron.addNewInput("input1", 0, 0);
            neuron.addNewInput("input2", 0, 0);
            PerceptronNetwork pn = new PerceptronNetwork(neuron);

            TrainingTemplate andTemplate = new TrainingTemplate("AND Template");
            andTemplate.addTrainingRow(new TrainingRow(new List<double> { 0, 0 }, new List<double> { 0 }));
            andTemplate.addTrainingRow(new TrainingRow(new List<double> { 0, 1 }, new List<double> { 0 }));
            andTemplate.addTrainingRow(new TrainingRow(new List<double> { 1, 0 }, new List<double> { 0 }));
            andTemplate.addTrainingRow(new TrainingRow(new List<double> { 1, 1 }, new List<double> { 1 }));

            TrainingTemplate orTemplate = new TrainingTemplate("OR Template");
            orTemplate.addTrainingRow(new TrainingRow(new List<double> { 0, 0 }, new List<double> { 0 }));
            orTemplate.addTrainingRow(new TrainingRow(new List<double> { 0, 1 }, new List<double> { 1 }));
            orTemplate.addTrainingRow(new TrainingRow(new List<double> { 1, 0 }, new List<double> { 1 }));
            orTemplate.addTrainingRow(new TrainingRow(new List<double> { 1, 1 }, new List<double> { 1 }));

            TrainingTemplate xorTemplate = new TrainingTemplate("XOR Template");
            xorTemplate.addTrainingRow(new TrainingRow(new List<double> { 0, 0 }, new List<double> { 0 }));
            xorTemplate.addTrainingRow(new TrainingRow(new List<double> { 0, 1 }, new List<double> { 1 }));
            xorTemplate.addTrainingRow(new TrainingRow(new List<double> { 1, 0 }, new List<double> { 1 }));
            xorTemplate.addTrainingRow(new TrainingRow(new List<double> { 1, 1 }, new List<double> { 0 }));


            templatesList = new List<TrainingTemplate>();

            ErrorHistory errorProg = new ErrorHistory();

            double error = pn.train(xorTemplate, 100, errorProg);

            labelWeight1.Text = neuron.inputs[0].weight.ToString("N3");

            labelWeight2.Text = neuron.inputs[1].weight.ToString("N3");

            labelError.Text = error.ToString("N3");



            for (int X = 0; X < errorProg.errorPoints.Count; X++)
            {
                chart1.Series["Error"].Points.AddXY(X, errorProg.errorPoints[X]);
            }

            //chart1.DataBind(errorProg);
        }




    }
}
