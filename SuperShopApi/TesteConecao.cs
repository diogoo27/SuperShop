using System;
using Microsoft.EntityFrameworkCore;
using SuperShopApi.Data;

class TesteConexao
{
    public static void Main()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SuperShopDb;Trusted_Connection=True;TrustServerCertificate=True;");

        using var context = new AppDbContext(optionsBuilder.Options);

        if (context.Database.CanConnect())
        {
            Console.WriteLine("Conectou ao banco com sucesso!");
        }
        else
        {
            Console.WriteLine("Não conseguiu conectar.");
        }
    }
}
