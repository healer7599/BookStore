using BookStoreApi.Model;
using BookStoreBL;
using Entity.BusinessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("{searchText?}")]
        public async Task<IActionResult> GetEmployee(string? searchText)
        {
            var result = new EmployeeBL().GetEmployee(searchText ?? string.Empty);

            return Ok(result);
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee emp)
        {
            var result = new EmployeeBL().InsertEmployee(emp);

            return Ok(result);
        }

        /// <summary>
        /// Xoá nhân viên
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        [HttpDelete("{employeeID}")]
        public async Task<IActionResult> DeleteEmployee(string employeeID)
        {
            var result = new EmployeeBL().DeleteEmployee(employeeID);

            return Ok(result);
        }
    }
}
