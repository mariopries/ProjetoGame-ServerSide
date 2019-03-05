using Photon.LoadBalancing.Common;
using Photon.LoadBalancing.Master.OperationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region using directives

using ExitGames.Logging;

using Photon.LoadBalancing.MasterServer;
using Photon.LoadBalancing.Operations;
using Photon.SocketServer;

#endregion

namespace Server
{
    class teste : OperationHandlerBase
    {
        public static readonly OperationHandlerInitial Instance = new OperationHandlerInitial();

        private static readonly ILogger log = LogManager.GetCurrentClassLogger();

        public override OperationResponse OnOperationRequest(PeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
        {
            log.DebugFormat(" TESTE Douglas : OperationCode :: " + operationRequest.OperationCode.ToString());

            switch (operationRequest.OperationCode)
            {
                default:
                    return HandleUnknownOperationCode(operationRequest, log);
                case (byte)100:
                    log.DebugFormat("Douglas : OperationCode.Authenticate - OperationHandlerInitial.cs -- DEU CERTOOOOOOOOOOOOOOO");
                    foreach (var item in operationRequest.Parameters)
                    {
                        log.DebugFormat("Douglas : " + item);
                    }

                    return ((MasterClientPeer)peer).HandleAuthenticate(operationRequest, sendParameters);

                case (byte)OperationCode.Authenticate:
                    log.DebugFormat("Douglas : OperationCode.Authenticate - OperationHandlerInitial.cs");
                    return ((MasterClientPeer)peer).HandleAuthenticate(operationRequest, sendParameters);

                case (byte)OperationCode.CreateGame:
                case (byte)OperationCode.JoinGame:
                case (byte)OperationCode.JoinLobby:
                case (byte)OperationCode.JoinRandomGame:
                case (byte)OperationCode.FindFriends:
                case (byte)OperationCode.LobbyStats:
                case (byte)OperationCode.LeaveLobby:
                case (byte)OperationCode.DebugGame:
                case (byte)OperationCode.Rpc:
                    return new OperationResponse(operationRequest.OperationCode)
                    {
                        ReturnCode = (int)Photon.Common.ErrorCode.OperationDenied,
                        DebugMessage = LBErrorMessages.NotAuthorized
                    };
            }
        }
    }
}
