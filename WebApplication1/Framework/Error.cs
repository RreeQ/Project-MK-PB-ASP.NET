using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Framework
{
    public class Error
    {
        private readonly RequestDelegate _next;
        public Error(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {

                await ErrorHandler(context, e);
            }
        }

        private async Task ErrorHandler(HttpContext context, Exception e)
        {
            var payload = new { message = e.Message };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(payload));
        }
    }
}
