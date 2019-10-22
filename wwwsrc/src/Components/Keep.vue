<template>
  <div class="keep">
    <div class="card shadow border" style="width: 18rem;">
      <div class="col-4">
        <img v-bind:src="`${keepProp.img}`" class="card-img" alt="Card image cap" />
        <div class="card-body">
            <button class="btn btn-sm" type="button" @click="addToVault()">Add to my Vault</button>
          <h5 class="card-title inline">{{keepProp.name}}</h5>
          <p class="card-text">{{keepProp.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepProp"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    addToVault() {
      this.$store.dispatch("addToVault", this.keep);
    }
  },
  components: {}
};
</script>


<style scoped>
.inline {
  display: inline;
}
img{
    width: 20vh;
    height: 20vh;
}
.card{
    background-color: rgb(112, 112, 117);
}
</style>