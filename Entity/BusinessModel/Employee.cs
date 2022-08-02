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
    /// Nhân viên
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Key]
        public string EmployeeID { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        public string? Position { get; set; }

        /// <summary>
        /// Mã nhà sách - FK
        /// </summary>
        [ForeignKey("BookStoreID")]
        public string BookStoreID { get; set; }

    }
}
