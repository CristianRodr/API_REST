using System.Text.RegularExpressions;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;

public record CorreoElectronico
{
    public string Value { get; init; }

    private CorreoElectronico(string value)
    {
        Value = value;  
    } 
    
    public static implicit operator string(CorreoElectronico correoElectronico) => correoElectronico.Value;

    public static Result<CorreoElectronico> Create(string _value)
    {
        if (EsCorreoValido(_value))
        {
            return new CorreoElectronico(_value);
        }
        throw new InvalidOperationException("El correo electrónico no es válido.");
    }

    private static bool EsCorreoValido(string correo)
    {
        const string emailRegex = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
        if (string.IsNullOrEmpty(correo))
        {
            return false;
        }
        
        var esCorrecto = Regex.Match(correo, emailRegex).Success;

        if (esCorrecto)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}