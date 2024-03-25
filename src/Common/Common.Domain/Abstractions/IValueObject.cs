using System.Linq.Expressions;
using System.Reflection;
using Common.Utilities.FunctionalExtensions.ErrorHandling;

namespace Common.Domain.Abstractions;

public interface IValueObject
{
}

public interface IValueObject<TValue, TThis> : IValueObject
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
}