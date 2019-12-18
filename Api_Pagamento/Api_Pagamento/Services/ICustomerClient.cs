using Api_Pagamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Pagamento.Services
{
    interface ICustomerClient
    {
        IEnumerable<Models.CustomerClient> GetCustomerClients(Guid id);
        Json_boleto GetJson_boleto(Guid customerId, Guid id);
        void AddJson_boleto(Guid customerId, Json_boleto id);
        void UpdateJson_boleto(Json_boleto iD);
        void DeleteJson_boleto(Json_boleto id);
        IEnumerable<CustomerClient> GetCustomerClient();
        //IEnumerable<CustomerClient> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        CustomerClient GetCustomerClient(Guid customerId);
        IEnumerable<CustomerClient> GetCustomerClients(IEnumerable<Guid> customerId);
        void AddCustomer(CustomerClient customer);
        void DeleteCustomer(CustomerClient customer);
        void UpdateCustomer(CustomerClient customer);
        bool CustomerExists(Guid customerId);
        bool Save();
    }
}
