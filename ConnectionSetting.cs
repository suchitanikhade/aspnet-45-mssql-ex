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
using System.Linq;
using System.Web;

namespace aspnet_mssql_sample
{
    public static class ConnectionSetting
    {
        internal static string CONNECTION_STRING
        {
            get
            {
                if (!(string.IsNullOrEmpty(DATABASE_SERVICE_NAME) || string.IsNullOrEmpty(DATABASE_SERVICE_PORT)
                || string.IsNullOrEmpty(DATABASE_NAME) || string.IsNullOrEmpty(DATABASE_USER) || string.IsNullOrEmpty(DATABASE_PASSWORD)))
                {
                    string _connectionString = string.Format("Data Source={0},{1};Initial Catalog={2};Persist Security Info=True;User ID={3};Password={4};", DATABASE_SERVICE_NAME,
                        DATABASE_SERVICE_PORT, DATABASE_NAME, DATABASE_USER, DATABASE_PASSWORD);

                    return _connectionString;
                }
                else { throw new Exception("Environment variables are not configured"); }
            }
        }

        #region Get Environment Variables

        private static string DATABASE_SERVICE_NAME
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_SERVICE_NAME")))
                {
                    return Environment.GetEnvironmentVariable("DATABASE_SERVICE_NAME");
                }

                return string.Empty;
            }
        }

        private static string DATABASE_SERVICE_PORT
        {
            get
            {
                return "3306";
            }
        }

        private static string DATABASE_USER
        {
            get
            {
                return "sa";
            }
        }

        private static string DATABASE_PASSWORD
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SA_PASSWORD")))
                {
                    return Environment.GetEnvironmentVariable("SA_PASSWORD");
                }

                return string.Empty;
            }
        }

        private static string DATABASE_NAME
        {
            get
            {
                return "sampledb";
            }
        }

        #endregion

    }
}
