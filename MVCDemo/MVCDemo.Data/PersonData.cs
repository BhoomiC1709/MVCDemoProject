using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MVCDemo.Data
{
    public class PersonData : DataObject
    {

        public class PersonDetail
        {
            public int PId;
            public string FirstName;
            public string LastName;
            public string Email;
            public string Address;
        }
        public PersonData() : base()
        {

        }

        //To Add Person  Details
        public bool AddPerson(PersonDetail obj)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand("AddPerson", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Address", obj.Address);

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

        public List<PersonDetail> GetPersons()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from tbl_person");

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

            conn.Open();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            try
            {
                sa.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            List<PersonDetail> persons = new List<PersonDetail>();

            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                PersonDetail personDetails = new PersonDetail
                {
                    PId = Convert.ToInt32(dataRow["PId"]),
                    FirstName = dataRow["FirstName"].ToString()
                };

                /*
                 UserDetails userDetails = new UserDetails();
                userDetails.UserId = Convert.ToInt32(dataRow["UserId"]);
                userDetails.FirstName = dataRow["FirstName"].ToString();
                */

                persons.Add(personDetails);
            }


            return persons;
        }

        //To view Person Details with generic list     
        //public List<PerosnDetail> GetAllPerosns()
        //{
        //    List<PerosnDetail> PersonList = new List<PerosnDetail>();
        //    SqlConnection con = new SqlConnection(ConnectionString);
        //    SqlCommand com = new SqlCommand("GetAllPerosns", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    da.Fill(dt);
        //    con.Close();
        //    //Bind EmpModel generic list using dataRow     
        //    foreach (DataRow dr in dt.Rows)
        //    {

        //        PersonList.Add(

        //            new PerosnDetail
        //            {
        //               // PId = Convert.ToInt32(dr["Id"]),
        //                FirstName = Convert.ToString(dr["FirstName"]),
        //                LastName = Convert.ToString(dr["LastName"]),
        //                //Email = Convert.ToString(dr["Email"]),
        //                //Address = Convert.ToString(dr["Address"]),
        //                //PhoneNo = Convert.ToInt32(dr["PhoneNo"]),
        //                //Occupation = Convert.ToString(dr["Occupation"])
        //            }
        //            );


        //    }

        //    return PersonList;


        //}
    }
}