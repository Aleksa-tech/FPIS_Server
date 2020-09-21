using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FPIS.DAL.DataAccessBroker
{
    public class ClientDbBroker : ReadWriteDbBroker<Klijent>
    {
        protected override void AddInsertParameters(SqlCommand cmd, Klijent entity)
        {
            cmd.Parameters.Add("@pib", SqlDbType.BigInt).Value = entity.PIB;
            cmd.Parameters.Add("@adresaISediste", SqlDbType.VarChar, 128).Value = entity.AdresaISediste;
            cmd.Parameters.Add("@imeIPrezimeKlijenta", SqlDbType.VarChar, 60).Value = entity.ImeIPrezimeKlijenta;
            cmd.Parameters.Add("@brojRacuna", SqlDbType.BigInt).Value = entity.BrojRacuna;
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Direction = ParameterDirection.Output;
        }

        protected override void AddUpdateParameters(SqlCommand cmd, Klijent entity)
        {
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = entity.Id;
            cmd.Parameters.Add("@pib", SqlDbType.BigInt).Value = entity.PIB;
            cmd.Parameters.Add("@adresaISediste", SqlDbType.VarChar, 128).Value = entity.AdresaISediste;
        }

        protected override Klijent ReadEntity(SqlDataReader reader)
        {
            var client = new Klijent();
            client.Id = reader.GetInt64("Id");
            client.PIB = reader.GetInt64("PIB");
            client.AdresaISediste = reader.GetString("AdresaISediste");
            client.ImeIPrezimeKlijenta = reader.GetString("ImeIPrezimeKlijenta");
            client.BrojRacuna = reader.GetInt64("BrojRacuna");
            client.Racun = new Racun { Id=client.BrojRacuna, TipRacuna=reader.GetString("TipRacuna") };

            return client;
        }
    }
}
