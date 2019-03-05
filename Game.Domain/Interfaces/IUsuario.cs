using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Domain.Interfaces
{
    public interface IUsuario
    {
        Guid Id { get; set; }
        string Username { get; set; }
        string Senha { get; set; }
    }
}
