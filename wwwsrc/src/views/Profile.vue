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
    <div class="row">
      <vault v-for="vault in vaults" :vaultProp="vault" :key="vault._id" />
    </div>
  </div>
</template>


<script>
import Vault from "../Components/Vault"
export default {
  name: "profile",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults(){
      return this.$store.state.vaults;
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
  components: {Vault}
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
  background-color: #4bbcbc;
  color: black;
}
</style>