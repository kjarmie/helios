// using Common.Domain.Abstractions;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
//
// namespace Webapp.ModelBinders;
//
// public class ValueObjectModelBinder<TValue, TThis> : IModelBinder
//     where TThis : IValueObject<TValue, TThis>
// {
//     public static ValueObjectModelBinder<TValue, TThis> Create(TValue value, TThis @this)
//     {
//         return new ValueObjectModelBinder<TValue, TThis>();
//     }
//
//     public Task BindModelAsync(ModelBindingContext bindingContext)
//     {
//         var modelName = bindingContext.ModelName;
//         var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
//
//         if (valueProviderResult == ValueProviderResult.None)
//             return Task.CompletedTask;
//
//         var value = valueProviderResult.FirstValue;
//
//         TValue? convertedValue;
//         try
//         {
//             convertedValue = (TValue?)Convert.ChangeType(value, typeof(TValue));
//         }
//         catch (Exception ex)
//         {
//             bindingContext.ModelState.AddModelError(modelName, "Invalid value type");
//             return Task.CompletedTask;
//         }
//
//         if (convertedValue is null)
//         {
//             bindingContext.ModelState.AddModelError(modelName, "No value");
//             return Task.CompletedTask;
//         }
//
//         var result = TThis.Create(convertedValue);
//
//         result.Match(
//             ok => bindingContext.Result = ModelBindingResult.Success(ok),
//             fail => bindingContext.ModelState.AddModelError(modelName, fail.Message)
//         );
//
//         return Task.CompletedTask;
//     }
// }