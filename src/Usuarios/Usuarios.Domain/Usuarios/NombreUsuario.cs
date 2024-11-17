namespace Usuarios.Domain.Usuarios;

public record NombreUsuario
{
    public string Value { get; init; }

    private NombreUsuario()
    {
        Value = Value;
    }

    public static NombreUsuario Create(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("Nombre de usuario no puede estar vacio.", nameof(nombre));
        }

        return new NombreUsuario();
    }
}