using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Pagamento.Models;

namespace Api_Pagamento.Services
{
    public class CustomerClientRepository : ICustomerClient, IDisposable
    {
        public void AddCustomer(CustomerClient customer)
        {
            throw new NotImplementedException();
        }

        public void AddJson_boleto(Guid customerId, Json_boleto id)
        {
            throw new NotImplementedException();
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
