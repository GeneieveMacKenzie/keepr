<template>
  <div class="home">
    <div class="row sticky-top">
      <div class="col-12">
        <nav class="navbar navbar-expand-sm bg-primary justify-content-between">
          <router-link  v-if="user.id" :to="{name: 'home'}"><a class="nav-link text-white" href="#" @click="logout">logout</a></router-link>
          <router-link v-else :to="{name: 'login'}"><a class="nav-link text-white" href="#">login</a></router-link>
          <router-link :to="{name: 'profile'}"><a v-if="user.id" class="nav-link text-white" href="#">Welcome {{user.username}}!</a><a v-else class="nav-link text-white" href="#"></a></router-link>
        </nav>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h1>Keepr</h1>
      </div>
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
.nav-link{
  font-size: 25px;
  padding: 0px;
}
.navbar{
  padding: 5px;
}
.sticky-top {
  position: sticky;
}

</style>