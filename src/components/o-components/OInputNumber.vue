<script setup lang="ts">
import { watch, ref } from "vue";

const props = defineProps<{
  modelValue: string | undefined;
  useGrouping?: boolean;
}>();

const modelVal = ref<number | undefined>(undefined); // Initialize as undefined

const emit = defineEmits(["update:modelValue"]);

watch(props, (val) => {
  if (val.modelValue) {
    const parsedValue = parseInt(val.modelValue);
    if (!isNaN(parsedValue)) {
      modelVal.value = parsedValue; // Set modelVal to parsed integer if valid
    } else {
      modelVal.value = undefined; // Handle case where parsing fails
    }
  } else {
    modelVal.value = undefined; // Handle case where parsing fails
  }
});
</script>

<template>
  <InputNumber
    :model-value="modelVal"
    @update:modelValue="emit('update:modelValue', $event.toString())"
    class="tw-w-full"
    :useGrouping="useGrouping"
  />
</template>
