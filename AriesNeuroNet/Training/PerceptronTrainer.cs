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
        public double learningRate = 0.3;

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
            bool stableGenFlag = true;
            bool genLimitFlag = true;
            bool templateFlag = false;

            double error = 0;

            do
            {
                //Main loop

                Console.WriteLine("========================================================================");
                Console.WriteLine("Begining Generation: " + currentGeneration);

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

                Console.WriteLine("Output is " + realOutput);

                //Calculate the error
                error = expectedOutput - realOutput;

                Console.WriteLine("Error is " + error);

                //Process the error

                if (error == 0)
                {
                    Console.WriteLine("I have not found an error");
                    stableGenerations++;
                    // I move on to the next training row
                    currentRow = (currentRow + 1) % trainingTemplate.rows.Count;
                    //Maybe I'm not so sure of this
                    adjustedWeights = false;
                }
                else
                {
                    stableGenerations = 0;
                    Console.WriteLine("I found an error");
                    Console.WriteLine("The error is " + error);
                    // Publish the old weights
                    List<double> oldWeights = new List<double>();
                    List<double> newWeights = new List<double>();

                    // I mark that I needed to adjust the weights.
                    adjustedWeights = true;
                    //Do the heavy duty processing
                    foreach (NeuronPort input in neuron.inputs)
                    {
                        oldWeights.Add(input.weight);
                        input.weight += input.reading * learningRate * error; // To do finish this
                        newWeights.Add(input.weight);
                    }
                    Console.WriteLine("I corrected with " + (learningRate * error));
                    Console.WriteLine("Old weights ");
                    foreach (double weight in oldWeights) {
                        Console.Write(weight + " ");                    
                    }
                    Console.WriteLine("New weights " + newWeights);
                    foreach (double weight in newWeights)
                    {
                        Console.Write(weight + " ");
                    }
                }

                //This constantly jumps throw the templates maybe not the best choice

                // Need to split this up into 2 loops one loops over the rows in the template 
                // One loops in the rows correcting the errors
                // Or see wiki article
                
                currentGeneration++;

                //I check the conditions
                stableGenFlag = stableGenerations < stableLimit;
                genLimitFlag = currentGeneration < maxGenerations;
                templateFlag = currentRow < trainingTemplate.rows.Count;

                Console.WriteLine("adjustedWeights "+ adjustedWeights +" templateFlag " + templateFlag + " stableGenFlag " + stableGenFlag + " genLimitFlag " + genLimitFlag);


                Console.WriteLine("End of Generation: " + (currentGeneration-1));
                Console.WriteLine("========================================================================");
                Console.ReadKey();


            } while (adjustedWeights /*&& stableGenFlag*/ && genLimitFlag && templateFlag);

            return error;
        }

    }
}
