using DBFirstBack_End.DataAccess;
using DBFirstBack_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseFirstDWB_Sabado.Backend
{
    public class EmployeesSC : Conexion<Employees>
    {
        NorthwindContext dataContext = new NorthwindContext();
        public IQueryable<Employees> GetData()
        {
            return dataContext.Employees.Select(s => s);
        }
        public Employees GetDataByID(int id)
        {
            var employee = GetData().Where(w => w.EmployeeId == id).FirstOrDefault();

            if(employee == null)
            {
                throw new Exception("El id solicitado para el empleado que quieres obtener, no existe");
            }

            return employee;
        }

        public void AddEmployee(EmployeeModel newEmployee)
        {

            var newEmployeeRegister = new Employees() 
            { 
                FirstName = newEmployee.Name, 
                LastName = newEmployee.FamilyName
            };

            dataContext.Employees.Add(newEmployeeRegister);
            dataContext.SaveChanges();

        }

        public void UpdateEmployeeFirstNameById(int id, string newName)
        {
            Employees currentEmployee = GetDataByID(id);

            if (currentEmployee == null)
                throw new Exception("No se encontró el empleado con el ID proporcionado");

            currentEmployee.FirstName = newName;
            dataContext.SaveChanges();
        }

        public void DeleteEmployeeByID(int id)
        {
            var employee = GetDataByID(id);
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();

            if (employee == null)
            {
                throw new Exception("El id solicitado para el empleado que quieres obtener, no existe");
            }
        }
    }
}
