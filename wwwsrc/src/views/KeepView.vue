<template>
  <div class="keep-view bg">
    <div class="row">
      <div class="col-12">
        <nav class="navbar bg-primary sticky-top">
          <router-link :to="{name: 'home'}">
            <a class="nav-link text-white" href="#" @click="backButton">Home</a>
          </router-link>
        </nav>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h2 class="pt-5">
          {{keep.name}}
          <br />
          {{keep.description}}
        </h2>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <img v-bind:src="`${keep.img}`" class="py-5" alt="Card image cap" />
      </div>
    </div>
  </div>
</template>


<script>
import Keep from "../Components/Keep";
export default {
  name: "keep-view",
  data() {
    return {
      keepsbyid: this.$store.state.keepsbyid
    };
  },
  mounted() {
    this.$store.dispatch("viewKeep", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.keepsbyid;
    }
  },
  methods: {
    backButton() {
      this.$store.dispatch("backButton");
    }
  },
  components: { Keep }
};
</script>


<style scoped>
.bg{
  background-color: rgb(214, 214, 214);
  min-height: 100vh;
}
.nav-link {
  font-size: 25px;
  padding: 0px;
}
.navbar {
  padding: 5px;
}
img {
    max-width:40%;
    height:auto;
}
</style>