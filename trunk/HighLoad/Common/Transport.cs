using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using Common.Serialization;

namespace Common
{
    public class Transport : ITransport
    {
        private IDataSerializer serializer;
        private const int BufferSize = 4096;
        public Transport(IDataSerializer serializer)
        {
            this.serializer = serializer;
        }
        public NameValueCollection Interact(IServerEndpoint serverEndpoint, NameValueCollection message)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(serverEndpoint.Url + ":" + serverEndpoint.Port);
            byte[] postBuffer;
            Stream postData = request.GetRequestStream();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            byte[] responseBuffer;
            string result;
            NameValueCollection nameValueCollection = new NameValueCollection();
            request.Method = "POST";
            foreach (KeyValuePair<string,string> collection in message)
            {
                postBuffer = serializer.Serialize(collection.Value);
                request.ContentLength = postBuffer.Length;
                postData.Write(postBuffer, 0, postBuffer.Length);
                responseBuffer = new byte[BufferSize];
                responseStream.Read(responseBuffer, 0, responseBuffer.Length);
                result = serializer.Deserialize<string>(responseBuffer);
                nameValueCollection.Add(collection.Key, result);
            }
            postData.Close();
            response.Close();
            responseStream.Close();
            return nameValueCollection;
        }
    }
}
