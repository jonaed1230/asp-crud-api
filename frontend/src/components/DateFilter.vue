<template>
  <div class="arrange-date">
    <input
      class="date-checkbox"
      type="checkbox"
      v-model="filterDate"
      @change="arrangeDate"
    />
    <span>Arrange by date</span>
  </div>
</template>
<script lang="ts">
import router from "@/router";

export default {
  data() {
    // check the filter_date query param and set the filterDate property to true if it is not set to true
    let filterDate = router?.currentRoute?.value?.query?.filter_date;
    const arrangeDate = () => {
      const mediaType = router?.currentRoute?.value?.query?.type;
      filterDate = filterDate === "true" ? "false" : "true";
      // change the query param on every click on the checkbox
      if (mediaType) {
        router.push({
          query: {
            filter_date: `${filterDate}`,
            type: mediaType,
          },
        });
      } else {
        router.push({
          query: {
            filter_date: `${filterDate}`,
          },
        });
      }
    };
    return {
      filterDate,
      arrangeDate,
    };
  },
};
</script>
<style>
.arrange-date {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.date-checkbox {
  -webkit-appearance: none;
  -moz-appearance: none;
  appearance: none;
  background-color: #fff;
  margin: 0;
  font: inherit;
  color: #eee;
  width: 1.15em;
  height: 1.15em;
  border: 0.15em solid #eee;
  border-radius: 0.15em;
  transform: translateY(-0.075em);
  margin-right: 0.5em;
  display: grid;
  place-content: center;
}
.date-checkbox::before {
  content: "";
  width: 0.65em;
  height: 0.65em;
  transform: scale(0);
  transition: 120ms transform ease-in-out;
  box-shadow: inset 1em 1em #1890ff;
  transform-origin: bottom left;
  clip-path: polygon(14% 44%, 0 65%, 50% 100%, 100% 16%, 80% 0%, 43% 62%);
}
.date-checkbox:checked::before {
  transform: scale(1);
}
</style>
