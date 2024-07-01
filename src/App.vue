<script setup lang="ts">
import { onMounted } from "vue";
import DynamicDialog from "primevue/dynamicdialog";

onMounted(async () => {});
</script>

<template>
  <router-view></router-view>
  <Toast position="top-right" />
  <DynamicDialog />
</template>
