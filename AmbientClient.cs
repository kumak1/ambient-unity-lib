// Copyright © kumak1. All rights reserved. 

using System;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

namespace AmbientUnityLib
{
    public class Ambient
    {
        private const string Scheme = "https";
        private const string Host = "ambidata.io";
        private readonly string channelId;
        private readonly string writeKey;
        private readonly string readKey;

        private string ReadPath => $"/api/v2/channels/{channelId}/data";
        private string SendPath => $"/api/v2/channels/{channelId}/urldataarray";

        private static readonly HttpClient Client = new HttpClient();

        public Ambient(string channelId, string readKey = "", string writeKey = "", int timeout = 3000)
        {
            this.channelId = channelId;
            this.writeKey = writeKey;
            this.readKey = readKey;

            Client.Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        private static string Request(HttpRequestMessage requestMessage)
        {
            Task<HttpResponseMessage> response;
            var responseStatusCode = HttpStatusCode.NotFound;
            string responseBody;

            try
            {
                response = Client.SendAsync(requestMessage);
                responseBody = response.Result.Content.ReadAsStringAsync().Result;
                responseStatusCode = response.Result.StatusCode;
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }

            if (!responseStatusCode.Equals(HttpStatusCode.OK))
            {
                return "status code: " + responseStatusCode.ToString();
            }

            return responseBody ?? "";
        }

        public string Read(AmbientReadParameter data = null)
        {
            data ??= new AmbientReadParameter();

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                new UriBuilder
                {
                    Scheme = Scheme,
                    Host = Host,
                    Path = ReadPath,
                    Query = data.ToCollectionWithKey(readKey).ToString(),
                }.ToString()
            );
            return Request(request);
        }

        public string Send(AmbientSendParameter data)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Post,
                new UriBuilder
                {
                    Scheme = Scheme,
                    Host = Host,
                    Path = SendPath,
                }.ToString()
            );
            request.Content = new FormUrlEncodedContent(data.ToDictionaryWithKey(writeKey));

            return Request(request);
        }
    }

}

