using System;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultkeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultkeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        public void AddKeep(Vaultkeep newvaultkeep)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (vaultId, keepId)
            VALUES
            (@vaultId, @keepId)";
            _db.Execute(sql, new { newvaultkeep });
        }
    }
}