using Common.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Webapp.ModelBinders;

// public class ValueObjectBinderProvider : IModelBinderProvider
// {
//     public IModelBinder? GetBinder(ModelBinderProviderContext bindingContext)
//     {
//         var modelType = bindingContext.Metadata.ModelType;
//
//
//
//         // var modelType = bindingContext.Metadata.ModelType;
//         // if (modelType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IValueObject<,>)))
//         // {
//         //     // Return a binder instance for IValueObject types
//         //     var valueObjectType = modelType;
//         //     return new ValueObjectModelBinder<object>(valueObjectType);
//         // }
//         //
//         // return null;
//     }
// }