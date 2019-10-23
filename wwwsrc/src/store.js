import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    vaultkeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps
    }
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    usernameButton() {
      router.push({ name: "profile" })
    },
    backButton() {
      router.push({ name: "home" })
    },
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getKeepsByUser({ commit }) {
      try {
        let res = await api.get('keeps/user')
        commit('setKeeps', res.data)
      } catch (error) {
        
      }
    },
    async addKeep({ commit, dispatch }, data) {
      try {
        let res = await api.post('keeps', data)
        dispatch('getKeeps')
      } catch (e) {
        console.warn(e.message)
      }
    },
    async deleteKeep({ dispatch }, data){
      try {
        let res = await api.delete(`keeps/${data.id}`)
        dispatch('getKeeps')
      } catch (error) {
        console.error(error)
      }
    },
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get('vaults')
        commit('setVaults', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async createVaultKeep({ commit, dispatch }, data) {
      try {
        let res = await api.post('vaultkeeps', data)
        dispatch('getVaultKeeps')
      } catch (error) {

      }
    },
    async getVaultKeeps({ commit }) {
      try {
        let res = await api.get('vaultkeeps')
        commit('setVaultKeeps')
      } catch (error) {
        
      }
    },
    async addVault({ commit, dispatch }, data) {
      try {
        let res = await api.post('vaults', data)
        dispatch('getVaults')
      } catch (e) {
        console.warn(e.message)
      }
    },
  }
})
