using System.Collections.Generic;

namespace ServeRestSharp.Responses.Users;

public class GetUsersSuccessfully
{
    public int Quantidade { get; set; }
    public List<Usuario>? Usuarios { get; set; }
}

public class Usuario
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Administrador { get; set; }
    public string? _Id { get; set; }
}
