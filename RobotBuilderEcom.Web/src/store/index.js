import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    parts: null,
    cart: [],
    botToUpdate: null,
  },
  mutations: {
    setBotToUpdate(state, bot) {
      state.botToUpdate = {
        head: state.parts.heads.find(x => x.id === bot.HeadId),
        leftArm: state.parts.arms.find(x => x.id === bot.LeftArmId),
        rightArm: state.parts.arms.find(x => x.id === bot.RightArmId),
        torso: state.parts.torsos.find(x => x.id === bot.TorsoId),
        base: state.parts.bases.find(x => x.id === bot.BaseId),
      };
    },
    updateBotParts(state, parts) {
      state.parts = parts;
    },
    updateCart(state, cartItems) {
      state.cart = cartItems;
    },
  },
  actions: {
    getBotPartsFromApi({ commit, dispatch }) {
      axios.get('api/botparts')
        .then((result) => {
          commit('updateBotParts', result.data.BotPartsResult);
          dispatch('getCartItemsFromApi');
        })
        .catch(console.error);
    },
    addBotToCart({ dispatch }, bot) {
      // construct bot transition object
      const botData = {
        headId: bot.head.id,
        leftArmId: bot.leftArm.id,
        rightArmId: bot.rightArm.id,
        torsoId: bot.torso.id,
        baseId: bot.base.id,
        cost: bot.cost,
      };
      axios.post('api/addbot', botData)
        .then(() => dispatch('getCartItemsFromApi'));
    },
    updateBotToCart({ dispatch }, bot) {
      // construct bot transition object
      const botData = {
        cartBotId: bot.cartBotId,
        headId: bot.head.id,
        leftArmId: bot.leftArm.id,
        rightArmId: bot.rightArm.id,
        torsoId: bot.torso.id,
        baseId: bot.base.id,
        cost: bot.cost,
      };
      axios.post('api/updatebot', botData)
        .then(() => dispatch('getCartItemsFromApi'));
    },
    getCartItemsFromApi({ state, commit }) {
      axios.get('api/cartitems')
        .then((result) => {
          const newCart = [];
          result.data.CartItems.map((ci) => {
            const abc = {
              cartBotId: ci.CartBotId,
              head: state.parts.heads.find(x => x.id === ci.HeadId),
              leftArm: state.parts.arms.find(x => x.id === ci.LeftArmId),
              rightArm: state.parts.arms.find(x => x.id === ci.RightArmId),
              torso: state.parts.torsos.find(x => x.id === ci.TorsoId),
              base: state.parts.bases.find(x => x.id === ci.BaseId),
              isActive: ci.IsActive,
              cost: ci.Cost,
            };
            newCart.push(abc);
          });
          commit('updateCart', newCart);
        })
        .catch(console.error);
    },
    softDeleteBot({ dispatch }, cartBotId) {
      axios.delete('api/softdeletebot', { data: { cartBotId } })
        .then(() => dispatch('getCartItemsFromApi'))
        .catch(console.error);
    },
    hardDeleteBot({ dispatch }, cartBotId) {
      axios.delete('api/harddeletebot', { data: { cartBotId } })
        .then(() => dispatch('getCartItemsFromApi'))
        .catch(console.error);
    },
    getCartBotById({ commit }, cartBotId) {
      axios.post('api/getbotbyid', cartBotId)
        .then(result => commit('setBotToUpdate', result.data.CartBotDetails))
        .catch(console.error);
    },
  },
  getters: {
    cartItems(state) {
      return state.cart.filter(bot => bot.isActive);
    },
    deletedFromCartItems(state) {
      return state.cart.filter(bot => !bot.isActive);
    },
  },
});
