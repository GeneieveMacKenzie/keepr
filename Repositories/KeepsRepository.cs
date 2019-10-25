using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM keeps WHERE isPrivate = false";
            return _db.Query<Keep>(sql);
        }

        public int Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps
            (name, description, img, userId, isPrivate)
            VALUES
            (@Name, @Description, @Img, @userId, @isPrivate);
            SELECT LAST_INSERT_ID();
            ";
            return _db.ExecuteScalar<int>(sql, newKeep);
        }

        public IEnumerable<Keep> GetByUser(string userid)
        {
            string sql = "SELECT * FROM keeps WHERE userId = @userid";
            return _db.Query<Keep>(sql, new { userid });
        }

        public Keep Get(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        public void Edit(Keep keep)
        {
            string sql = @"
            UPDATE keeps
            SET 
                name = @Name,
                description = @Description,
                img = @Img,
                isPrivate = @isPrivate,
                count = @count
            WHERE 
                id = @Id";
            _db.Execute(sql, keep);
        }
        public void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}