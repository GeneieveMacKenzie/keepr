<template>
  <div class="vault">
    <div class="card shadow border" style="width: 18rem;">
      <div class="card-body">
        <button
          type="button"
          class="btn btn-info btn-lg"
          data-toggle="modal"
          data-target="#vault"
          @click="getVaultKeeps()"
        >{{vaultProp.name}}</button>
        <div id="vault" class="modal fade" role="dialog">
          <div class="modal-dialog modal-lg">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">{{vaultProp.name}}</h4>
                <p class="card-text">{{vaultProp.description}}</p>
                <div>
                  <keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
                </div>
              </div>
              <div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import Keep from "../Components/Keep"
export default {
  name: "vault",
  props: ["vaultProp"],
  data() {
    return {};
  },
  computed: {
    keeps(){
      return this.$store.state.keeps;
    }
  },
  methods: {
      getVaultKeeps(){
          this.$store.dispatch("getVaultKeeps")
      }
    },
  components: {Keep}
};
</script>


<style scoped>
</style>