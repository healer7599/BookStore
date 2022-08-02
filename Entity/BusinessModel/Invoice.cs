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
    /// Hoá đơn
    /// </summary>
    public class Invoice : BaseEntity
    {
        /// <summary>
        /// Mã hoá đơn
        /// </summary>
        [Key]
        public string InvoiceID { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Tổng số tiền
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// Kiểu thanh toán
        /// </summary>
        public string PayType { get; set; }

        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [ForeignKey("ProductID")]
        public string ProductID { get; set; }

        /// <summary>
        /// Mã giao dịch
        /// </summary>
        [ForeignKey("TransactionID")]
        public string TransactionID { get; set; }
    }
}
