<script setup lang="ts">
import { watch, ref } from "vue";
import { getDateFromString } from "@/utilities/getDateFromString.ts";

const props = defineProps<{
  modelValue: string | undefined;
}>();

const modelVal = ref<Date | undefined>(undefined); // Initialize as undefined

const emit = defineEmits(["update:modelValue"]);

watch(props, (val) => {
  if (val.modelValue) {
    modelVal.value = getDateFromString(val.modelValue); // Set modelVal to parsed integer if valid
  } else {
    modelVal.value = undefined; // Handle case where parsing fails
  }
});
</script>

<template>
  <Calendar
    :model-value="modelVal"
    @update:modelValue="emit('update:modelValue', $event?.toLocaleString())"
    class="tw-w-full"
    showIcon
  />
</template>
