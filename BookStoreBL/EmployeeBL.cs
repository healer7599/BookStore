using BookStoreDL;
using Entity.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBL
{
    public class EmployeeBL
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<Employee> GetEmployee(string searchText)
        {
            return new EmployeeDL().GetEmployee(searchText);
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int InsertEmployee(Employee emp)
        {
            return new EmployeeDL().InsertEmployee(emp);
        }
    }
}
