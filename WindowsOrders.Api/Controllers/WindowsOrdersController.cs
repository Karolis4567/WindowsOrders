using Microsoft.AspNetCore.Mvc;
using WindowsOrders.BLL.Repos;
using WindowsOrders.BLL.Repos.Dtos;

namespace WindowsOrders.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WindowsOrdersController : Controller
    {
        protected IWindowsOrdersRepo repo;
        public WindowsOrdersController(IWindowsOrdersRepo windowsOrdersRepo)
        {
            this.repo = windowsOrdersRepo;
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrderAsync([FromBody] OrderDto newOrder)
        { 
            var result = await this.repo.SaveOrderAsync(newOrder);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var result = await this.repo.GetAllOrdersAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var result = await this.repo.GetOrderAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400);
            }
            
            
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var ret = await this.repo.DeleteOrderAsync(id);
            if (ret)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }
        
       
    }
}
