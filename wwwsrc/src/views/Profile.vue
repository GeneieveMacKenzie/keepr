<template>
  <div class="profile bg">
    <div class="row">
      <div class="col-12">
        <nav class="navbar bg-primary sticky-top">
          <router-link :to="{name: 'home'}">
            <a class="nav-link text-white" href="#" @click="backButton">Home</a>
          </router-link>
          <h3 class="text-warning">{{user.username}}</h3>
        </nav>
      </div>
    </div>
    <div class="row">
      <div class="col-3 bg2">
        <h1>Vaults</h1>
        <CreateVaultModal />
        <button
          class="btn btn-warning btn-sm mt-4"
          data-toggle="modal"
          data-target="#create-vault-modal"
        >Create Vault</button>
        <vault v-for="vault in vaults" :vaultProp="vault" :key="vault._id" />
      </div>
      <div class="col-9">
        <h1>Keeps</h1>
        <CreateKeepModal />
        <button
          class="btn btn-warning btn-sm mt-4"
          data-toggle="modal"
          data-target="#create-keep-modal"
        >Create Keep</button>
        <div class="row">
            <keep v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import CreateKeepModal from "../Components/CreateKeepModal";
import CreateVaultModal from "../Components/CreateVaultModal";
import Keep from "../Components/Keep";
import Vault from "../Components/Vault";
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
    vaults() {
      return this.$store.state.vaults;
    },
    keeps() {
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
  components: { Vault, CreateVaultModal, CreateKeepModal, Keep }
};
</script>


<style scoped>
.navbar {
  padding: 3px;
}
.nav-link {
  font-size: 25px;
  padding: 0px;
}
.sticky-top {
  position: sticky;
}
.bg {
  background-color: rgb(214, 214, 214);
  min-height: 100vh;
}
.bg2 {
  background-color: rgb(235, 232, 232);
  min-height: 100vh;
}
button{
  color: #1e2b37;
}
</style>