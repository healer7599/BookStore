using System.Data;
using System.Data.SqlClient;
using Entity.ConfigModel;

namespace BookStoreDL.Base
{
    public class BaseDL
    {

        #region "Declare"

        /// <summary>
        /// Đối tượng thao tác dữ liệu
        /// </summary>
        private DALUtil _dal;

        #endregion

        #region "Property"

        public DALUtil DAL
        {
            get { return _dal; }
        }

        #endregion

        #region "Constructor"

        public BaseDL()
        {
            _dal = new DALUtil(GetConnectionString());
        }

        #endregion

        #region "Sub/Func"

        #endregion

        #region "Private"

        /// <summary>
        /// Lấy chuỗi kết nối
        /// </summary>
        /// <returns></returns>
        private string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "";
        }

        #endregion
    }
}
