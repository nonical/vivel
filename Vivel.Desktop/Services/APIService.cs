using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Vivel.Model.Extensions;

namespace Vivel.Desktop.Services
{
    // TODO: Make APIService class generic, instead of methods
    public class APIService
    {
        private readonly string _apiUrl;
        private readonly string _accessToken;

        public APIService(string resource, string accessToken)
        {
            _apiUrl = $"{Properties.Settings.Default.ApiURL}/{resource}";
            _accessToken = accessToken;
        }
        public async Task<T> Get<T>(object request = null)
        {
            var queryString = "";

            if (request != null)
            {
                queryString = await request?.ToQueryString();
            }

            var result = await $"{_apiUrl}?{queryString}".WithHeader("Authorization", $"Bearer {_accessToken}").GetJsonAsync<T>();

            return result;
        }

        public async Task<T> GetByID<T>(string id)
        {
            var result = await $"{_apiUrl}/{id}".WithHeader("Authorization", $"Bearer {_accessToken}").GetJsonAsync<T>();

            return result;
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

        public async Task<T> Delete<T>(string id)
        {
            var result = await $"{_apiUrl}/{id}".WithHeader("Authorization", $"Bearer {_accessToken}").DeleteAsync().ReceiveJson<T>();

            return result;
        }

        public async Task<Tuple<int, dynamic>> DownloadFile(string path, object request, string filename)
        {
            try
            {
                var queryString = await request.ToQueryString();
                var result = await $"{_apiUrl}/{path}?{queryString}".WithHeader("Authorization", $"Bearer {_accessToken}").DownloadFileAsync("c:\\downloads", filename);

                return new Tuple<int, dynamic>(200, result);
            }
            catch (Exception e)
            {
                return new Tuple<int, dynamic>(-1, e.Message);
            }
        }
    }
}
