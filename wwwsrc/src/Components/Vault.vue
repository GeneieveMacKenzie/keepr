<template>
  <div class="vault d-flex justify-content-center">
    <div class="card mt-3 shadow border" style="width: 18rem;">
      <div class="card-body">
        <button
          type="button"
          class="btn btn-info btn-lg"
          data-toggle="modal"
          data-target="#vault"
          @click="vaultView(vaultProp)"
        >{{vaultProp.name}}</button>
        <button class="btn btn-sm" @click="deleteVault(vaultProp)"><i class="far fa-trash-alt fa-2x"></i></button>
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
    return {}
  },
  computed: {
  },
  methods: {
      vaultView(vaultProp){
        this.$router.push({
          name:"vault",
          params: {vaultId: vaultProp.id}
        })
        this.$store.dispatch("getVaultById", vaultProp)
      },
      deleteVault(vaultProp){
        this.$store.dispatch("deleteVault", vaultProp)
      }
    },
  components: {Keep}
};
</script>


<style scoped>

</style>