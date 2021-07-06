using System;
using System.Collections.Generic;
using System.Text;

namespace BlockHistoryApp.Service.Common
{
    public class Response<T> where T:class
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public string  Message { get; set; }

        public static Response<T> Success(T Data)
        {
            var response = new Response<T> {Status=true, Data = Data };

            return response;
        }

        public static Response<T> Failed(string message="")
        {
            var response = new Response<T> { Status = false, Message = message};

            return response;
        }
    }

    
}
