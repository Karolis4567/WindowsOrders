using Microsoft.EntityFrameworkCore;
using WindowsOrders.BLL.Repos.Dtos;
using WindowsOrders.DAL.Contexts;

namespace WindowsOrders.BLL.Repos
{
    public class WindowsOrdersMetaRepo : IWindowsOrdersMetaRepo 
    {
        private WindowsOrdersContext windowsOrdersContext;
        public WindowsOrdersMetaRepo(WindowsOrdersContext windowsOrdersContext) 
        {
            this.windowsOrdersContext = windowsOrdersContext;   
        }

        public async Task<IEnumerable<StatesDto>> GetStatesAsync()
        {
            return await this.windowsOrdersContext.States.Select(x => new StatesDto()
            {
                id = x.id
                , code = x.code   
                , name = x.name
            }).ToArrayAsync();    
        }

        public async Task<IEnumerable<TypesDto>> GetTypesAsync()
        {
            return await this.windowsOrdersContext
                .OrdersWindowsItemsTypes
                .Select(x => new TypesDto()
                {
                    id = x.id, name = x.name    
                })
                .ToArrayAsync();
        }

    }
}
