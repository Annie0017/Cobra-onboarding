using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Cobra_onboarding.Models
{
    public class Fun
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public DataSet  GetCustomerById(int id)
        {

            SqlCommand com = new SqlCommand("GetCustomerById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("Id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            return ds;
        }
    }

    //public void Edit(ClassPerson cus)
    //{
    //    SqlConnection com = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    //}
    public class ClassPerson
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
    }
}