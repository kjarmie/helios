using System.Linq.Expressions;
using System.Reflection;
using Common.Utilities.FunctionalExtensions.ErrorHandling;

namespace Common.Domain.Abstractions;

public interface IValueObject<TValue, TThis>
    where TThis : IValueObject<TValue, TThis>
{
    // public static Result<T> Create(object p) => Error.New($"ValueObject.{typeof(T).Name}",
    //     "Static 'Create' factory method not implemented.");
    /// <summary>
    /// Parses an instance of the ValueObject without performing validation. Useful for conversion on the edge, especially
    /// when parsing from the database where it is assumed that the values are correctly stored.
    /// </summary>
    /// <param name="value">The primitive value to parse.</param>
    /// <returns>A new instance of TTHis</returns>
    public static abstract TThis Parse(TValue value);

    /// <summary>
    /// Creates a new instance of the ValueObject with validation. Very useful when receiving user input.
    /// </summary>
    /// <param name="value">The primitive value to parse.</param>
    /// <returns>A new instance of TTHis wrapped in a Result to indicate if parsing was successful.</returns>
    public static abstract Result<TThis> Create(TValue value);

    /// <summary>
    /// Performs validation logic on the value object. Provides an alternative creation pattern to the Create method
    /// by performing validation on the primitive, then calling Parse to create a new instance. It is recommended
    /// that the Create method uses the same logic as this method.
    /// </summary>
    /// <param name="value">The primitive value to parse.</param>
    /// <returns>A bool indicating if the primitive is a valid ValueObject of type TTHis.</returns>
    public static abstract bool IsValid(TValue value);


}