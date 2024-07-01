import { getCookie } from "@/services/cookieService";
import axios from "axios";

const defaultOptions = {
  baseURL: import.meta.env.VITE_APP_FIN_OPS,
  withCredentials: true,
};

const finOpsApiClient = axios.create(defaultOptions);

finOpsApiClient.interceptors.request.use(
  (config) => {
    const token = getCookie("sdfoToken");
    if (token) {
      config.headers["Authorization"] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default finOpsApiClient;
