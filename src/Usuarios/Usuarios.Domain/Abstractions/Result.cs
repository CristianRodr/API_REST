using System.Diagnostics.CodeAnalysis;

namespace Usuarios.Domain.Abstractions;

public class Result
{
    protected internal Result(bool IsSuccess, Error error)
    {
        if (IsSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!IsSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }
        IsSuccess = IsSuccess;
        Error = error;
    }
    
    public bool IsSuccess { get; }
    public Error Error { get; }
    
    public bool IsFailure => !IsSuccess;
    
    public static Result Success() => new Result(true, Error.None);
    
    public static Result Failure(Error error) => new Result(false, error);
    
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false,error); 
    
    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }
    
    [NotNull]
    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("El resulto no se ha enviado");
    
    public static implicit operator Result<TValue>(TValue value) => Create(value);
}