using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Shared.ResponseModel
{
    public interface IApiResponse<T>
    {
        string StatusCode { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
        T Data { get; set; }
    }
    public interface IApiResponse
    {
       int StatusCode { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
    }
}
