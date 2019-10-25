import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
import Profile from './views/Profile.vue'
import VaultView from './views/VaultView.vue'
import KeepView from './views/KeepView'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/profile',
      name: 'profile',
      component: Profile
    },
    {
      path: '/vault/:vaultId',
      name: 'vault',
      component: VaultView
    },
    {
      path: '/keep/:keepId',
      name: 'keep',
      component: KeepView
    }
  ]
})
