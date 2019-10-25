<template>
  <div class="row bg">
    <div class="col-12 sticky-top vault-view">
      <nav class="navbar bg-primary">
        <router-link :to="{name: 'profile'}">
          <a class="nav-link text-white" href="#" @click="backToProfile">Profile</a>
        </router-link>
      </nav>
      <div class="vault">
        <div class="row">
          <keep v-for="keep in vaultKeeps" :keepProp="keep" :key="keep._id" />
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import Keep from "../Components/Keep";
export default {
  name: "vault-view",
  data() {
    return {
      activeVault: this.$store.state.activeVault
    };
  },
  mounted() {
    this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    vaultKeeps() {
      return this.$store.state.vaultkeeps;
    }
  },
  methods: {
    backToProfile() {
      this.$store.dispatch("backToProfile");
    }
  },
  components: { Keep }
};
</script>


<style scoped>
.nav-link {
  font-size: 25px;
  padding: 0px;
}
.navbar {
  padding: 5px;
}
.bg {
  background-color: rgb(214, 214, 214);
  min-height: 100vh;
}
</style>