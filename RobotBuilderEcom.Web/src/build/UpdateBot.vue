<template>
  <div v-if="availableParts && selectedRobot" class="content">
    <button class="add-to-cart" @click="updateInCart()">Update!</button>
    <div class="top-row">
      <div class="robot-name">
        {{selectedRobot.head.title}}
        <span class="sale" v-if="selectedRobot.head.onSale">Sale!</span>
      </div>
      <part-selector
        :parts="availableParts.heads"
        :selectedPartId="selectedRobot.head.id"
        position="top"
        @partSelected="part => selectedRobot.head = part"
      ></part-selector>
    </div>
    <div class="middle-row">
      <part-selector
        :parts="availableParts.arms"
        :selectedPartId="selectedRobot.leftArm.id"
        position="left"
        @partSelected="part => selectedRobot.leftArm = part"
      ></part-selector>
      <part-selector
        :parts="availableParts.torsos"
        :selectedPartId="selectedRobot.torso.id"
        position="center"
        @partSelected="part => selectedRobot.torso = part"
      ></part-selector>
      <part-selector
        :parts="availableParts.arms"
        :selectedPartId="selectedRobot.rightArm.id"
        position="right"
        @partSelected="part => selectedRobot.rightArm = part"
      ></part-selector>
    </div>
    <div class="bottom-row">
      <part-selector
        :parts="availableParts.bases"
        :selectedPartId="selectedRobot.base.id"
        position="bottom"
        @partSelected="part => selectedRobot.base = part"
      ></part-selector>
    </div>
  </div>
</template>

<script>
import PartSelector from './PartSelector.vue';

export default {
  name: 'RobotBuilder',
  components: { PartSelector },
  props: ['cartBotId'],
  data() {
    return {
      cart: [],
    };
  },
  created() {
    if (this.$route.params.cartBotId) {
      this.$store.dispatch('getCartBotById', { cartBotId: this.$route.params.cartBotId });
    }
  },
  computed: {
    availableParts() {
      return this.$store.state.parts;
    },
    selectedRobot() {
      return this.$store.state.botToUpdate;
    },
  },
  methods: {
    updateInCart() {
      const robot = this.selectedRobot;
      const cost = robot.head.cost
        + robot.leftArm.cost
        + robot.rightArm.cost
        + robot.torso.cost
        + robot.base.cost;
      this.$store.dispatch('updateBotToCart', Object.assign({}, robot, { cost, cartBotId: this.cartBotId }))
        .then(() => this.$router.push('/cart'))
        .catch(console.error);
    },
  },
};
</script>

<style>
.part {
  position: relative;
  width: 165px;
  height: 165px;
  border: 3px solid #aaa;
}
.part img {
  width: 165px;
}
.top-row {
  display: flex;
  justify-content: space-around;
}
.middle-row {
  display: flex;
  justify-content: center;
}
.bottom-row {
  display: flex;
  justify-content: space-around;
  border-top: none;
}
.head {
  border-bottom: none;
}
.left {
  border-right: none;
}
.right {
  border-left: none;
}
.left img {
  transform: rotate(-90deg);
}
.right img {
  transform: rotate(90deg);
}
.bottom {
  border-top: none;
}
.prev-selector {
  position: absolute;
  z-index: 1;
  top: -3px;
  left: -28px;
  width: 25px;
  height: 171px;
}
.next-selector {
  position: absolute;
  z-index: 1;
  top: -3px;
  right: -28px;
  width: 25px;
  height: 171px;
}
.center .prev-selector,
.center .next-selector {
  opacity: 0.8;
}
.left .prev-selector {
  top: -28px;
  left: -3px;
  width: 144px;
  height: 25px;
}
.left .next-selector {
  top: auto;
  bottom: -28px;
  left: -3px;
  width: 144px;
  height: 25px;
}
.right .prev-selector {
  top: -28px;
  left: 24px;
  width: 144px;
  height: 25px;
}
.right .next-selector {
  top: auto;
  bottom: -28px;
  left: 24px;
  width: 144px;
  height: 25px;
}
.right .next-selector {
  right: -3px;
}
.robot-name {
  position: absolute;
  top: -25px;
  text-align: center;
  width: 100%;
}
.sale {
  color: red;
}
.content {
  position: relative;
}
.add-to-cart {
  position: absolute;
  right: 30px;
  width: 220px;
  padding: 3px;
  font-size: 16px;
}
td,
th {
  text-align: left;
  padding: 5px;
  padding-right: 20px;
}
.cost {
  text-align: right;
}
.cart {
  text-align: left;
}
</style>
