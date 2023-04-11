using System;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;
using System.Data;

namespace Smc.Infra.Data.Session
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(string cnn)
        {
            _id = Guid.NewGuid();
            Connection = new SqlConnection(cnn);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}

