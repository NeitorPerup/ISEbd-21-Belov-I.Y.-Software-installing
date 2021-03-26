using System;
using System.Collections.Generic;
using System.Text;
using SoftwareInstallingBuisnessLogic.Interfaces;
using SoftwareInstallingBuisnessLogic.ViewModels;
using SoftwareInstallingBuisnessLogic.BindingModels;
using System.Linq;
using SoftwareInstallingDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareInstallingDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new SoftwareInstallingDatabase())
            {
                return context.Orders.Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    PackageName = context.Packages.Include(x => x.Order).FirstOrDefault(r => r.Id == rec.PackageId).PackageName,
                    PackageId = rec.PackageId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId
                })
                .ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SoftwareInstallingDatabase())
            {
                return context.Orders
                .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate == model.DateCreate) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date
                >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date))         
                .Select(rec => new OrderViewModel
                 {
                    Id = rec.Id,
                    PackageName = context.Packages.Include(x => x.Order).FirstOrDefault(r => r.Id == rec.PackageId).PackageName,
                    PackageId = rec.PackageId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId
                })
                .ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SoftwareInstallingDatabase())
            {
                var order = context.Orders
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    PackageName = context.Packages.Include(x => x.Order).FirstOrDefault(r => r.Id == order.PackageId)?.PackageName,
                    PackageId = order.PackageId,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    ClientId = order.ClientId
                } :
                null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new SoftwareInstallingDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new SoftwareInstallingDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new SoftwareInstallingDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PackageId = model.PackageId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.ClientId = (int)model.ClientId;
            return order;
        }
    }
}
