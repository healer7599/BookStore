using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApi.Model
{
    public class ServiceResult
    {
        private string _data;

        public StatusCode StatusCode { get; set; } = StatusCode.Status200;
        public string Message { get; set; }

        public object Data
        {
            get
            {
                return _data;
            }

            set
            {
                if (value is string)
                {
                    _data = (string)value;
                }
                else
                {
                    _data = JsonConvert.SerializeObject(value);
                }
            }
        }
    }

    public enum StatusCode
    {
        Status200 = 200,
        Status500 = 500
    }
}
