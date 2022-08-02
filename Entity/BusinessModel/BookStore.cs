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
    /// Nhà sách
    /// </summary>
    public class BookStore : BaseEntity
    {
        /// <summary>
        /// Mã nhà sách
        /// </summary>
        [Key]
        public string BookStoreID { get; set; }

        /// <summary>
        /// Tên nhà sách
        /// </summary>
        public string BookStoreName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

    }
}
