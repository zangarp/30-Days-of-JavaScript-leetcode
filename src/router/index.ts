import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    component: () => import("@/pages/Main.vue"),
    name: "Main",
  },
];

export const router = createRouter({
  history: createWebHistory(),
  routes,
});
