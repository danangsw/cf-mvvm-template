using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Threading;
using System.Resources;
using DSW.Core.Utility.Services;

namespace DSW.Service.ApiClient
{
    public interface IApiClientService
    {
        T Get<T>(string IP, string route) where T : new();
        T Get<T>(string IP, string route, string id) where T : new();
        T Post<T>(string IP, string route, T data) where T : new();
        T Put<T>(string IP, string route, T data) where T : new();
        R Post<R>(string IP, string route, object data) where R : new();
    }

    public class ApiClientService : IApiClientService
    {
        public ResourceManager ResxMessages { get { return MultiLanguageManager.Messages; } }

        public T Get<T>(string IP, string route) where T : new()
        {
            var client = new RestClient(IP);
            client.Timeout = ApiClientConstant.Timeout;
            var requestGet = new RestRequest(route, Method.GET);
            IRestResponse<T> response = client.Execute<T>(requestGet);
            if (!response.IsSuccessful)
            {
                if (response.ErrorMessage == ApiClientConstant.Error.UnableToConnect ||
                    response.ErrorMessage == ApiClientConstant.Error.ServerNotFound)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS008);
                }

                if (response.ErrorMessage == ApiClientConstant.Error.Timeout)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS040);
                }

                throw new Exception(string.IsNullOrEmpty(response.Content) ? response.ErrorMessage : response.Content);
            }

            return response.Data;
        }


        public T Get<T>(string IP, string route, string id) where T : new()
        {
            var client = new RestClient(IP);
            client.Timeout = ApiClientConstant.Timeout;
            var requestGet = new RestRequest(route + id, Method.GET);
            IRestResponse<T> response = client.Execute<T>(requestGet);
            if (!response.IsSuccessful)
            {
                if (response.ErrorMessage == ApiClientConstant.Error.UnableToConnect ||
                    response.ErrorMessage == ApiClientConstant.Error.ServerNotFound)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS008);
                }

                if (response.ErrorMessage == ApiClientConstant.Error.Timeout)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS040);
                }

                throw new Exception(string.IsNullOrEmpty(response.Content) ? response.ErrorMessage : response.Content);
            }

            return response.Data;
        }

        public T Post<T>(string IP, string route, T data) where T : new()
        {
            var client = new RestClient(IP);
            client.Timeout = ApiClientConstant.Timeout;
            var requestPost = new RestRequest(route, Method.POST);
            requestPost.AddHeader(ApiClientConstant.HeaderKey.ContentType, ApiClientConstant.HeaderValue.ApplicationJson);
            requestPost.AddJsonBody(data);
            IRestResponse<T> response = client.Execute<T>(requestPost);
            if (!response.IsSuccessful)
            {
                if (response.ErrorMessage == ApiClientConstant.Error.UnableToConnect ||
                    response.ErrorMessage == ApiClientConstant.Error.ServerNotFound)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS008);
                }

                if (response.ErrorMessage == ApiClientConstant.Error.Timeout)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS040);
                }

                throw new Exception(string.IsNullOrEmpty(response.Content) ? response.ErrorMessage : response.Content);
            }
            return response.Data;
        }

        public T Put<T>(string IP, string route, T data) where T : new()
        {
            var client = new RestClient(IP);
            client.Timeout = ApiClientConstant.Timeout;
            var requestPut = new RestRequest(route, Method.PUT);
            requestPut.AddHeader(ApiClientConstant.HeaderKey.ContentType, ApiClientConstant.HeaderValue.ApplicationJson);
            requestPut.AddJsonBody(data);
            IRestResponse<T> response = client.Execute<T>(requestPut);
            if (!response.IsSuccessful)
            {
                if (response.ErrorMessage == ApiClientConstant.Error.UnableToConnect ||
                    response.ErrorMessage == ApiClientConstant.Error.ServerNotFound)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS008);
                }

                if (response.ErrorMessage == ApiClientConstant.Error.Timeout)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS040);
                }

                throw new Exception(string.IsNullOrEmpty(response.Content) ? response.ErrorMessage : response.Content);
            }
            return response.Data;
        }

        public R Post<R>(string IP, string route, object data)
            where R : new()
        {
            var client = new RestClient(IP);
            client.Timeout = ApiClientConstant.Timeout;
            var requestPost = new RestRequest(route, Method.POST);
            requestPost.AddHeader(ApiClientConstant.HeaderKey.ContentType, ApiClientConstant.HeaderValue.ApplicationJson);
            requestPost.AddJsonBody(data);
            IRestResponse<R> response = client.Execute<R>(requestPost);
            if (!response.IsSuccessful)
            {
                if (response.ErrorMessage == ApiClientConstant.Error.UnableToConnect ||
                    response.ErrorMessage == ApiClientConstant.Error.ServerNotFound)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS008);
                }

                if (response.ErrorMessage == ApiClientConstant.Error.Timeout)
                {
                    response.ErrorMessage = ResxMessages.GetString(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS040);
                }

                throw new Exception(string.IsNullOrEmpty(response.Content) ? response.ErrorMessage : response.Content);
            }
            return response.Data;
        }


    }
}
