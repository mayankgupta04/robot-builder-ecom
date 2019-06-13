<template>
<div>
  <div>
    <h1>Cart</h1>
    <table>
      <thead>
        <tr>
          <th class="robot-title">
            Robot
          </th>
          <th class="cost">
            Cost
          </th>
          <th>
            Actions
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(robot, index) in cartItems" :key="index">
          <td class="robot-title">
            {{robot.head.title}}
          </td>
          <td class="cost">
            {{robot.cost}}
          </td>
          <td class="delete-button">
            <button @click.prevent="softDeleteBot(robot.cartBotId)">Delete</button>
            <button @click.prevent="updateBot(robot.cartBotId)">Update</button>
          </td>
        </tr>
      </tbody>
    </table>
 </div>
 <div>
    <h2 class="deleted-items">Deleted from cart:</h2>
    <table>
      <thead>
        <tr>
          <th class="robot-title">
            Robot
          </th>
          <th class="cost">
            Cost
          </th>
          <th>
            Actions
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(robot, index) in deletedFromCartItems" :key="index">
          <td class="robot-title">
            {{robot.head.title}}
          </td>
          <td class="cost">
            {{robot.cost}}
          </td>
          <td class="delete-button">
            <button @click.prevent="hardDeleteBot(robot.cartBotId)">Delete Permanent</button>
          </td>
        </tr>
      </tbody>
    </table>
 </div>
</div>
</template>

<script>
export default {
  name: 'Cart',
  methods: {
    softDeleteBot(cartBotId) {
      this.$store.dispatch('softDeleteBot', cartBotId);
    },
    hardDeleteBot(cartBotId) {
      this.$store.dispatch('hardDeleteBot', cartBotId);
    },
    updateBot(cartBotId) {
      this.$router.push({
        path: `/update/${cartBotId}`,
      });
    },
  },
  computed: {
    cartItems() {
      return this.$store.getters.cartItems;
    },
    deletedFromCartItems() {
      return this.$store.getters.deletedFromCartItems;
    },
  },
};
</script>

<style scoped>
  td, th {
    padding: 5px;
  }
  .robot-title {
    text-align: left;
    padding-right: 200px;
  }
  .cost {
    text-align: right;
  }
  .deeted-items {
    color: red;
  }
</style>
