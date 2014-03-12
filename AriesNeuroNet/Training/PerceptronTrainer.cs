using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Neurons;
using AriesNeuroNet.InputOutput;

namespace AriesNeuroNet.Training
{
    public class PerceptronTrainer : TrainerBase
    {
        public double learningRate = 0.1;

        public double trainNetwork(TrainingTemplate trainingTemplate, AriesNeuroNet.Neurons.Neuron neuron, int maxGenerations)
        {
            int stableLimit = trainingTemplate.rows.Count;
            int stableGenerations = 0;
            int currentGeneration = 0;

            int currentRow = 0;

            //Step 1 initialize the neurons to randomize weights
            neuron.randomizeWeights();

            //We take into account that we might not need to adjust the weights
            bool adjustedWeights = false;

            double error = 0;

            do
            {
                //Main loop

                //We assume this time arround we don't need to adjust
                adjustedWeights = false;

                //TODO add some printfs

                //Set the imputs
                // I need to cycle through the various templates
                List<double> inputs = trainingTemplate.rows[currentRow].inputs;
                neuron.setInputValues(inputs);

                //Fire the neuron
                neuron.fireNeuron();

                //Get the expected output from the template this works only for training a perceptron
                double expectedOutput = trainingTemplate.rows[currentRow].outputs[0];

                //Get the real output
                double realOutput = neuron.output.weightedReading;

                //Calculate the error
                error = expectedOutput - realOutput;

                //Process the error

                if (error == 0)
                {
                    stableGenerations++;
                    // I move on to the next training row
                    currentRow = (currentRow + 1) % trainingTemplate.rows.Count;
                }
                else
                {
                    stableGenerations = 0;
                    // I mark that I needed to adjust the weights.
                    adjustedWeights = true;
                    //Do the heavy duty processing
                    foreach (NeuronPort input in neuron.inputs)
                    {
                        input.weight += input.reading * learningRate * error; // To do finish this
                    }
                }

                //This constantly jumps throw the templates maybe not the best choice

                // Need to split this up into 2 loops one loops over the rows in the template 
                // One loops in the rows correcting the errors
                // Or see wiki article
                
                currentGeneration++;

            } while (adjustedWeights && (stableGenerations < stableLimit) && (currentGeneration < maxGenerations) && (currentRow < trainingTemplate.rows.Count));

            return error;
        }

    }
}
