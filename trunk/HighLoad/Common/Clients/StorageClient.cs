using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Common.Serialization;

namespace Common.Clients
{
    public class StorageClient : IStorageClient
    {
        private readonly IDataSerializer dataSerializer;
        private readonly IServerEndpointFactory serverEndpointFactory;
        private readonly ITransport transport;

        public StorageClient(IDataSerializer dataSerializer, ITransport transport,
                             IServerEndpointFactory serverEndpointFactory)
        {
            this.dataSerializer = dataSerializer;
            this.transport = transport;
            this.serverEndpointFactory = serverEndpointFactory;
        }

        #region IStorageClient Members

        public IEnumerable<T> Update<T>(long revision)
        {
            var message = new NameValueCollection
                              {
                                  {"command", "update"},
                                  {"data", revision.ToString()}
                              };
            NameValueCollection result = Send(message);

            return dataSerializer.Deserialize<IEnumerable<T>>(Convert.FromBase64String(result["data"]));
        }

        public T Save<T>(T data)
        {
            var message = new NameValueCollection
                              {
                                  {"command", "save"},
                                  {"data", Convert.ToBase64String(dataSerializer.Serialize(data))}
                              };

            NameValueCollection result = Send(message);

            return dataSerializer.Deserialize<T>(Convert.FromBase64String(result["data"]));
        }

        #endregion

        private NameValueCollection Send(NameValueCollection message)
        {
            return transport.Interact(serverEndpointFactory.GetStorageServerEndpoint(), message);
        }
    }
}