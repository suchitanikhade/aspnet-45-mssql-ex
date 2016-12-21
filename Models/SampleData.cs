#region Copyright ©2016, Click2Cloud Inc. - All Rights Reserved
/* ------------------------------------------------------------------- *
*                            Click2Cloud Inc.                          *
*                  Copyright ©2016 - All Rights reserved               *
*                                                                      *
* Apache 2.0 License                                                   *
* You may obtain a copy of the License at                              * 
* http://www.apache.org/licenses/LICENSE-2.0                           *
* Unless required by applicable law or agreed to in writing,           *
* software distributed under the License is distributed on an "AS IS"  *
* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express  *
* or implied. See the License for the specific language governing      *
* permissions and limitations under the License.                       *
*                                                                      *
* -------------------------------------------------------------------  */
#endregion Copyright ©2016, Click2Cloud Inc. - All Rights Reserved

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;

namespace aspnet_45_mssql_ex.Models
{
    public class SampleData
    {
        private static string connectionString = ConnectionSetting.CONNECTION_STRING;

        public static void RetriveRecords()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Car";

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                Cars = new List<Car>();
                while (reader.Read())
                {
                    Cars.Add(new Car()
                    {
                        CarId = int.Parse(reader["CarId"].ToString()),
                        Model = reader["Model"].ToString(),
                        Manufacturer = reader["Manufacturer"].ToString(),
                        Year = int.Parse(reader["Year"].ToString())
                    });
                }
                reader.Close();

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public static bool InsertRecord(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Car (Model, Year, Manufacturer) VALUES (@Model, @Year, @Manufacturer);";

                command.Parameters.AddWithValue("@Model", car.Model);
                command.Parameters.AddWithValue("@Year", car.Year);
                command.Parameters.AddWithValue("@Manufacturer", car.Manufacturer);

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                if(command.ExecuteNonQuery() == 1) { return true; }

                return false;
            }
        }

        public static List<Car> Cars { get; set; }
    }
}
