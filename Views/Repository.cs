using Microsoft.EntityFrameworkCore;

namespace Repository

{

  public class Context : DbContext


  {


    public DbSet<Models.Produto> Produtos { get; set; }

    public DbSet<Models.Almoxarifado> Almoxarifados { get; set; }

    public DbSet<Models.Saldo> Saldos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)



    {

      string conn = "Server=localhost;User Id=root;Database=products";      

      ServerVersion version = ServerVersion.AutoDetect(conn);

      optionsBuilder.UseMySql(conn, version);

    }




  }




}