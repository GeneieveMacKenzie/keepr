<template>
  <div class="vault">
    <div class="card shadow border" style="width: 18rem;">
      <div class="card-body">
        <button
          type="button"
          class="btn btn-info btn-lg"
          data-toggle="modal"
          data-target="#vault"
          @click="vaultView(vaultProp)"
        >{{vaultProp.name}}</button>
        <button class="btn btn-danger btn-sm" @click="deleteVault(vaultProp)">DELETE</button>
        <p>{{vaultProp.description}}</p>
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