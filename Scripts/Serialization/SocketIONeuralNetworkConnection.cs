using SharpNeat.Genomes.Neat;

[System.Serializable]
public class SocketIONeuralNetworkConnection : INeuralNetworkConnection
{
    private ConnectionGene _gene;
    public uint SourceId { get; private set; }
    public uint TargetId { get; private set; }
    public bool Mutated { get; private set; }
    public double Weight { get; private set; }

    public ConnectionGene Gene
    {
        set
        {
            _gene = value;
            SourceId = _gene.SourceNodeId;
            TargetId = _gene.TargetNodeId;
            Mutated = _gene.IsMutated;
            Weight = _gene.Weight;
        }
    }
}