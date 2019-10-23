<template>
  <div class="home container-fluid">
    <div class="row sticky-top">
      <div class="col-12">
        <nav class="navbar">
          <button v-if="user.id" @click="logout">logout</button>
          <router-link v-else :to="{name: 'login'}">Login</router-link>
          <button
            class="btn"
            type="button"
            @click="usernameButton"
            v-if="user.email"
          >Hello, {{user.username}}</button>
        </nav>
      </div>
    </div>
    <div class="row">
      <CreateKeepModal />
          <button
          class="btn btn-danger btn-sm mt-4"
          data-toggle="modal"
          data-target="#create-keep-modal"
        >Create Keep</button>
    </div>
      <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
    </div>
</template>



<script>
import CreateKeepModal from "../Components/CreateKeepModal"
import Keep from "../Components/Keep";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    usernameButton() {
      this.$store.dispatch("usernameButton");
    }
  },
  components: { Keep, CreateKeepModal}
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
.btn {
  background-color: #2a84eb;
  color: black;
}
</style>