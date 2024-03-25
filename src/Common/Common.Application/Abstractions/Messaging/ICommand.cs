using Common.Utilities.FunctionalExtensions.ErrorHandling;
using MediatR;

namespace Common.Application.Abstractions.Messaging;

/// <summary>
/// Marker interface to represent a Command (mutation) request with a response, wrapped in a Result.
/// </summary>
/// <typeparam name="TResponse">Response type</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}