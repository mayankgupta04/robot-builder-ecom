export default {
  computed: {
    parts() {
      return this.$store.state.parts || {
        heads: [], arms: [], bases: [], torsos: [],
      };
    },
  },
};
