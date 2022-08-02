using BookStoreDL.Base;
using Entity.BusinessModel;
using Entity.ConfigModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDL
{
    public class EmployeeDL : BaseDL
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<Employee> GetEmployee(string searchText)
        {
            var param = new Dictionary<string, object>();

            param.Add("SearchText", searchText);

            return DAL.GetListObjects<Employee>("dbo.Proc_GetEmployee", param);
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int InsertEmployee(Employee emp)
        {
            var param = new Dictionary<string, object>();

            param.Add("EmployeeID", emp.EmployeeID);
            param.Add("EmployeeName", emp.EmployeeName);
            param.Add("UserName", emp.UserName ?? string.Empty);
            param.Add("Password", emp.Password ?? string.Empty);
            param.Add("Position", emp.Position ?? string.Empty);
            param.Add("BookStoreID", emp.BookStoreID);

            return DAL.ExecuteNonQuery("dbo.Proc_InsertEmployee", param);
        }

        /// <summary>
        /// Xoá nhân viên
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int DeleteEmployee(string employeeID)
        {
            var param = new Dictionary<string, object>();

            param.Add("EmployeeID", employeeID);

            return DAL.ExecuteNonQuery("dbo.Proc_DeleteEmployee", param);
        }
    }
}
