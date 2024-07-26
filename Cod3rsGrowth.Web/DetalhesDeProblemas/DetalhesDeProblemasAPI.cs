using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SharpYaml.Serialization;
using System.Diagnostics;

namespace Cod3rsGrowth.Web.DetalhesDeProblemas
{
    public static class DetalhesDeProblemasAPI
    {
        public static void ExibeDetalhesDeProblemasDeExcecaoNaAPI(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;
                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };
                        if (exception is ValidationException excecoes)
                        {
                            problemDetails.Title = "A requisição é inválida.";
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = excecoes.Message;
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Erro inesperado: {exceptionHandlerFeature.Error}");
                            problemDetails.Title = exception.Message;
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = exception.Demystify().ToString();
                        }
                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/problem+json";
                        var json = JsonConvert.SerializeObject(problemDetails);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
