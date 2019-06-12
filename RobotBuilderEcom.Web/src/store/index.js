import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    parts: null,
    cart: [],
  },
  mutations: {
    updateBotParts(state, parts) {
      state.parts = parts;
    },
    updateCart(state, cartItems) {
      state.cart = cartItems;
    },
    addBotToCart(state, bot) {
      state.cart.push(bot);

      // construct bot transition object
      const botData = {
        headId: bot.head.id,
        leftArmId: bot.leftArm.id,
        rightArmId: bot.rightArm.id,
        torsoId: bot.torso.id,
        baseId: bot.base.id,
        cost: bot.cost,
      };
      debugger;
      axios.post('api/addbot', botData);
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
    getCartItemsFromApi({ commit }) {
      axios.get('api/cartitems')
        .then((result) => {
          commit('updateCart', result.data.CartItems);
        })
        .catch(console.error);
    },
  },
});
