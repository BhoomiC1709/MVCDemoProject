using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCDemo.Data
{
    public class DataObject
    {
        public DataObject()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DCN"].ConnectionString;
        }

        //public DataObject()
        //{
        //}

        private string _connectionString;

        //public string ConnectionString
        //{
        //    get { return _connectionString; }
        //}
        public string ConnectionString => _connectionString;
    }
}