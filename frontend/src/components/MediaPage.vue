<script setup lang="ts">
import MediaFilter from "./MediaFilter.vue";
import DateFilter from "./DateFilter.vue";
</script>
<template>
  <div class="media-header">
    <DateFilter />
    <MediaFilter />
  </div>
</template>
<style>
  .media-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1.5rem;
  }
</style>
