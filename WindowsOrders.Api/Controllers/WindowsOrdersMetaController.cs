using Microsoft.AspNetCore.Mvc;
using WindowsOrders.BLL.Repos;

namespace WindowsOrders.Api.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class WindowsOrdersMetaController : Controller
    {
        protected IWindowsOrdersMetaRepo repo;
        public WindowsOrdersMetaController(IWindowsOrdersMetaRepo windowsOrdersRepo)
        {
            this.repo = windowsOrdersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatesAsync()
        {
            var result = await this.repo.GetStatesAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTypesAsync()
        {
            var result = await this.repo.GetTypesAsync();
            return Ok(result);  
        }

       
    }
}
