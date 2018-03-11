using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Infrastructure
{
    class MiddlewareTest
    {
        private readonly RequestDelegate _next;

        public MiddlewareTest(RequestDelegate next)
        {
            _next = next;
        }
        
        
        public async Task Invoke(HttpContext httpContext)
        {
            var resp = httpContext.Response; 
            resp.Headers.Add("from-middleware", "Hello");

            await _next(httpContext);
        }
    }

    class MiddlewareInterfaceTest : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine($"New instance; {GetHashCode()}");
            return next.Invoke(context);
        }
    }
}