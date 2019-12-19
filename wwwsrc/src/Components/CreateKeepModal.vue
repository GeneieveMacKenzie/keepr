<template>
  <div id="create-keep-modal" class="modal" tabindex="2" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create Keep</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addKeep()">
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                placeholder="Enter Keep Name Here"
                v-model="newKeep.name"
                required
              />
            </div>
            <div class="form-group">
              <!-- <label for="url">URL for recipe</label> -->
              <input
                type="text"
                class="form-control"
                placeholder="img URL"
                v-model="newKeep.img"
                required
              />
            </div>
            <div class="form-group">
              <!-- <label for="ingredients">Ingredients</label> -->
              <input
                type="text"
                class="form-control"
                placeholder="Enter Description"
                v-model="newKeep.description"
                required
              />
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "create-keep-modal",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {},
  methods: {
    addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
      $(".close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
</style>