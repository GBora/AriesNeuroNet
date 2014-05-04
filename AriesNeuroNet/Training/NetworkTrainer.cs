using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriesNeuroNet.Network;
using AriesNeuroNet.Neurons;
using AriesNeuroNet.InputOutput;

namespace AriesNeuroNet.Training
{
    public class NetworkTrainer: TrainerBase
    {
        public double learningRate = 0.7;
        public double moementum = 0.3;
        /// <summary>
        /// trains the netwrok though back propagation
        /// </summary>
        /// <param name="trainingTemplate"></param>
        /// <param name="inputLayer">the input layer of the network</param>
        /// <param name="outputLayer">the output layer of the network</param>
        /// <param name="hiddenLayer">the hidden layer of the network</param>
        /// <param name="maxGenerations"></param>
        /// <param name="errorProg"></param>
        /// <returns></returns>
        public double trainNetwork(TrainingTemplate trainingTemplate, Layer inputLayer, Layer outputLayer, Layer hiddenLayer, int maxGenerations, double acceptableError, ErrorHistory errorProg)
        {
            // Step 0 innitialize
            int stableLimit = trainingTemplate.rows.Count;
            int stableGenerations = 0;
            int currentGeneration = 0;

            double error = 0;
            
            List<double> errorHistory = new List<double>();

            bool adjustedWeights = false;
            bool stableGenFlag = true;
            bool genLimitFlag = true;
            bool templateFlag = false;

            foreach (Neuron neuron in inputLayer.neurons)
            {
                neuron.randomizeWeights();

            }

            foreach (Neuron neuron in hiddenLayer.neurons)
            {
                neuron.randomizeWeights();
            }

            //Should I set the output neuron's weights to 1 ?


            for (int currentRow = 0; currentRow < trainingTemplate.rows.Count; currentRow++)
            {
                // I extract the current row
                TrainingRow row = trainingTemplate.rows[currentRow];

                do
                {
                    // I reset the adjutedWeights flag
                    adjustedWeights = false;

                    //extract the inputs and distribute them
                    List<double> templateInputs = row.inputs;
                    // Need to reverse them as to pop them
                    templateInputs.Reverse();

                    //Fire the neurons
                    foreach (Neuron neuron in inputLayer.neurons)
                    {
                        foreach (NeuronPort input in neuron.inputs)
                        {
                             // We get the last input from the template and check if it's not null if it's null we put 0
                            double var_input = 0;

                            if (templateInputs.Count > 0)
                            {
                                var_input = templateInputs.Last();
                                templateInputs.RemoveAt(templateInputs.Count -1);
                            }


                            input.reading = var_input;
                        }
                        neuron.fireNeuron();
                    }

                    // fire the hidden layer


                    foreach (Neuron neuron in hiddenLayer.neurons)
                    {
                        neuron.fireNeuron();
                    }

                    //Fire the output layer
                    outputLayer.neurons[0].fireNeuron();
                    error = outputLayer.neurons[0].output.weightedReading - trainingTemplate.rows[0].outputs[0];

                    if (error > acceptableError)
                    {
                        //Process the error here

                        Neuron outputNeuron = outputLayer.neurons[0];

                        //First of calculate the deltaSigma for output layer
                        outputNeuron.nodeDelta = (-1 * error) * outputNeuron.fireRule.fireNeuronDerivative(outputNeuron.inputs, outputNeuron.bias);

                        // and hidden layer (no input layer)

                        foreach (Neuron neuron in hiddenLayer.neurons)
                        {
                            
                            neuron.nodeDelta = outputNeuron.nodeDelta * (neuron.fireRule.fireNeuronDerivative(neuron.inputs, neuron.bias) + neuron.output.weight);
                                // need to add sum of weights going out
                        }

                        //Calculate the gradient

                        //For the output 

                        outputNeuron.output.gradient = outputNeuron.output.weightedReading * outputNeuron.nodeDelta;

                        foreach (Neuron neuron in hiddenLayer.neurons)
                        {

                            neuron.output.gradient = neuron.output.weightedReading * outputNeuron.nodeDelta;
                        }

                        //Calculate the new weights
                        
                        //For the output layer
                        outputNeuron.deltaWeight = learningRate * outputNeuron.output.gradient + moementum * outputNeuron.deltaWeight;
                        outputNeuron.output.weight += outputNeuron.deltaWeight;

                        //for the hidden layer
                        foreach (Neuron neuron in hiddenLayer.neurons)
                        {
                            neuron.deltaWeight = learningRate * neuron.output.gradient + moementum * neuron.deltaWeight;
                            neuron.output.weight += neuron.deltaWeight;
                        }

                        //For the input layer ?

                    }

                    // I mark that I've finished these generation
                    currentGeneration++;

                    //I check the conditions
                    stableGenFlag = stableGenerations < stableLimit;
                    genLimitFlag = currentGeneration < maxGenerations;
                    templateFlag = currentRow < trainingTemplate.rows.Count;


                    //the breaking conditions

                    if (!stableGenFlag)
                    {
                        //Console.WriteLine("Ended due to stable limit gen") ; 
                        return error;
                    }
                    if (!genLimitFlag)
                    {
                        //Console.WriteLine("Ended due to limit of gens to train");
                        return error;
                    }

                    
                } while (error > acceptableError);
            };

            //IAppDomainSetup still need to return the error history
            return error;
        }
    }
}
