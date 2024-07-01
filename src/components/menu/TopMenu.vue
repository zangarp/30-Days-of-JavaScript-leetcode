<script setup lang="ts">
const emit = defineEmits(["openFilterDialog"]);

function openFilterDialog() {
  emit("openFilterDialog");
}
</script>

<template>
  <div class="tw-flex">
    <mc-refresh2-fill class="m-top-menu-icon" />
    <ak-circle-plus class="m-top-menu-icon" />
    <ca-document-attachment class="m-top-menu-icon" />
    <an-outlined-printer class="m-top-menu-icon" />
    <cl-filter class="m-top-menu-icon" @click="openFilterDialog" />
  </div>
</template>

<style scoped></style>
