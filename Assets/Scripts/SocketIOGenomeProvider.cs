﻿using SharpNeat.Genomes.Neat;
using SocketIO;
using UnityEngine;

public class SocketIOGenomeProvider : GenomeProvider
{
    private SocketIOComponent socket;

    void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        // Setup listeners
        socket.On(SocketIODefaultEventTypes.Open, OnSocketOpen);
        socket.On(SocketIODefaultEventTypes.Close, OnSocketClose);
        socket.On(SocketIOUneatyEventTypes.Connected, OnUserConnected);
        socket.On(SocketIOUneatyEventTypes.Disconnected, OnUserDisconnected);

        socket.Emit(SocketIOUneatyEventTypes.Connected);

        socket.On(SocketIOUneatyEventTypes.NewModel, OnNewModel);
        Debug.Log("Game is start");
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

    public override NeatGenome Get()
    {
        return null;
    }
}