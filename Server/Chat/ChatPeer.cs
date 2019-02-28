using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

public class ChatPeer : ClientPeer
{
    public ChatPeer(InitRequest initRequest) : base(initRequest)
    {
    }

    protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
    {
        throw new System.NotImplementedException();
    }

    protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
    {
        throw new System.NotImplementedException();
    }
}