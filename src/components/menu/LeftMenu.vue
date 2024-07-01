<script setup lang="ts">
import { Menu } from "@/types/Menu";
import { ref } from "vue";

const props = defineProps<{
  menuList?: Menu[];
}>();

const menuCreate = ref<HTMLElement | null>(null);
const isModalVisible = ref(false);
const taskDescription = ref("");

const toggle = () => {
  isModalVisible.value = !isModalVisible.value;
};

const emit = defineEmits(["menuSelected"]);

function menuSelected(listNum?: number) {
  emit("menuSelected", listNum);
}

const createTask = () => {
  if (!taskDescription.value.trim()) {
    alert("Please enter a task description.");
    return;
  }

  const newTask = {
    description: taskDescription.value,
  };


  props.menuList?.push(newTask);

  toggle();
};
</script>


<template>
  <div>
    <Button
        label="Создать план"
        @click="toggle"
        class="custom-button"
    />
    <MenuBlock
        :menuList="props.menuList"
        @menu-selected="menuSelected"
    />
    <!-- Modal -->
    <div v-if="isModalVisible" class="modal-backdrop">
      <div class="modal">
        <div class="modal-header">
          <h3>Создать новую задачу</h3>
          <button type="button" @click="toggle" class="btn-close" aria-label="Закрыть">x</button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createTask">
            <label for="taskDescription" class="col-form-label fst-italic">Описание</label>
            <textarea v-model="taskDescription" class="form-control" id="taskDescription" placeholder="Введите описание задачи" rows="5"></textarea>
            <button type="submit" class="btn-create">Создать</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style scoped>

.modal-backdrop {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  background: white;
  border-radius: 8px;
  padding: 20px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

.modal-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-bottom: 1px solid #e5e5e5;
  padding-bottom: 10px;
}

.modal-body {
  padding-top: 10px;
}

.form-control {
  width: 100%;
  padding: 10px;
  border-radius: 4px;
  border: 1px solid #ccc;
}

.btn-create {
  background-color: #f05e22;
  color: white;
  border: none;
  padding: 10px 20px;
  cursor: pointer;
  border-radius: 4px;
  margin-top: 10px; /* Adjust margin as needed */
}

.btn-create:hover {
  background-color: #e5531d;
}

.col-form-label {
  display: block;
  margin-bottom: 5px;
}
</style>

