using Pets_2.Context;
using Pets_2.Domains;
using Pets_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_2.Repositories {
    public class RacasRepository : IRacas {
        RacasContext connect = new RacasContext();

        SqlCommand cmd = new SqlCommand();

        public void Delete(int id) {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText = "DELETE FROM Racas WHERE IdRacas = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            connect.Desconnect();
        }

        public List<Racas> ReadAll() {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText = "SELECT * FROM Racas";

            SqlDataReader data = cmd.ExecuteReader();

            List<Racas> racas = new List<Racas>();

            while (data.Read()) {
                racas.Add(
                    new Racas() {
                        IdRacas   = Convert.ToInt32(data.GetValue(0)),
                        Descricao = data.GetValue(1).ToString(),
                        IdTipo = Convert.ToInt32(data.GetValue(2)),
                    }
                ) ;
            }


            connect.Desconnect();

            return racas;
        }

        public Racas Register(Racas a) {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText =
                "INSERT INTO Racas (Descricao)" +
                "VALUES" +
                "@descricao";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            connect.Desconnect();

            return a;
        }

        public Racas SearchById(int id) {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText = "SELECT * FROM Racas WHERE IdRacas = @id";
                cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader data = cmd.ExecuteReader();

            Racas a = new Racas();

            while (data.Read()) {
                a.IdRacas   = Convert.ToInt32(data.GetValue(0));
                a.Descricao = data.GetValue(1).ToString();
            }
            connect.Desconnect();
            return a;
        }

        public Racas Update(int id, Racas a) {
            cmd.Connection = connect.ToConnect();
            cmd.CommandText = "UPDATE Racas SET " +
                "Descricao = @descricao" +
                "IdTipo = @idtipo WHERE IdRacas = @id";

            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@idtipo", a.IdTipo);
            cmd.Parameters.AddWithValue("@id", a.IdRacas);

            cmd.ExecuteNonQuery();
            connect.Desconnect();

            return a;
        }
    }
}
