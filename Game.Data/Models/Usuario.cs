using Game.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Data.Models
{
    public class Usuario : IUsuario
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
    }
}
