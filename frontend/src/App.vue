<script lang="ts">
import Files from "./components/TabsView.vue";
import SystemInfo from "./views/HomeView.vue";
import About from "./views/AboutView.vue";

export default {
  components: {
    Files,
    SystemInfo,
    About,
  },
    // define and export multiple tabs and remember always name your tabs the way you imported it.
  data() {
    return {
      currentTab: "Files",
      tabs: [
        {
          name: "SystemInfo",
          component: SystemInfo,
        },
        {
          name: "Files",
          component: Files,
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
