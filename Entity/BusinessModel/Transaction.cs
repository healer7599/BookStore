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
    /// Giao dịch
    /// </summary>
    public class Transaction : BaseEntity
    {
        /// <summary>
        /// Mã giao dịch
        /// </summary>
        [Key]
        public string TransactionID { get; set; }

        /// <summary>
        /// Ngày giao dịch
        /// </summary>
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Mã khách hàng - FK
        /// </summary>
        [ForeignKey("CustomerID")]
        public string CustomerID { get; set; }

        /// <summary>
        /// Mã nhân viên - FK
        /// </summary>
        [ForeignKey("EmployeeID")]
        public string EmployeeID { get; set; }

    }
}
