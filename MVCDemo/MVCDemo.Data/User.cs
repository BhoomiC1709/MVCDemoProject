using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MVCDemo.Data
{
    public class User : DataObject
    {
        public class UserDetails
        {
            public int UserId;
            public string FirstName;
            public string LastName;
        }
        public User() : base()
        {

        }

        public UserDetails GetUser(int id)
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("GetUser", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userid", id);

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



            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                UserDetails userDetails = new UserDetails
                {
                    UserId = Convert.ToInt32(dataRow["UserId"]),
                    FirstName = dataRow["FirstName"].ToString()
                };


                /*
                  UserDetails userDetails = new UserDetails();
                userDetails.UserId = Convert.ToInt32(dataRow["UserId"]);
                userDetails.FirstName = dataRow["FirstName"].ToString();
                 */
                return userDetails;
            }


            return new UserDetails();
        }
        //private properties

        // create

        //update

        //delete

        //read

        //list
        public List<UserDetails> GetUsers()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from User");

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

            List<UserDetails> users = new List<UserDetails>();

            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                UserDetails userDetails = new UserDetails
                {
                    UserId = Convert.ToInt32(dataRow["UserId"]),
                    FirstName = dataRow["FirstName"].ToString()
                };

                /*
                 UserDetails userDetails = new UserDetails();
                userDetails.UserId = Convert.ToInt32(dataRow["UserId"]);
                userDetails.FirstName = dataRow["FirstName"].ToString();
                */

                users.Add(userDetails);
            }


            return users;
        }
    }
}