using DBFirstBack_End.DataAccess;
using DBFirstBack_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseFirstDWB_Sabado.Backend
{
    public class OrdersSC : Conexion<OrderDetails>
    {
        NorthwindContext dataContext = new NorthwindContext();

        public IQueryable<OrderDetails> GetData()
        {
            return dataContext.OrderDetails.Select(s => s);
        }

        public OrderDetails GetDataByID(int id)
        {
            var order = GetData().Where(w => w.OrderId == id).FirstOrDefault();
            if (order == null)
            {
                throw new Exception("No se encontró el ID de la orden, por favor asegurese de haber tecleado el correcto");
            }
            return order;
        }

        public void AddOrder(OrderDetailsModel newOrder)
        {
            var newOrderRegister = new OrderDetails()
            {
                OrderId = newOrder.OrderID,
                ProductId = newOrder.ProductID,
                UnitPrice = newOrder.UnitPri,
                Quantity = newOrder.Quantity
            };
            dataContext.OrderDetails.Add(newOrderRegister);
            dataContext.SaveChanges();
        }

        public void UpdateQuantityOrderById(int id, short newQuantity)
        {
            OrderDetails currentOrder = GetDataByID(id);

            if (currentOrder == null)
                throw new Exception("No se encontró la orden con el ID proporcionado");

            currentOrder.Quantity = newQuantity;
            dataContext.SaveChanges();
        }

        public void DeleteOrderById(int id)
        {
            var order = GetDataByID(id);
            if(order == null)
            {
                throw new Exception("No se encontro el ID especificado, la orden no existe");
            }
            dataContext.OrderDetails.Remove(order);
            dataContext.SaveChanges();
        }
    }
}
