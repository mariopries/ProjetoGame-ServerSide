using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using System.Threading;

public class Program : IPhotonPeerListener
{
    private bool connected;
    PhotonPeer peer;

    public static void Main()
    {
        var client = new Program();
        client.peer = new PhotonPeer(client, ConnectionProtocol.Tcp);
        // connect
        client.DebugReturn(DebugLevel.INFO, "Connecting to server at 127.0.0.1:4530 using TCP");
        client.peer.Connect("127.0.0.1:4530", "Chat");
        // client needs a background thread to dispatch incoming messages and send outgoing messages
        client.Run();
        while (true)
        {
            if (!client.connected) { continue; }
            // read input
            string buffer = Console.ReadLine();
            // send to server
            var parameters = new Dictionary<byte, object> { { 1, buffer } };
            client.peer.OpCustom(1, parameters, true);
        }
    }

    private void UpdateLoop()
    {
        while (true)
        {
            peer.Service();
        }
    }

    public void Run()
    {
        Thread thread = new Thread(UpdateLoop);
        thread.IsBackground = true;
        thread.Start();
    }

    #region IPhotonPeerListener

    public void DebugReturn(DebugLevel level, string message)
    {
        Console.WriteLine(string.Format("{0}: {1}", level, message));
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        // handle response by code (action we called)
        switch (operationResponse.OperationCode)
        {
            // out custom "hello world" operation's code is 1
            case 1:
                // OK
                if (operationResponse.ReturnCode == 0)
                {
                    // show the complete content of the response
                    Console.WriteLine(operationResponse.ToStringFull());
                }
                else
                {
                    // show the error message
                    Console.WriteLine(operationResponse.DebugMessage);
                }
                break;
        }
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        if (statusCode == StatusCode.Connect)
        {
            connected = true;
        }
        switch (statusCode)
        {
            case StatusCode.Connect:
                // send hello world when connected
                var parameter = new Dictionary<byte, object>();
                parameter.Add((byte)100, "Hello World");

                peer.OpCustom(1, parameter, true);
                break;
            default:
                DebugReturn(DebugLevel.ERROR, statusCode.ToString());
                break;
        }
    }

    public void OnEvent(EventData eventData)
    {
        Console.WriteLine("Testando");
    }

    public void OnMessage(object messages)
    {
        Console.WriteLine("TESTE : "+messages.ToString());
    }

    #endregion
}