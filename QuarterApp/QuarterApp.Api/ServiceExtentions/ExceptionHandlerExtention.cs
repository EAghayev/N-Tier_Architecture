using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using QuarterApp.Service.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterApp.Api.ServiceExtentions
{
    public static class ExceptionHandlerExtention
    {
        public static void AddExceptionHandlerService(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = 500;
                    string message = "Inter Server Error. Please Try Again Later!";


                    if (contextFeature != null)
                    {
                        message = contextFeature.Error.Message;

                        if (contextFeature.Error is ItemNotFoundException)
                            statusCode = 404;
                        else if (contextFeature.Error is RecordAlreadyExistException)
                            statusCode = 409;
                        else if (contextFeature.Error is PageIndexFormatException)
                            statusCode = 400;
                        else if (contextFeature.Error is FileFormatException)
                            statusCode = 400;
                    }

                    context.Response.StatusCode = statusCode;

                    var errprJsonStr = JsonConvert.SerializeObject(new
                    {
                            code = statusCode,
                            message = message
                    });

                    await context.Response.WriteAsync(errprJsonStr);
                });
            });

        }
    }
}
