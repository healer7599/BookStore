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
        /// <param name="empID"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [Route("{searchText?}")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee(string? searchText)
        {
            var result = new ServiceResult();

            try
            {
                result.Data = new EmployeeBL().GetEmployee(searchText ?? string.Empty);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

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
            var result = new ServiceResult();

            try
            {
                result.Data = new EmployeeBL().InsertEmployee(emp);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return Ok(result);
        }
    }
}
