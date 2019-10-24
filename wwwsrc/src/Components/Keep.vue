<template>
  <div class="keep">
    <div class="card shadow border" style="width: 18rem;">
      <div class="col-12">
        <img v-bind:src="`${keepProp.img}`" class="card-img" alt="Card image cap" />
        <div class="card-body">
          <button class="btn btn-sm" type="button" @click="deleteKeep(keepProp)">x</button>
          <!-- <button
            class="btn btn-sm"
            type="button"
            @click="createVaultKeep(keepProp)"
          >Add to my Vault</button> -->
          <select v-model="newVaultId" @change="createVaultKeep()">
            <option disabled value>Add To Vault</option>
            <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{vault.name}}</option>
          </select>
          <h5 class="card-title inline">{{keepProp.name}}</h5>
          <p class="card-text">{{keepProp.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "../Components/Vault"
export default {
  name: "keep",
  props: ["keepProp"],
  data() {
    return {
        newVaultId: "",
    };
  },
  computed: {
    vaults(){
      return this.$store.state.vaults
    }
  },
  methods: {
    createVaultKeep() {
      let payload={
        keepId: this.keepProp.id,
        vaultId: this.newVaultId
      }
      this.$store.dispatch("createVaultKeep", payload);
    },
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    }
  },
  components: {Vault}
};
</script>


<style scoped>
.inline {
  display: inline;
}
img {
  width: 20vh;
  height: 20vh;
}
.card {
  background-color: rgb(112, 112, 117);
}
</style>