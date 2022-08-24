<script lang="ts">
import router from "@/router";
export default {
  data() {
    // check the media_type query param and set the mediaType property to selected value.
    const mediaType = router?.currentRoute?.value?.query?.type || "All";
    interface SelectEvent {
      target: {
        value: string;
      };
    }
    const arrangeMedia = (e: SelectEvent) => {
      const filterDate = router?.currentRoute?.value?.query?.filter_date;
      const selectedMediaType = e.target.value;

      if (selectedMediaType === "All") {
        return;
      } else {
        // change the query param on every change on the select element
        if (filterDate) {
          router.push({
            query: {
              filter_date: `${filterDate}`,
              type: selectedMediaType,
            },
          });
        } else {
          router.push({
            query: {
              type: selectedMediaType,
            },
          });
        }
      }
    };
    return {
      mediaType,
      arrangeMedia,
    };
  },
};
</script>
<template>
  <select v-model="mediaType" @change="arrangeMedia">
    <option value="All">All</option>
    <option value="Photos">Photos</option>
    <option value="Videos">Videos</option>
    <option value="Audio">Audio</option>
  </select>
</template>
