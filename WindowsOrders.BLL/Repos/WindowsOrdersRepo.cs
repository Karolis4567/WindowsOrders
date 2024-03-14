using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using WindowsOrders.BLL.Extensions;
using WindowsOrders.BLL.Repos.Dtos;
using WindowsOrders.DAL.Contexts;
using WindowsOrders.DAL.Contexts.Entities;

namespace WindowsOrders.BLL.Repos
{
    public class WindowsOrdersRepo : IWindowsOrdersRepo
    {
        protected WindowsOrdersContext windowsOrdersContext;
        public WindowsOrdersRepo(WindowsOrdersContext windowsOrdersContext) 
        {
            this.windowsOrdersContext = windowsOrdersContext;
        }

        

        public async Task<int> SaveOrderAsync(OrderDto newOrder)
        {
            var ret = 0;
            if (newOrder == null) return ret;
            
            if (newOrder.id > 0)
            {
                var result = await this.windowsOrdersContext
                    .Orders
                    .Include(x => x.states)
                    .Include(x => x.ordersWindows)
                    .Include("ordersWindows.ordersWindowsItems")
                    .FirstOrDefaultAsync(x => x.id == newOrder.id);
                
                if (result != null)
                {
                    result.name = newOrder.name;
                    result.statesId = newOrder.stateId;
                    result.ordersWindows = ConvertToOrdersWindows(newOrder.windows.ToList());
                    await this.windowsOrdersContext.SaveChangesAsync();
                    ret = newOrder.id;
                }
            } 
            else
            {
                try
                {
                    var order = new Orders();
                    order.statesId = newOrder.stateId;
                    order.name = newOrder.name;
                    order.ordersWindows = ConvertToOrdersWindows(newOrder.windows.ToList());
                    await this.windowsOrdersContext.Orders.AddAsync(order);
                    await this.windowsOrdersContext.SaveChangesAsync();
                    ret = order.id;
                } catch (Exception ex) 
                {
                    int stopHere = 0;
                }
            }          
            
            return ret;
        }

        private List<OrdersWindows> ConvertToOrdersWindows(List<OrderWindowDto> windows)
        { 
            var ret = new List<OrdersWindows>();
            if (windows == null || windows.Count == 0) return ret;
            var cnt = windows.Count;

            for (int i = 0; i < cnt; i++)
            {
                var window = new OrdersWindows();
                if (!windows[i].isNew) window.id = windows[i].id;
                window.name = windows[i].name;
                window.quantity = windows[i].quantity;
                window.ordersWindowsItems = this.ConvertToOrdersWindowsItems(windows[i].items.ToList());
                ret.Add(window);
            }

            return ret;
        }
        private List<OrdersWindowsItems> ConvertToOrdersWindowsItems(List<OrderWindowItemDto> items)
        {
            var ret = new List<OrdersWindowsItems>();
            if (items == null || items.Count == 0) return ret;
            var cnt = items.Count;
            
            for (int i = 0; i < cnt; i++)
            {
                var item = new OrdersWindowsItems()
                {                    
                    order = items[i].order,
                    typeId = items[i].typeId,
                    width = items[i].width,
                    height = items[i].height,   
                };
                if (!items[i].isNew) item.id = items[i].id;

                ret.Add(item);                         
            }
            return ret;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var result = await this.windowsOrdersContext.Orders.FirstOrDefaultAsync(x => x.id == id);
            if (result != null)
            {
                this.windowsOrdersContext.Remove(result);
                await this.windowsOrdersContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        private IQueryable<Orders> baseForOrdersQuery =>
            this.windowsOrdersContext.Orders
                 .AsNoTracking()
                 .Include(x => x.states)
                 .Include(x => x.ordersWindows)
                 .Include("ordersWindows.ordersWindowsItems")
                 .AsQueryable();
        

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
           

           return await this.baseForOrdersQuery
                 .Select(x => new OrderDto()
                 {
                     id = x.id,
                     name = x.name, 
                     createDate = x.createDate, 
                     stateId = x.statesId,
                     stateName = x.states.name,
                     stateCode = x.states.code,
                     windows = x.ordersWindows.Select(x => 
                        new OrderWindowDto()
                        {
                            id = x.id, name = x.name, quantity = x.quantity, 
                            items = x.ordersWindowsItems.Select(x => new OrderWindowItemDto()
                            { 
                                id = x.id,
                                height = x.height,
                                order = x.order,
                                typeId=x.typeId,
                                typeName = x.types.name,
                                width = x.width 
                            }).ToArray()
                        }).ToArray()    
                     
                 })
                 .OrderByDescending(x => x.id)
                 .ToArrayAsync();
        }
            

        public async Task<OrderDto> GetOrderAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await this.baseForOrdersQuery
                    .Select(x => new OrderDto()
                    {
                        id = x.id,
                        name = x.name,
                        createDate = x.createDate,
                        stateId = x.statesId,
                        stateName = x.states.name,
                        stateCode = x.states.code,
                        windows = x.ordersWindows.Select(x =>
                           new OrderWindowDto()
                           {
                               id = x.id,
                               name = x.name,
                               quantity = x.quantity,
                               items = x.ordersWindowsItems.Select(x => new OrderWindowItemDto()
                               {
                                   id = x.id,
                                   height = x.height,
                                   order = x.order,
                                   typeId = x.typeId,
                                   typeName = x.types.name,
                                   width = x.width
                               }).ToArray()
                           }).ToArray()

                    })
                   .FirstOrDefaultAsync(x => x.id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    
    }
}
