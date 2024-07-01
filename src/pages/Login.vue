<script setup lang="ts">
import { ref } from "vue";
import { Login } from "@/api/finOpsAPI.ts";
import { useToast } from "primevue/usetoast";
import { saveToCookie } from "@/services/cookieService.ts";

const toast = useToast();
const login = ref<string>("");
const password = ref<string>("");
const isLoginButtonLoading = ref<boolean>(false);

async function loginToSite() {
  isLoginButtonLoading.value = true;
  await Login(login.value, password.value)
    .then(function (res) {
      saveToCookie("sdfoToken", res.data, 0.5);
      window.location.reload();
    })
    .catch(function (err) {
      toast.add({
        severity: "error",
        summary: "Ошибка",
        detail: err.response.data,
        life: 3000,
      });
    });
  isLoginButtonLoading.value = false;
}
</script>

<template>
  <div
    class="tw-bg-[#F5F6FA] tw-h-[100vh] tw-w-full tw-flex tw-justify-center tw-items-center"
  >
    <Card class="tw-w-[450px] tw-text-center">
      <template #title>Авторизация в системе "СДФО"</template>
      <template #content>
        <div>
          <IconField class="tw-mb-5" @keyup.enter="loginToSite">
            <InputIcon class="pi pi-user"> </InputIcon>
            <InputText v-model="login" placeholder="Логин" class="tw-w-full" />
          </IconField>
          <Password
            v-model="password"
            :feedback="false"
            toggleMask
            input-class="tw-w-full"
            inputId="password1"
            placeholder="Пароль"
            @keyup.enter="loginToSite"
          />
          <Button
            label="Вход"
            class="tw-bg-[#64748B] tw-mt-5 tw-border-0"
            @click="loginToSite"
            :loading="isLoginButtonLoading"
          />
        </div>
      </template>
    </Card>
  </div>
</template>

<style scoped></style>
