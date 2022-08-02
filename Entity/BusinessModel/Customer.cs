using Entity.BusinessModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BusinessModel
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    public class Customer : BaseEntity
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Key]
        public string CustomerID { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

    }
}
