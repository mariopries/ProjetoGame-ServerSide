using Photon.SocketServer;

public class ChatServer : ApplicationBase
{
    protected override PeerBase CreatePeer(InitRequest initRequest)
    {
        return new ChatPeer(initRequest);
    }

    protected override void Setup()
    {
        throw new System.NotImplementedException();
    }

    protected override void TearDown()
    {
        throw new System.NotImplementedException();
    }
}