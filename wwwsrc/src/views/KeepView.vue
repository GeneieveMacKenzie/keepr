<template>
    <div class="keep-view">

        <h1>Keep</h1>
        <h1>{{keep.name}}</h1>
    </div>
</template>


<script>
import Keep from "../Components/Keep"
export default {
    name: 'keep-view',
    data(){
        return {
           keepsbyid: this.$store.state.keepsbyid
        }
    },
    mounted(){
        this.$store.dispatch("viewKeep", this.$route.params.keepId)
    },
    computed:{
    keep() {
      return this.$store.state.keepsbyid;
    }
    },
    methods:{},
    components:{Keep}
}
</script>


<style scoped>

</style>