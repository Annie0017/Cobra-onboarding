using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Cobra_onboarding.Models
{
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