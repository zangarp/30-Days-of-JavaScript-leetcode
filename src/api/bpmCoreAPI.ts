import bpmCoreAPIClient from "../axios/bpmCoreAxios.ts";
import { Employee } from "@/types/Employee.ts";

export async function getCurrentUser() : Promise<Employee> {
  const response = await bpmCoreAPIClient.get("/Employee/GetEmployee");
  return response.data;
}