import { createApp } from "vue";
import App from "./App.vue";
import PrimeVue from "primevue/config";
import ToastService from "primevue/toastservice";
import { router } from "@/router";
import "./assets/css/tailwind.scss";
import "primevue/resources/themes/aura-light-green/theme.css";
import "./assets/css/main.css";
import { ru } from "@/plugins/locale/ru.ts";
import "primeicons/primeicons.css";
import Tooltip from "primevue/tooltip";
import Toast from "primevue/toast";
import DialogService from "primevue/dialogservice";

const app = createApp(App)
  .use(ToastService)
  .use(router)
  .use(PrimeVue, {
    locale: ru,
  })
  .use(DialogService);

app.directive("tooltip", Tooltip);
app.component("Toast", Toast);
app.mount("#app");
