using UnityEngine;
using Newtonsoft.Json;
using SharpNeat.Genomes.Neat;
using SocketIO;

public class SocketIOGenomeTransmitter : MonoBehaviour
{
    private SocketIOComponent socket;
    public GenomeProvider GenomeProvider;

    void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        // Setup listeners
        socket.On(SocketIODefaultEventTypes.Open, OnSocketOpen);
        socket.On(SocketIODefaultEventTypes.Close, OnSocketClose);
        socket.On(SocketIOUneatyEventTypes.Connected, OnUserConnected);
        socket.On(SocketIOUneatyEventTypes.Disconnected, OnUserDisconnected);
        socket.On("UPDATE_MODEL", OnModelUpdated);

        socket.Emit(SocketIOUneatyEventTypes.Connected);

        socket.On(SocketIOUneatyEventTypes.NewModel, OnNewModel);
        Debug.Log("Game is start");
    }

    void Update()
    {
        NeatGenome genome = GenomeProvider.Get();
        if (genome != null)
        {
            INeuralNetwork network = new SocketIONeuralNetwork();
            network.Genome = genome;
            string json = JsonConvert.SerializeObject(network);
            Debug.Log("Sending json update: " + json);
            socket.Emit(SocketIOUneatyEventTypes.NewModel, json);
        }
    }

    private void OnModelUpdated(SocketIOEvent obj)
    {
        Debug.Log("Receiving new model: " + obj.data.ToString());
    }

    private void OnSocketClose(SocketIOEvent obj)
    {
        Debug.Log("Closing socket.");
    }

    private void OnNewModel(SocketIOEvent obj)
    {
        Debug.Log("New Model");
    }

    public void OnSocketOpen(SocketIOEvent ev)
    {
        Debug.Log("updated socket id " + socket.sid);
    }

    void OnUserDisconnected(SocketIOEvent obj)
    {
        Debug.Log("Other user disconnected: " +
                  uNEATySocketIOUtils.JsonToString(obj.data.GetField("name").ToString(), "/"));
    }

    void OnUserConnected(SocketIOEvent obj)
    {
        Debug.Log("Other user connected: " +
                  uNEATySocketIOUtils.JsonToString(obj.data.GetField("name").ToString(), "/"));
    }
}