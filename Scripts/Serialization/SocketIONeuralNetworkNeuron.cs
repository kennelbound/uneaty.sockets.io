using SharpNeat.Genomes.Neat;

[System.Serializable]
public class SocketIONeuralNetworkNeuron : INeuralNetworkNeuron
{
    private NeuronGene _gene;

    public NeuronGene Gene
    {
        set
        {
            _gene = value;
            NodeType = _gene.NodeType.ToString();
            Id = _gene.Id;
        }
    }

    public uint Id { get; private set; }
    public string NodeType { get; private set; }
}