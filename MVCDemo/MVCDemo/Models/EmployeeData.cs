using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemo.Data;

namespace MVCDemo.Models
{
    public class EmployeeData : DataObject
    {
        //private SqlConnection con;
        ////To Handle connection related activities    
        //private void connection()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["DCN"].ToString();
        //    con = new SqlConnection(constr);

        //   // string _connectionString = ConfigurationManager.ConnectionStrings["DCN"].ConnectionString;

        //}
        //To Add Employee details    
        public bool AddEmployee(Employee obj)
        {

            //connection();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("spAddEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@Department", obj.Department);
            com.Parameters.AddWithValue("@City", obj.City);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }



        //To view employee details with generic list     
        public List<Employee> GetAllEmployees()
        {
            //connection();
            SqlConnection con = new SqlConnection(ConnectionString);
            List<Employee> EmpList = new List<Employee>();


            SqlCommand com = new SqlCommand("spGetAllEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new Employee
                    {
                        EmpId = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Department = Convert.ToString(dr["Department"]),
                        City = Convert.ToString(dr["City"])

                    }


                    );


            }

            return EmpList;


        }
        //To Update Employee details    
        public bool UpdateEmployee(Employee obj)
        {

            //connection();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("spUpdateEmployee", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.EmpId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@Department", obj.Department);
            com.Parameters.AddWithValue("@City", obj.City);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To delete Employee details    
        public bool DeleteEmployee(int Id)
        {

            //connection();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("spDeleteEmployee", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

    }
}