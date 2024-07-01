import axios from "axios";

const defaultOptions = {
  baseURL: import.meta.env.VITE_APP_API_BASE,
  withCredentials: true
}

const bpmCoreAPIClient = axios.create(defaultOptions);

export default bpmCoreAPIClient;