using Entity.BusinessModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BusinessModel
{
    /// <summary>
    /// Sản phẩm
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [Key]
        public string ProductID { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Giá
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Mã nhà sách - FK
        /// </summary>
        [ForeignKey("BookStoreID")]
        public string BookStoreID { get; set; }
    }
}
