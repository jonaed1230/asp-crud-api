<script lang="ts">
import Media from "./MediaPage.vue";
import Home from "./HomeVue.vue";
import About from "./AboutVue.vue";

export default {
  components: {
    Media,
    Home,
    About,
  },
  // define and export multiple tabs and remember always name your tabs the way you imported it.
  data() {
    return {
      currentTab: "Media",
      tabs: [
        {
          name: "Home",
          component: Home,
        },
        {
          name: "Media",
          component: Media,
        },
        {
          name: "About",
          component: About,
        },
      ],
    };
  },
};
</script>

<template>
  <div class="demo">
    <button
      v-for="tab in tabs"
      :key="tab.name"
      :class="['tab-button', { active: currentTab === tab.name }]"
      @click="currentTab = tab.name"
    >
      {{ tab.name }}
    </button>
    <component :is="currentTab" class="tab" />
  </div>
</template>
