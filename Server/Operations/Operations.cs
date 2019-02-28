using Photon.Hive;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Operations
{
    public class Operations : HivePeer
    {
        public Operations(InitRequest request) : base(request)
        {
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            // handle operation here (check request.OperationCode)
            switch (operationRequest.OperationCode)
            {
                case 1:
                    {
                        var message = (string)operationRequest.Parameters[100];
                        if (message == "Hello World")
                        {
                            // received hello world, send an answer!
                            var response = new OperationResponse
                            {
                                OperationCode = operationRequest.OperationCode,
                                ReturnCode = 0,
                                DebugMessage = "OK",
                                Parameters = new Dictionary<byte, object> { { 100, "Hello yourself!" } }
                            };

                            this.SendOperationResponse(response, sendParameters);
                        }
                        else
                        {
                            // received something else, send an error
                            var response = new OperationResponse
                            {
                                OperationCode = operationRequest.OperationCode,
                                ReturnCode = 1,
                                DebugMessage = "Don't understand, what are you saying?"
                            };

                            this.SendOperationResponse(response, sendParameters);
                        }

                        return;
                    }
            }
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            throw new NotImplementedException();
        }

    }
}
