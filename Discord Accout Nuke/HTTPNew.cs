using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Discord_Accout_Nukes;

namespace Discord_Accout_Nukes
{
    public static class HTTPNew
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string url, HttpContent iContent)
        {
            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, new Uri(url))
            {
                Content = iContent
            };

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException) { }

            return response;
        }
        public static async Task<HttpResponseMessage> PutAsync(this HttpClient client, string url, HttpContent iContent)
        {
            var method = new HttpMethod("PutAsync");

            var request = new HttpRequestMessage(method, new Uri(url))
            {
                Content = iContent
            };

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException) { }

            return response;
        }
    }
}
