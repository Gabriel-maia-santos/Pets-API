using Learning_Database_with_Pets.Context;
using Learning_Database_with_Pets.Interfaces;
using Pets_2.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_2.Repositories {
    public class TipoDePetsRepository : ITipoDePets {

        TipodePetsContext connect = new TipodePetsContext();

        SqlCommand cmd = new SqlCommand();

        public void Delete(int id) {
            cmd.Connection = connect.ToConnect();

            cmd.CommandText = "DELETE FROM TipoDePets WHERE IdTipo = @id";
            cmd.Parameters.AddWithValue("@id", id);

            //Run command
            cmd.ExecuteNonQuery();

            connect.Desconect();
        }

        public List<TipoDePets> ReadAll() {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText = "SELECT * FROM TipoDePets";

            SqlDataReader data = cmd.ExecuteReader();

            List<TipoDePets> tipoDePets = new List<TipoDePets>();

            while (data.Read()) {
                tipoDePets.Add(
                     new TipoDePets() {
                         IdTipo = Convert.ToInt32(data.GetValue(3)),
                         Descricao = data.GetValue(1).ToString(),
                     }

                    ); ;
            }
            connect.Desconect();
            return tipoDePets;
        }

        public TipoDePets Register(TipoDePets a) {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText =
                "INSET INTO TipoDePets (Descricao)" +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            connect.Desconect();

            return a;        }

        public TipoDePets SearchById(int id) {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText = "SELECT * FROM TipoDePets WHERE IdTipo = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader data = cmd.ExecuteReader();

            TipoDePets a = new TipoDePets();

            while (data.Read()) {
                a.IdTipo    = Convert.ToInt32(data.GetValue(0));
                a.Descricao = data.GetValue(1).ToString();
            }
            connect.Desconect();
            return a;
        }

        public TipoDePets Update(int id, TipoDePets a) {
            cmd.Connection = connect.ToConnect();

            cmd.CommandText = "UPDATE TipoDePets SET " +
                "Descricao = @descricao WHERE IdTipo = @id";

            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            connect.Desconect();

            return a;
        }
    }
}
