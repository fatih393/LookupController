using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Shared.ResponseModel
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public string StatusCode { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get ; set ; }
        public T Data { get; set ; }



        public static ApiResponse<T> Create(T Data, bool IsSuccess = true, string StatusCode = null, string ErrorMesssage = null)
        {
            return new ApiResponse<T>() { Data = Data, Success = IsSuccess, Message = ErrorMesssage, StatusCode = StatusCode };
        }
        public static ApiResponse<T> Create(Exception ex)
        {
            return new ApiResponse<T>() { Success = false, Message = ex.Message };
        }
        public static ApiResponse<T> CreateOk(T data)
        {
            return new ApiResponse<T>() { Data = data, Success = true, StatusCode = StatusCodes.Status200OK.ToString() };
        }

        public static ApiResponse<T> CreateBadRequest(T data, string errorMesssage = null, string errorSource = null, string correlationID = null)
        {
            return new ApiResponse<T>() { Data = data, Success = false, Message = errorMesssage, StatusCode = StatusCodes.Status400BadRequest.ToString()};
        }

        public static ApiResponse<T> CreateNotFound(string errorMesssage)
        {
            return new ApiResponse<T>() { Success = false, Message = errorMesssage, StatusCode = StatusCodes.Status204NoContent.ToString() };
        }

    }

    public class ApiResponse : IApiResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public int StatusCode { get; set; }


        public static ApiResponse Create()
        {
            return new ApiResponse() { Success = true };
        }
        public static ApiResponse Create(bool success = true, int statusCode = 200)
        {
            return new ApiResponse() { Success = success, StatusCode = statusCode };
        }
        public static ApiResponse Create(bool success = true)
        {
            return new ApiResponse()
            {
                Success = success,
                StatusCode = success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest
            };
        }
        public static Task<ApiResponse> CreateAsync()
        {
            return Task.FromResult(Create());
        }
        public static ApiResponse Create(Exception ex)
        {
            return new ApiResponse() { Success = false, Message = ex.Message };
        }
        public static Task<ApiResponse> CreateAsync(Exception ex)
        {
            return Task.FromResult(Create(ex));
        }
    }
}
