using BookStoreApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        /// <summary>
        /// Lấy mã chi nhánh
        /// </summary>
        /// <returns></returns>
        [HttpGet("book-store-id")]
        public async Task<IActionResult> GetBookStoreID()
        {
            var result = Environment.GetEnvironmentVariable("MA_CN");

            return Ok(result);
        }
    }
}
