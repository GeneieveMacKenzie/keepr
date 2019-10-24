<template>
  <div class="row profile">
    <div class="col-12 sticky-top">
      <nav class="navbar">
        <form class="form-inline">
          <button class="btn" type="button" @click="backButton">Back</button>
          <h3>{{user.username}}</h3>
        </form>
      </nav>
    </div>
    <div class="col-12">
          <CreateVaultModal />
          <button
          class="btn btn-danger btn-sm mt-4"
          data-toggle="modal"
          data-target="#create-vault-modal"
        >Create Vault</button>
    </div>
    <div class="col-12">
      <vault v-for="vault in vaults" :vaultProp="vault" :key="vault._id" />
    </div>
       <div class="col-12">
          <CreateKeepModal />
          <button
          class="btn btn-danger btn-sm mt-4"
          data-toggle="modal"
          data-target="#create-keep-modal"
        >Create Keep</button>
    </div>
    <div class="col-12">
      <keep v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
    </div>
  </div>
</template>


<script>
import CreateKeepModal from "../Components/CreateKeepModal"
import CreateVaultModal from "../Components/CreateVaultModal"
import Keep from "../Components/Keep"
import Vault from "../Components/Vault"
export default {
  name: "profile",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
    this.$store.dispatch("getKeepsByUser");

  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults(){
      return this.$store.state.vaults;
    },
    keeps(){
      return this.$store.state.userkeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },

    backButton() {
      this.$store.dispatch("backButton");
    }
  },
  components: {Vault, CreateVaultModal, CreateKeepModal, Keep} 
};
</script>


<style scoped>
.form-inline {
  display: contents;
}
.sticky-top {
  position: sticky;
  background-color: #dad6d2;
}
h3 {
  font-family: "Amaranth", sans-serif;
  font-size: 4vh;
}
.btn {
  background-color: #2a84eb;
  color: black;
}
</style>