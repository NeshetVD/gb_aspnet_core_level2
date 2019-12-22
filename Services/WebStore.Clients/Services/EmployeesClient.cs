using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Clients.Services
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        protected override string ServiceAddress { get; } = "api/employees";

        public EmployeesClient(IConfiguration configuration) : base(configuration)
        {
        }

        public void AddNew(EmployeeView model)
        {
            string url = $"{ServiceAddress}";
            Post(url, model);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            string url = $"{ServiceAddress}/{id}";
            Delete(url);
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            string url = $"{ServiceAddress}";
            return Get<List<EmployeeView>>(url);
        }

        public EmployeeView GetById(int id)
        {
            string url = $"{ServiceAddress}/{id}";
            return Get<EmployeeView>(url);
        }

        public EmployeeView UpdateEmployee(int id, EmployeeView entity)
        {
            string url = $"{ServiceAddress}/{id}";
            return Put(url, entity).Content.ReadAsAsync<EmployeeView>().Result;
        }
    }
}
