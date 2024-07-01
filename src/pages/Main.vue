<script setup lang="ts">
import Documents from "@/components/Documents.vue";

import { Menu } from "@/types/Menu.ts";
import { GetLeftMenuAsync } from "@/api/finOpsAPI.ts";
import { onMounted, ref } from "vue";

const menuList = ref<Menu[]>();
const documentsComp = ref<InstanceType<typeof Documents> | null>(null);

function menuSelected() {
  documentsComp.value?.getMessages();
}

onMounted(async () => {
  menuList.value = await GetLeftMenuAsync();
  localStorage.setItem("listNum", "1");
});
</script>

<template>
  <Toast />
  <MainHeader />
  <div class="tw-flex">
    <div class="tw-w-[15%]">
      <LeftMenu :menu-list="menuList" @menu-selected="menuSelected" />
    </div>
    <div class="tw-w-[85%] tw-m-[10px]">
      <Documents ref="documentsComp" />
    </div>
  </div>
</template>

<style scoped></style>
