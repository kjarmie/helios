// using Common.Domain.Abstractions;
// using Common.Utilities.FunctionalExtensions.ErrorHandling;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
//
// namespace Webapp.ModelBinders;
//
// public abstract class ValueObjectModelBinder<TValue, TThis> : IModelBinder
//     where TThis : IValueObject<TValue, TThis>
// {
//     public abstract Task BindModelAsync(ModelBindingContext bindingContext);
//
//     protected Task PerformBinding(ModelBindingContext bindingContext, Action<string> action)
//     {
//         if (!typeof(TThis).IsAssignableFrom(bindingContext.ModelType))
//         {
//             return Task.CompletedTask;
//         }
//
//         var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
//         if (valueProviderResult == ValueProviderResult.None)
//             return Task.CompletedTask;
//
//         var valueString = valueProviderResult.FirstValue;
//         if (valueString is null)
//             return Task.CompletedTask;
//         try
//         {
//             action(valueString);
//
//
//             var result = TThis.Create(valueString);
//             result.Match(
//                 ok => bindingContext.Model = ok,
//                 fail => bindingContext.ModelState.AddModelError(bindingContext.ModelName, fail.Message)
//             );
//             return Task.CompletedTask;
//         }
//         catch (Exception ex)
//         {
//             bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
//         }
//
//         return Task.CompletedTask;
//     }
//
//     private Result<TThis> Parse(string valueString)
//     {
//
//     }
//
//     private Result<R> TryParse<R, T>(T value) where R : IValueObject<T, R>
//     {
//         return R.Create(value);
//     }
// }
//
// // public class StringValueObjectModelBinder<TThis> : ValueObjectModelBinder<string, TThis>
// //     where TThis : IValueObject<string, TThis>
// // {
// //     public override Task BindModelAsync(ModelBindingContext bindingContext)
// //     {
// //         return PerformBinding(bindingContext, (valueString) =>
// //         {
// //             var result = TThis.Create(valueString);
// //             result.Match(
// //                 ok => bindingContext.Model = ok,
// //                 fail => bindingContext.ModelState.AddModelError(bindingContext.ModelName, fail.Message)
// //             );
// //         });
// //     }
// // }
// //
// // public class IntegerValueObjectModelBinder<TValue, TThis> : ValueObjectModelBinder<int, TThis>
// //     where TThis : IValueObject<int, TThis>
// // {
// //     public override Task BindModelAsync(ModelBindingContext bindingContext)
// //     {
// //         return PerformBinding(bindingContext, (valueString) =>
// //         {
// //             var valid = int.TryParse(valueString, out var value);
// //             if (!valid)
// //             {
// //                 bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Could not parse as integer.");
// //             }
// //             else
// //             {
// //                 var result = TThis.Create(value);
// //                 result.Match(
// //                     ok => bindingContext.Model = ok,
// //                     fail => bindingContext.ModelState.AddModelError(bindingContext.ModelName, fail.Message)
// //                 );
// //             }
// //         });
// //     }
// // }