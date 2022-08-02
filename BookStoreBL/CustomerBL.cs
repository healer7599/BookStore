using BookStoreDL;
using Entity.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreBL
{
    public class CustomerBL
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<Customer> GetCustomer(string searchText)
        {
            return new CustomerDL().GetCustomer(searchText);
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public int InsertCustomer(Customer cus)
        {
            return new CustomerDL().InsertCustomer(cus);
        }

        /// <summary>
        /// Xoá khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public int DeleteCustomer(string customerID)
        {
            return new CustomerDL().DeleteCustomer(customerID);
        }
    }
}
