<template>
    <div class="col-12 sticky-top">
      <nav class="navbar">
        <form class="form-inline">
          <button class="btn" type="button" @click="backToProfile">Back</button>
        </form>
      </nav>
    <div class="vault">
    <keep v-for="keep in vaultKeeps" :keepProp="keep" :key="keep._id" />
    </div>
    </div>
</template>


<script>
import Keep from "../Components/Keep"
export default {
    name: 'vault-view',
    data(){
        return {
            activeVault: this.$store.state.activeVault
        }
    },
    mounted(){
        this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId)
    },
    computed:{
        vault(){
            return this.$store.state.activeVault
        },
        vaultKeeps(){
            return this.$store.state.vaultkeeps;
        }

    },
    methods:{
        backToProfile(){
            this.$store.dispatch("backToProfile")
        }
    },
    components:{Keep}
}
</script>


<style scoped>

</style>