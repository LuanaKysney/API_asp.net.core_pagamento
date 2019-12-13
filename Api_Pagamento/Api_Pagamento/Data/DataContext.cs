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
        public DbSet<Models.Bandeiras_cartao_credito> bandeiras_Cartao_Creditos { get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.CustomerClient>().HasData(
                new Models.CustomerClient() {
                    customerId = Guid.Parse(""),
                    first_name = "Naruto Raposa de 9 caldas",
                    taxpayer_id = "09865425555",
                    email = "testeApi@gmail.com",
                    address = new Models.CustomerClient.Address() {
                        line1 = "complemento",
                        neighborhood = "ceilandia",
                        city = "sol nascente",
                        state = "brasília",
                        postal_code = "72236800",
                        country_code = "brasília"
                    }
                });
                }
        }
    }
