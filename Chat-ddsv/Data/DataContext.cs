using Chat_ddsv.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat_ddsv.Data
{
    public class DataContext : DbContext
    {
        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Lista de propriedades de classes de modelo que vão virar as tabelas no banco
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Amigo> Amigos { get; set; }
    }
}