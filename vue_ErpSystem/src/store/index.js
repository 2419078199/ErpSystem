import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    userInfo: {}
  },
  mutations: {
    editUserInfo(state, payload) {
      state.userInfo = payload
    }
  },
  actions: {},
  modules: {}
})
