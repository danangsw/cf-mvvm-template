using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.Utility.Services
{
    public class ResponseResult
    {
        public List<ResponseError> Errors = null;
        public bool Succeeded { get; protected set; }

        public ResponseResult(){
            Errors = new List<ResponseError>();
        }

        public static ResponseResult Failed(params ResponseError[] errors)
        {
            var result = new ResponseResult { Succeeded = false };
            if (errors != null)
            {
                result.Errors.AddRange(errors);
            }
            return result;
        }

        public static ResponseResult Failed(params string[] errors)
        {
            var result = new ResponseResult { Succeeded = false };
            if (errors != null)
            {
                foreach (var item in errors)
                {
                    result.Errors.Add(new ResponseError(item));
                }
            }
            return result;
        }

        public static ResponseResult Succeed()
        {
            var response = new ResponseResult { Succeeded = true };
            return response;
        }

        public override string ToString()
        {
            return Succeeded ?
                   "Succeeded" :
                    string.Join("\r", Errors.Select(x => x.Description).ToArray());

        }
    }


    public class ResponseResult<T> : ResponseResult where T : class
    {
        private static readonly ResponseResult<T> _success = new ResponseResult<T> { Succeeded = true };

        public List<T> Responses = null;
        public ResponseResult() {
            Responses = new List<T>();
        }

        public static new ResponseResult<T> Failed(params ResponseError[] errors)
        {
            var result = new ResponseResult<T> { Succeeded = false };
            if (errors != null)
            {
                result.Errors.AddRange(errors);
            }
            return result;
        }

        public static new ResponseResult<T> Failed(params string[] errors)
        {
            var result = new ResponseResult<T> { Succeeded = false };
            if (errors != null)
            {
                foreach (var item in errors)
                {
                    result.Errors.Add(new ResponseError(item));
                }
            }
            return result;
        }

        public static ResponseResult<T> Succeed(IEnumerable<T> results)
        {
            var response = new ResponseResult<T> { Succeeded = true };
            if (results != null)
            {
                response.Responses.AddRange(results);
            }
            return response;
        }

        public static ResponseResult<T> Succeed(T results)
        {
            var response = new ResponseResult<T> { Succeeded = true };
            if (results != null)
            {
                response.Responses.Add(results);
            }
            return response;
        }
    }


    public class ResponseError
    {
        private string code = "202";
        public string Code { get { return code ; } private set { code = value; } } 

        public string Description { get; private set; }

        public ResponseError(string description)
        {
            Description = description;
        }

        public ResponseError(string code, string description)
        {
            Description = description;
            Code = code;
        }
    }
}
