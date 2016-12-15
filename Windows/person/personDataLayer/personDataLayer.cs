using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace personDataLayer
{

    public class personDataLayer
    {

        private string connectionString = "Data Source=(local);Initial Catalog=test;"
                                + "Integrated Security=true";
        private string queryString = "SELECT * from dbo.person;";


        public string read()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    //  reader.Close();


                    return reader.GetString(1);


                }
                catch (Exception ex)
                {
                    return ex.Message;
                }


            }

        }
    }
}
   