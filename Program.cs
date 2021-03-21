using System;
using System.Linq;
using DatabaseFirstDWB_Sabado.Backend;
using DBFirstBack_End.DataAccess;

namespace DBFirstBack_End
{
    class Program
    {
        public static NorthwindContext dataContext = new NorthwindContext();
        public static void Excercise1()
        {
            //Select *from Employees

            var employeeQry = dataContext.Employees.AsQueryable();
            //Ambas formas es lo mismo
            var employeeQry_alt = dataContext.Employees.Select(s => s);
            var output = employeeQry.ToList();
        }

        public static void Ejercicio2()
        {
            //SELECT Title, FirstName, LastName FROM Employees WHERE Title = 'Sales'

            var dbContext = new DataAccess.NorthwindContext();
            var employeeQry = dbContext.Employees.Select(s => new
            {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title == "Sales Representative");

            var output = employeeQry.ToList();

            output.ForEach(fe => Console.WriteLine("Nombre: " + fe.FirstName));

        }

        public static void Ejercicio3()
        {
            //SELECT Title, FirstName, LastName FROM Employees WHERE Title = 'Sales Representative'

            //var employee = new EmployeeModel() { Name = "Rolando", Age = 21 };
            var dbContext = new DataAccess.NorthwindContext();

            //A un objeto Lambda que se le asigna sobre un objeto anonimo o 
            //un objeto no anonimo, se le llama proyección
            var employeeQry = dbContext.Employees.Where(w => w.Title == "Sales Representative").Select(s => new
            {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title
            });

            var output = employeeQry.ToList();
        }

        public static void Excercise4(int id = 1)
        {
            //UPDATE Employees SET NAME = 'Alejandra' WHERE ID = 1;
            Employees currentEmployee = getEmpleadoById(id);

            if (currentEmployee == null)
                throw new Exception("No se encontró empleado con el ID proporcionado");

            currentEmployee.FirstName = "Alejandra";
            dataContext.SaveChanges();

        }

        private static Employees getEmpleadoById(int id)
        {
            return dataContext.Employees.Where(w => w.EmployeeId == id).FirstOrDefault();
        }

        public static void Excercise5(int id = 1)
        {
            //Insertar nuevo producto en la tabla de productos
            var newProduct = new Products();
            newProduct.ProductName = "Jugo del Valle";
            newProduct.UnitPrice = 15.50m;

            dataContext.Products.Add(newProduct);
            dataContext.SaveChanges();
        }

        public static void Excercise6(int id = 1)
        {
            //UPDATE Employees SET NAME = 'Alejandra' WHERE ID = 1;
            Employees currentEmployee = getEmpleadoById(id);

            if (currentEmployee == null)
                throw new Exception("No se encontró empleado con el ID proporcionado");

            dataContext.Employees.Remove(currentEmployee);
            dataContext.SaveChanges();

            //Para borrar todos

        }

        public void Excercise7(int orderID = 10248)
        {
            var qry = dataContext.Orders.Where(w => w.OrderId == orderID)
                .Select(s => new
                {
                    Cliente = s.Customer.CompanyName,
                    Vendedor = s.Employee.FirstName,
                    Productos = s.OrderDetails.Select(se => se.Product.ProductName)
                });

            var result = qry.ToList();
        }

        public static CategoriesSC categoriesService = new CategoriesSC();

        public static void Tarea2()
        {
            var output = categoriesService.GetData().ToList();
        }
        static void Main(string[] args)
        {
            //Excercise1();
            //Ejercicio2();
            //Ejercicio3();
            //Excercise4(id: 1); si no inicializas parametro
            //Excercise4();
            //Excercise5();
            //Excercise6();
            //Excercise7();
            Tarea2();
            Console.WriteLine("Hello World!");
        }
    }
}
