using Common.Utilities.FunctionalExtensions.ErrorHandling;
using MediatR;

namespace Common.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}