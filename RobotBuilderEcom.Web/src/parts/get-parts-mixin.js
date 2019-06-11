export default {
  created() {
    this.$store.dispatch('getBotPartsFromApi');
  },
  computed: {
    parts() {
      return this.$store.state.parts || {
        heads: [], arms: [], bases: [], torsos: [],
      };
    },
  },
};
