using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fiorella.Services.Exceptions
{
    public class RestException : Exception
    {
        public RestException(string errorKey, string errorMessage, HttpStatusCode code, string message = null)
        {
            StatusCode = code;
            Message = message;
            Errors = new List<RestExceptionError> { new RestExceptionError(errorKey, errorMessage) };
        }

        public RestException(HttpStatusCode code, List<RestExceptionError> errorList, string message = null)
        {
            StatusCode = code;
            Message = message;
            Errors = errorList;
        }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public List<RestExceptionError> Errors { get; set; }
    }

    public class RestExceptionError
    {
        public RestExceptionError(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
  