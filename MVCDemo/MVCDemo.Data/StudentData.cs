using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//using MVCDemo.Models;


namespace MVCDemo.Data
{
    public class StudentData : DataObject
    {
       
        public class Student
        {
            public int SId;
            public string FirstName;
            public string LastName;
            public int EnrollmentNo;
            public string Email;
            public string Address;
            public int PhoneNo;
        }
        //To Add Student details    
        public bool AddStudent(Student obj)
        {

            //  connection();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("spAddStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@EnrollmentNo", obj.EnrollmentNo);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@PhoneNo", obj.PhoneNo);

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

        //public bool AddStudent(MVCDemo.Models.Student stu)
        //{
        //    throw new NotImplementedException();
        //}


        //To view Student details with generic list     
        public List<Student> GetAllStudents()
        {
            //connection();
            SqlConnection con = new SqlConnection(ConnectionString);
            List<Student> StuList = new List<Student>();

            
            SqlCommand com = new SqlCommand("spGetAllStudents", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                StuList.Add(

                    new Student
                    {
                        SId = Convert.ToInt32(dr["SId"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        EnrollmentNo = Convert.ToInt32(dr["EnrollmentNo"]),
                        Email = Convert.ToString(dr["Email"]),
                        Address = Convert.ToString(dr["Address"]),
                        PhoneNo = Convert.ToInt32(dr["PhoneNo"]),


                    }


                    );


            }

            return StuList;


        }
        //To Update Student details    
        public bool UpdateStudent(Student obj)
        {

            // connection();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("spUpdateStudentDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SId", obj.SId);
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@EnrollmentNo", obj.EnrollmentNo);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@PhoneNo", obj.PhoneNo);
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
        //To delete Student details    
        public bool DeleteStudent(int Id)
        {
            //connection();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("spDeleteStudentById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SId", Id);

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