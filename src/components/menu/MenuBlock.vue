<script setup lang="ts">
import { Menu } from '@/types/Menu';
import { ref, defineProps, defineEmits } from 'vue';

const active = ref<number>(-1);
const props = defineProps<{
  menuList?: Menu[],
  header?: string
}>();
const emit = defineEmits(["menuSelected"]);

function menuSelected(listNum?: number, index?: number) {
  localStorage.setItem("listNum", listNum!.toString());
  active.value = index!;
  emit("menuSelected", listNum, index);
}
</script>

<template>
  <div class="tw-text-[12px] tw-shadow-lg tw-rounded-b-lg tw-mt-[10px] tw-ml-[10px]">
    <ul id="menu">
      <li v-for="(menu, index) in props.menuList"
          :key="menu.listNum"
          class="tw-p-[3px] tw-cursor-pointer hover:tw-bg-[#E6F3F3] tw-px-[5px]"
          @click="menuSelected(menu.listNum, index)"
          :class="{ active: active === index }">
        {{ menu.label }}
      </li>
    </ul>
  </div>

</template>

<style scoped>
.active {
  background-color: #E6F3F3;
}
</style>