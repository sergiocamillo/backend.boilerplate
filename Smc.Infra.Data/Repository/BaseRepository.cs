using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Http;
using Smc.Infra.Data.Session;

namespace Smc.Infra.Data.Repository
{
	public class BaseRepository
	{
        private DbSession _session;

        public BaseRepository(DbSession session)
        {
            _session = session;
        }

        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = _session.Connection)
            {
                return connection.QueryFirstOrDefault<T>(sql, parameters, _session.Transaction);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = _session.Connection)
            {
                return connection.Query<T>(sql, parameters, _session.Transaction).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = _session.Connection)
            {
                return connection.Execute(sql, parameters, _session.Transaction);
            }
        }
    }
}

