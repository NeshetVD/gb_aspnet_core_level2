using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryEmployeeData : IEmployeesData
    {
        private readonly List<EmployeeView> _employees;

        public InMemoryEmployeeData()
        {
            _employees = new List<EmployeeView>
            {
                new EmployeeView
                {
                    Id = 1,
                    FirstName = "Иван",
                    SurName = "Иванов",
                    Patronymic = "Иванович",
                    Age = 22
                },
                new EmployeeView
                {
                    Id = 2,
                    FirstName = "Владислав",
                    SurName = "Петров",
                    Patronymic = "Иванович",
                    Age = 35
                }
            };
        }

        public void AddNew(EmployeeView model)
        {
            if (model == null)
                throw new ArgumentException(nameof(model));

            model.Id = _employees.Max(x=> x.Id) + 1;
            _employees.Add(model);
        }

        public void Commit()
        {
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }

        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public EmployeeView UpdateEmployee(int id, EmployeeView entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity));

            var employee = _employees.FirstOrDefault(x => x.Id == entity.Id);
            if (employee == null)
                throw new InvalidOperationException("No employee found");

            // fill fields of model
            employee.Id = entity.Id;
            employee.FirstName = entity.FirstName;
            employee.SurName = entity.SurName;
            employee.Patronymic = entity.Patronymic;
            employee.Age = entity.Age;
            employee.Position = entity.Position;

            return employee;
        }
    }
}
