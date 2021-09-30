using System;

namespace Chat_ddsv.Models
{
    public class Usuario
    {
        //Construtor
        public Usuario() => CreatedAt = DateTime.Now;

        //Atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public DateTime CreatedAt { get; set; }

        //ToString

        public override string ToString() =>
            $"Nome: {Nome}";
    }
}