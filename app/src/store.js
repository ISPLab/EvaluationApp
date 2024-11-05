import { createStore } from 'vuex'

const store = createStore({
  state: {
    auth: {
      id: 0,
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
      state.auth.id = payload.id;
    },
  },
});

export default store;