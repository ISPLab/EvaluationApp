import { createStore } from 'vuex'

const store = createStore({
  state: {
    auth: {
      isAuthenticated: false,
      isActive: false,
      username: '',
    },
  },
  mutations: {
    SET_AUTH(state, payload) {
      state.auth.isAuthenticated = payload.isAuthenticated;
      state.auth.isActive = payload.isActive;
      state.auth.username = payload.username;
    },
  },
});

export default store;