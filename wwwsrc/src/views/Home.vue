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
      <keep v-for="keep in keeps" :keepProp="keep" :key="keep._id" />
    </div>
  </div>
</template>



<script>
import Keep from "../Components/Keep";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
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
  components: { Keep }
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
  background-color: #4bbcbc;
  color: black;
}
</style>