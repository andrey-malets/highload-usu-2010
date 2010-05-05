using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;

namespace Common
{
    class Transport : ITransport
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
            request.Method = "POST";
            byte[] postBuffer = serializer.Serialize(message.Get("POST")); // ?
            request.ContentLength = postBuffer.Length;
            Stream postData = request.GetRequestStream();
            postData.Write(postBuffer,0,postBuffer.Length);
            postData.Close();
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            byte[] responseBuffer = new byte[BufferSize];
            responseStream.Read(responseBuffer, 0, responseBuffer.Length);// ?
            string result = serializer.Deserialize<string>(responseBuffer);
            response.Close();
            responseStream.Close();
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("RESULT", result);
            return nameValueCollection;
        }
    }
}
