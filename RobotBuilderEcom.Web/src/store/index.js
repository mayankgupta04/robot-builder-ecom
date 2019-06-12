import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    parts: null,
  },
  mutations: {
    updateBotParts(state, parts) {
      state.parts = parts;
    },
  },
  actions: {
    getBotPartsFromApi({ commit }) {
      axios.get('api/botparts')
        .then((result) => {
          commit('updateBotParts', result.data.BotPartsResult);
        })
        .catch(console.error);
    },
  },
});
