using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Service.ApiClient
{
    public static class ApiClientConstant
    {
        public const int Timeout = 300000;

        public static class Error
        {
            public const string UnableToConnect = "Unable to connect to the remote server";
            public const string ServerNotFound = "Error53";
            public const string Timeout = "Error258";
        }

        public static class HeaderKey {
            public const string ContentType = "Content-type";
        }

        public static class HeaderValue
        {
            public const string ApplicationJson = "application/json";
        }

        public static class StocktakeUri
        {
            public const string Route = "api/Stocktake/";
            public const string InitialSetup = Route + "InitialSetup/";
            public const string GetStocktake = Route + "GetStocktake/";
            public const string SubmitStocktake = Route + "SubmitStocktake/";
        } 
    }
}
