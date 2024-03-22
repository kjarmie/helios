using LanguageExt.Common;
using MediatR;

namespace Common.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}