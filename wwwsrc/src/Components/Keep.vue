<template>
  <div class="keep row">
    <div class="offset-2 col-3">
      <div class="card shadow m-4 border" style="width: 18rem;">
        <img v-bind:src="`${keepProp.img}`" alt="Card image cap" />
        <div class="card-body">
          <button
            v-if="$route.name === 'profile'"
            class="btn btn-sm"
            type="button"
            @click="deleteKeep(keepProp)"
          >
            <i class="far fa-trash-alt fa-2x"></i>
          </button>
          <button
            v-if="$route.name === 'vault'"
            class="btn btn-sm"
            type="button"
            @click="deleteVaultKeep()"
          >
            <i class="far fa-trash-alt fa-2x"></i>
          </button>
          <span class="fa-layers fa-fw">
            <button class="btn btn-sm" type="button" @click="viewKeep(keepProp)">
              <i class="far fa-eye fa-2x"></i>
            </button>
          </span>
          <button type="button" class="btn" data-toggle="collapse" data-target="#collapse">
            <i class="far fa-share-square fa-2x"></i>
          </button>
          <div class="collapse" id="collapse">
            <select v-model="newVaultId" @change="createVaultKeep()">
              <option disabled value>Add To Vault</option>
              <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{vault.name}}</option>
            </select>
          </div>
          <h5 class="card-title inline">{{keepProp.name}}</h5>
          <p class="card-text">{{keepProp.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "../Components/Vault";
export default {
  name: "keep",
  props: ["keepProp"],
  data() {
    return {
      newVaultId: ""
    };
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    createVaultKeep() {
      let payload = {
        keepId: this.keepProp.id,
        vaultId: this.newVaultId
      };
      this.$store.dispatch("createVaultKeep", payload);
    },
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    },
    deleteVaultKeep() {
      let data = {
        vaultId: this.$route.params.vaultId,
        keepId: this.keepProp.id
      };
      this.$store.dispatch("deleteVaultKeep", data);
    },
    viewKeep(keepProp) {
      keepProp.count++;
      this.$router.push({
        name: "keep",
        params: { keepId: keepProp.id }
      });
      this.$store.dispatch("viewKeep", keepProp);
    }
  },
  components: { Vault }
};
</script>


<style scoped>
.inline {
  display: inline;
}
img {
  width: 100%;
  height: auto;
}
.card {
  background-color: rgb(199, 199, 209);
  height: 40vh;
}
</style>