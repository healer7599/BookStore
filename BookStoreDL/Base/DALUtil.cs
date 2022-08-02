using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDL.Base
{
    public class DALUtil
    {
        #region "Declare"

        /// <summary>
        /// Chuỗi kết nối
        /// </summary>
        private string _connString = string.Empty;

        #endregion

        #region "Constructor"

        public DALUtil(string connString)
        {
            _connString = connString;
        }

        #endregion

        #region "Sub/Func"

        /// <summary>
        /// Lấy ra danh sách dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeName"></param>
        /// <param name="dicParam"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public List<T> GetListObjects<T>(string storeName, Dictionary<string, object> dicParam, int timeout = 15)
        {
            var conn = new SqlConnection(_connString);
            var result = new List<T>();

            try
            {
                var command = conn.CreateCommand();

                command.CommandText = storeName;
                command.CommandTimeout = timeout;
                command.CommandType = CommandType.StoredProcedure;

                // xử lý các param truyền cho store
                foreach (var param in dicParam)
                {
                    command.Parameters.AddWithValue($"@{param.Key}", param.Value);
                }

                // mở kết nối
                conn.Open();

                // thực thi
                var dataReader = command.ExecuteReader(CommandBehavior.SingleResult);

                // đọc dữ liệu
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Type type = typeof(T);

                        result.Add((T)MappingObject(type, dataReader));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // đóng kết nối
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return result;
        }

        /// <summary>
        /// Thực thi thủ tục
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="dicParam"></param>
        /// <param name="timeout"></param>
        /// <returns>Số lượng bản ghi ảnh hưởng</returns>
        public int ExecuteNonQuery(string storeName, Dictionary<string, object> dicParam, int timeout = 15)
        {
            var conn = new SqlConnection(_connString);
            var result = 0;

            try
            {
                var command = conn.CreateCommand();

                command.CommandText = storeName;
                command.CommandTimeout = timeout;
                command.CommandType = CommandType.StoredProcedure;

                // xử lý các param truyền cho store
                foreach (var param in dicParam)
                {
                    var pName = $"@{param.Key}";

                    command.Parameters.AddWithValue(pName, param.Value);
                }

                // mở kết nối
                conn.Open();

                // thực thi
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // đóng kết nối
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return result;
        }

        #endregion

        #region "Private"

        /// <summary>
        /// Mapping dữ liệu từ DB
        /// </summary>
        /// <param name="type"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private object MappingObject(Type type, SqlDataReader row)
        {
            var entity = Activator.CreateInstance(type);
            var props = type.GetProperties();

            for (int i = 0; i < row.FieldCount; i++)
            {
                var prop = props.First(x => x.Name == row.GetName(i));
                var value = row.GetValue(i);

                if (prop != null && value != DBNull.Value)
                {
                    prop.SetValue(entity, value);
                }
            }

            return entity;
        }

        #endregion
    }
}
