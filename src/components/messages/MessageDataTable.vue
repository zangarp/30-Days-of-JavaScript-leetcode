<script setup lang="ts">

import {ref} from "vue";

const value = ref<string>();
</script>

<template>
  <div>
    <InputText type="text" v-model="value" />
  </div>
</template>

<style scoped></style>
