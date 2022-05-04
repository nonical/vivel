using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace Vivel.Desktop.Services
{
    public class IdentityAPIService
    {
        private readonly string _apiUrl;
        private readonly string _accessToken;

        public IdentityAPIService(string resource, string accessToken)
        {
            _apiUrl = $"{Properties.Settings.Default.IdentityApiURL}/{resource}";
            _accessToken = accessToken;
        }

        public async Task<T> Insert<T>(object request)
        {
            var result = await $"{_apiUrl}".WithHeader("Authorization", $"Bearer {_accessToken}").PostJsonAsync(request).ReceiveJson<T>();

            return result;
        }

        public async Task<T> Update<T>(string id, object request)
        {
            var result = await $"{_apiUrl}/{id}".WithHeader("Authorization", $"Bearer {_accessToken}").PutJsonAsync(request).ReceiveJson<T>();

            return result;
        }
    }
}
