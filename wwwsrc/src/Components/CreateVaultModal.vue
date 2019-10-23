<template>
  <div id="create-vault-modal" class="modal" tabindex="2" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create Vault</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addVault()">
            <div class="form-group">
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Enter Keep Name Here"
                v-model="newVault.name"
                required
              />
            </div>
            <div class="form-group">
              <!-- <label for="ingredients">Ingredients</label> -->
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Enter Description"
                v-model="newVault.description"
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
  name: "create-vault-modal",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    addVault() {
      this.$store.dispatch("addVault", this.newVault);
      $(".close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
</style>