using Microsoft.AspNetCore.Mvc;

namespace AsyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HughQueryController : ControllerBase
    {
        [HttpGet]

        //  Async Operation
        //public async Task<IActionResult> Get()
        //{
        //    await Task.Delay(5000);

        //    return Content("Huge Query Data Fetching Completed!");
        //}

        //  Sync Operation
        public Task<IActionResult> Get()
        {
            return Task.Delay(5000).ContinueWith(_ =>
            {
                return (IActionResult)Content("Huge Query Data Fetching Completed!");
            });
        }
    }
}
