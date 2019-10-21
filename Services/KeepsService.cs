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

        // public IEnumerable<Keep> Get(string id)
        // {
        //     if (exists == null) { throw new Exception("Invalid Id"); }
        //     return _repo.GetByUser(id);
        // }

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

        // public string Delete(int id)
        // {
        //    
        //     if(keep == null)  { throw new Exception("Invalid Id"); }
        //     _repo.Delete(id);
        //     return "Deleted";
        // }

    }

}