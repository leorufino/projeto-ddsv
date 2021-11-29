using System;

namespace Chat_ddsv.Models
{
    public class Amigo
    {
        //Construtor
        public Amigo() => CreatedAt = DateTime.Now;

        //Atributos
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public int AmigoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        //ToString
        public override string ToString() =>
            $"Nome: {Nome}";
    }
}