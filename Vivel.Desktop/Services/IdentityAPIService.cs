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

        public async Task<Tuple<int, dynamic>> Insert(object request)
        {
            try
            {
                var result = await $"{_apiUrl}".WithHeader("Authorization", $"Bearer {_accessToken}").PostJsonAsync(request).ReceiveJson();

                return new Tuple<int, dynamic>(200, result);
            }
            catch (Exception e)
            {
                return new Tuple<int, dynamic>(-1, e.Message);
            }

        }

        public async Task<Tuple<int, dynamic>> Update(string id, object request)
        {
            try
            {
                var result = await $"{_apiUrl}/{id}".WithHeader("Authorization", $"Bearer {_accessToken}").PutJsonAsync(request).ReceiveJson();

                return new Tuple<int, dynamic>(200, result);
            }
            catch (Exception e)
            {
                return new Tuple<int, dynamic>(-1, e.Message);
            }
        }

        public async Task<Tuple<int, dynamic>> Delete(string id)
        {
            try
            {
                var result = await $"{_apiUrl}/{id}".WithHeader("Authorization", $"Bearer {_accessToken}").DeleteAsync().ReceiveJson();

                return new Tuple<int, dynamic>(200, result);
            }
            catch (Exception e)
            {
                return new Tuple<int, dynamic>(-1, e.Message);
            }
        }
    }
}
