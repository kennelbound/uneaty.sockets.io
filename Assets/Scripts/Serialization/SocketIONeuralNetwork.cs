using System.Collections.Generic;
using SharpNeat.Genomes.Neat;

[System.Serializable]
public class SocketIONeuralNetwork : INeuralNetwork
{
    private NeatGenome _genome;

    public NeatGenome Genome
    {
        set
        {
            _genome = value;

            Neurons = new List<INeuralNetworkNeuron>(_genome.NeuronGeneList.Count);
            Connections = new List<INeuralNetworkConnection>(_genome.ConnectionGeneList.Count);

            foreach (NeuronGene neuronGene in _genome.NeuronGeneList)
            {
                INeuralNetworkNeuron neuron = new SocketIONeuralNetworkNeuron();
                neuron.Gene = neuronGene;
                Neurons.Add(neuron);
            }

            foreach (ConnectionGene connectionGene in _genome.ConnectionList)
            {
                INeuralNetworkConnection connection = new SocketIONeuralNetworkConnection();
                connection.Gene = connectionGene;
                Connections.Add(connection);
            }
        }
    }

    public List<INeuralNetworkNeuron> Neurons { private set; get; }
    public List<INeuralNetworkConnection> Connections { private set; get; }
}