<script setup lang="ts">

defineProps<{ title: string }>();
</script>

<template>
  <div class="rounded-xl drop-shadow-lg overflow-clip">
    <div class="flex flex-row header justify-between bg-white gap-x-4 items-start">
      <span class="text-2xl font-normal tracking-normal">{{ title }}</span>
      <slot name="toolbar"></slot>
    </div>
    <slot name="toolbar2"></slot>
    <slot name="default"></slot>
  </div>
</template>

<style scoped>
.header {
  /* height: 60px !important; */
  padding: 16px;
}
</style>
<style>
.v-data-table {
  font-size: 12px !important;
}
</style>
