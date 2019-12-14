using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pagamento.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base (options)
        {

        }
        public DbSet<Models.CustomerClient> customerClients { get; set; }
        public DbSet<Models.Json_boleto> json_Boletos { get; set; }
        public DbSet<Models.Bandeiras_cartao_credito> bandeiras_Cartao_Creditos { get; set; }
        public DbSet<Models.AddressClient> addressClients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.CustomerClient>().HasData(
                new Models.CustomerClient() {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    addressId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    first_name = "Naruto Shippuden ",
                    taxpayer_id = "09865425555",
                    email = "testeApi@gmail.com",


                }) ;
            modelBuilder.Entity<Models.AddressClient>().HasData(
                 new Models.AddressClient() {
                     Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),  
                     line1 = "complemento",
                     neighborhood = "ceilandia",
                     city = "Vilarejo",
                     state = "brasília",
                     postal_code = "72236800",
                     country_code = "brasília"
                 }) ;
            base.OnModelCreating(modelBuilder);
        }
        }
    }
