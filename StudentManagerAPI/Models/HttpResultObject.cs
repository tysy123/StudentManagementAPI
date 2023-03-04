using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StudentManagerAPI.Models
{
    public class HttpResultObject
    {
        public dynamic Status { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public dynamic Data { get; set; }

        public HttpResultObject()
        {
            this.Status = HttpStatusCode.OK.ToString();
            this.Message = null;
            this.Code = HttpStatusCode.OK;
            this.Data = null;
        }

        public HttpResultObject(dynamic data)
        {
            if (data != null)
            {
                this.Status = HttpStatusCode.OK.ToString();
                this.Message = null;
                this.Code = HttpStatusCode.OK;
                this.Data = data;
            }
            else
            {
                this.Status = HttpStatusCode.BadRequest.ToString();
                this.Message = "Bad Request!";
                this.Code = HttpStatusCode.OK;
                this.Data = data;
            }
        }
        public HttpResultObject(dynamic data, string message)
        {
            this.Status = HttpStatusCode.OK.ToString();
            this.Message = message;
            this.Code = HttpStatusCode.OK;
            this.Data = data;
        }

        public HttpResultObject(HttpStatusCode code, dynamic status, dynamic data, string message)
        {
            this.Status = status;
            this.Message = message;
            this.Code = code;
            this.Data = data;
        }
    }
}
