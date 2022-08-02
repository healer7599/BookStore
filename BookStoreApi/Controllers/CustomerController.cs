using BookStoreApi.Model;
using BookStoreBL;
using Entity.BusinessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("{searchText?}")]
        public async Task<IActionResult> GetCustomer(string? searchText)
        {
            var result = new CustomerBL().GetCustomer(searchText ?? string.Empty);

            return Ok(result);
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> InsertCustomer([FromBody] Customer cus)
        {
            var result = new CustomerBL().InsertCustomer(cus);

            return Ok(result);
        }

        /// <summary>
        /// Xoá khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        [HttpDelete("{customerID}")]
        public async Task<IActionResult> DeleteCustomer(string customerID)
        {
            var result = new CustomerBL().DeleteCustomer(customerID);

            return Ok(result);
        }
    }
}
