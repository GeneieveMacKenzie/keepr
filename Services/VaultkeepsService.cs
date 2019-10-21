using System;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
    public class VaultkeepsService
    {
        private readonly VaultsRepository _repo;
        private readonly KeepsRepository _keeprepo;
        private readonly VaultkeepsRepository _vaultkeeprepo;
        public VaultkeepsService(VaultsRepository repo, KeepsRepository keeprepo, VaultkeepsRepository vaultkeeprepo)
        {
            _repo = repo;
            _keeprepo = keeprepo;
            _vaultkeeprepo = vaultkeeprepo;
        }

        public string AddKeep(Vaultkeep newvaultkeep) 
        {
            Vault vault = _repo.Get(newvaultkeep.VaultId);
            if (vault == null || vault.userId != newvaultkeep.userId) { throw new Exception("invalid vault id"); }
            Keep keepToAdd = _keeprepo.Get(newvaultkeep.KeepId);
            if (keepToAdd == null) { throw new Exception("Invalid keep id"); }
            _vaultkeeprepo.AddKeep(newvaultkeep);
            return "Successfully added Keep to Vault";

        }
    }
}
