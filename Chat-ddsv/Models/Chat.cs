using System;

namespace Chat_ddsv.Models
{
    public class Chat
    {
        //Construtor
        public Chat() => CreatedAt = DateTime.Now;

        //Atributos
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        //ToString

        public override string ToString() =>
            $"Content: {Content}";
    }
}