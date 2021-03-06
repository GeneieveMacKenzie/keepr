using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Keepr.Models;
using Keepr.Repositories;

namespace keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        private readonly AccountRepository _accountrepo;
        public KeepsService(KeepsRepository repo, AccountRepository accountrepo)
        {
            _repo = repo;
            _accountrepo = accountrepo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }

        public IEnumerable<Keep> GetByUser(string userid)
        {
            return _repo.GetByUser(userid);
        }

        public Keep Get(int id)
        {
            Keep exists = _repo.Get(id);
            if (exists == null) { throw new Exception("Invalid id"); }
            return exists;
        }

        public Keep Create(Keep newKeep)
        {
            int id = _repo.Create(newKeep);
            newKeep.Id = id;
            return newKeep;
        }
        public Keep Edit(Keep newKeep)
        {
            Keep keep = _repo.Get(newKeep.Id);
            if (keep == null) { throw new Exception("Invalid Id Homie"); }
            keep.userId = newKeep.userId;
            _repo.Edit(keep);
            return keep;
        }
        public string Delete(int id, string userId)
        {
            Keep keep = _repo.Get(id);
            if (keep == null || keep.userId != userId) { throw new Exception("Invalid Request"); }
            _repo.Delete(id);
            return "Successfully Deleted";
        }

    }

}