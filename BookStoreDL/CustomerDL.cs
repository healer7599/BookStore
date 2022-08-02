using BookStoreDL.Base;
using Entity.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDL
{
    public class CustomerDL : BaseDL
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<Customer> GetCustomer(string searchText)
        {
            var param = new Dictionary<string, object>();

            param.Add("SearchText", searchText);

            return DAL.GetListObjects<Customer>("dbo.Proc_GetCustomer", param);
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public int InsertCustomer(Customer cus)
        {
            var param = new Dictionary<string, object>();

            param.Add("CustomerID", cus.CustomerID);
            param.Add("CustomerName", cus.CustomerName);
            param.Add("Address", cus.Address ?? string.Empty);
            param.Add("PhoneNumber", cus.PhoneNumber ?? string.Empty);

            return DAL.ExecuteNonQuery("dbo.Proc_InsertCustomer", param);
        }
    }
}
