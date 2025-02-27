﻿using LinqToDB.SqlQuery;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                        if (exception is FluentValidation.ValidationException excecoes)
                        {
                            problemDetails.Title = "A requisição é inválida.";
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = excecoes.StackTrace;
                            problemDetails.Instance = excecoes.StackTrace;
                            problemDetails.Extensions["Erro"] = excecoes.Errors

                             .GroupBy(x => x.PropertyName, x => x.ErrorMessage)
                             .ToDictionary(y => y.Key, y => y.ToList());
                        }
                        else if (exception is SqlException sqlException)
                        {
                            problemDetails.Title = "Erro no Banco de Dados";
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = sqlException.StackTrace;
                            problemDetails.Extensions["Erro"] = sqlException.Message;
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Erro inesperado: {exceptionHandlerFeature.Error}");
                            problemDetails.Title = "Erro inesperado";
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = exception.Demystify().ToString();
                            problemDetails.Extensions["Erro"] = exception.Message;
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