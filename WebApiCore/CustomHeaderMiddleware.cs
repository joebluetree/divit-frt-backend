using Database.Lib.Interfaces;
using System.Reflection.PortableExecutable;

namespace WebApiCore
{
    public class CustomHeaderMiddleware
    {
        private readonly IHeaderRepository _headerRepository;
        private readonly RequestDelegate _next;

        public CustomHeaderMiddleware(RequestDelegate next, IHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _headerRepository.init();
            foreach (var header in context.Request.Headers)
            {
                _headerRepository.AddHeader(header.Key, header.Value!);
            }
            // Call the next delegate/middleware in the pipeline
            await _next(context);

            // Optionally, add a custom header to the response
            //context.Response.Headers.Add("Custom-Response-Header", "CustomValue");
        }
    }

}