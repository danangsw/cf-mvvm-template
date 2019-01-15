using System;
using System.Collections.Generic;
using System.Text;

namespace DSW.Library
{
    public static class AppConstant
    {
    }

    public static class ApiClientConstant
    {
        public static class RestClient {
            public const int Timeout = 300000;
            public const string ContentType = "Content-type";
            public const string ApplicationJson = "application/json";
            private const string ApiPrefix = "api";
        }

        public static class Error {
            public const string UnableToConnect = "Unable to connect to the remote server";
            public const string ServerNotFound = "Error53";
            public const string Timeout = "Error258";
        }
    }

    public static class DatabaseConstant
    {
    }
}
