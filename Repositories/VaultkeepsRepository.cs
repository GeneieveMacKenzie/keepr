using System;
using System.Collections.Generic;
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

        public void AddKeep(int VaultId, int KeepId, string userId)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @KeepId, @userId)";
            _db.Execute(sql, new { VaultId, KeepId, userId });
            
        }

        public IEnumerable<Vaultkeep> Get(string userId, int vaultId)
        {
            string sql = @"
            SELECT * FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId AND vk.userId = @userId)";
            return _db.Query<Vaultkeep>(sql, new { userId, vaultId });
        }

        public void Delete(int vaultId)
        {
            string sql = "DELETE FROM vaultkeeps WHERE Id = @vaultId";
            _db.Execute(sql, new {vaultId});
        }

        public Vaultkeep GetOne(Vaultkeep vk)
        {
            string sql = @"
            SELECT * FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId)";
            return _db.QueryFirstOrDefault<Vaultkeep>(sql, vk);
        }
    }
}