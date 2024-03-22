using LanguageExt.Common;
using MediatR;

namespace Common.Application.Abstractions.Messaging;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{

}