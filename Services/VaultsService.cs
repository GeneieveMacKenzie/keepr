using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        // private readonly AccountRepository _accountrepo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public Vault Create(Vault newVault)
        {
            int id = _repo.Create(newVault);
            newVault.Id = id;
            return newVault;
        }

        public IEnumerable<Vault> Get(string userid)
        {
            return _repo.Get(userid);
        }

        public Vault Get(int id)
        {
            Vault vault = _repo.Get(id);
            if (vault == null) { throw new Exception("Invalid Id"); }
            return vault;
        }

        public string Delete(int id, string userid)
        {
            Vault vault = _repo.Get(id);
            if (vault == null || vault.userId != userid) { throw new Exception("Invalid Request"); }
            _repo.Delete(id);
            return "Successfully Deleted";

        }

    }

}