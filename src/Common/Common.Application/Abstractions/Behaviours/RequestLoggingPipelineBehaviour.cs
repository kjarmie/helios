using LanguageExt;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Common.Application.Abstractions.Behaviours;

public sealed class RequestLoggingPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<RequestLoggingPipelineBehaviour<TRequest, TResponse>> _logger;

    public RequestLoggingPipelineBehaviour(ILogger<RequestLoggingPipelineBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("Processing request {RequestName}", requestName);

        var result = await next();

        // TODO: Log if the outcome was success or fail. We need a way to constrain the TResult to a Result/Fin/Either, etc. We may need to create our own version of the Result struct but as a class or record.

        _logger.LogInformation("Completed request {RequestName}", requestName);

        // using(LogContext.PushProperty("Error", result.Error, true) {
        //      _logger.LogInformation("Completed request {RequestName} with {@Error}", requestName, error);
        // }

        return result;
    }
}