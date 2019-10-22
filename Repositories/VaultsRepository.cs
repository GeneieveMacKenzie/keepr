using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        public int Create(Vault newVault)
        {
            string sql = @"
            INSERT INTO vaults
            (id, name, description, userId)
            VALUES
            (@Id, @Name, @Description, @userId)";
            return _db.ExecuteScalar<int>(sql, newVault);
        }

        public IEnumerable<Vault> Get(string userid)
        {
            string sql = "SELECT * FROM vaults WHERE userId = @userid";
            return _db.Query<Vault>(sql, new { userid });
        }

        public Vault Get(int id)
        {
            string sql = "SELECT * FROM vaults WHERE id = @id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id";
            _db.Execute(sql, new { id });

        }

    }
}

