<template>
<div class="vault">
    <div class="card shadow border" style="width: 18rem;">
        <div class="card-body">
          <h5 class="card-title inline">{{vaultProp.name}}</h5>
          <p class="card-text">{{vaultProp.description}}</p>
        </div>
      </div>
    </div>
</template>


<script>
export default {
    name: 'vault',
    props: ['vaultProp'],
    data(){
        return {}
    },
    computed:{},
    methods:{},
    components:{}
}
</script>


<style scoped>

</style>