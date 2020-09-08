using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_2.Context {
    public class RacasContext {
        SqlConnection con = new SqlConnection();

        public RacasContext() {
            con.ConnectionString = @"Data Source=DESKTOP-3AR93PM\SQLEXPRESS;Initial Catalog=boletim;User ID=sa;Password=sa132";
            
        }
        public SqlConnection ToConnect() {
            if(con.State == System.Data.ConnectionState.Closed) {
                con.Open();
            }
            return con;
        }

        public void Desconnect() {
            if(con.State == System.Data.ConnectionState.Open) {
                con.Close();
            }
        }
    }
}
