using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pagamento.Models;

namespace Api_Pagamento.Services
{
    public class CustomerClientRepository : ICustomerClient, IDisposable
    {

        private readonly Data.DataContext _context;

        public CustomerClientRepository (Data.DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCustomer(CustomerClient customer)
        {
            throw new NotImplementedException();
        }
        //Criando um boleto
        public void AddJson_boleto(Guid customerId, Json_boleto boleto)
        {

            if (customerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            if (boleto == null)
            {
                throw new ArgumentNullException(nameof(Json_boleto));
            }
            // always set the AuthorId to the passed-in authorId
            boleto.customerId = customerId;
            _context.json_Boletos.Add(boleto);
        }

        public bool CustomerExists(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(CustomerClient customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteJson_boleto(Json_boleto id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerClient> GetCustomerClient()
        {
            throw new NotImplementedException();
        }

        public CustomerClient GetCustomerClient(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerClient> GetCustomerClients(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerClient> GetCustomerClients(IEnumerable<Guid> customerId)
        {
            throw new NotImplementedException();
        }

        public Json_boleto GetJson_boleto(Guid customerId, Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(CustomerClient customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateJson_boleto(Json_boleto iD)
        {
            throw new NotImplementedException();
        }
    }
}
