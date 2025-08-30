using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Data {
    public class AppDbContext : DbContext{

        //Construtor para inserir as informações de configuração do banco de dados
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Criando o banco de dados chamado DBZ com base na tabela Personagem
        public DbSet<Personagem> DBZ { get; set; }  

        
    }
}
