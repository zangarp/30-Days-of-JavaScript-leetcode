import finOpsApiClient from "@/axios/FinOpsAxios";
import { Guid } from "guid-typescript";
import { Menu } from "@/types/Menu";
import { Handbook } from "@/types/Handbook.ts";
import { Message } from "@/types/Message.ts";
import { MessageFilter } from "@/types/MessageFilter";
import { Field } from "@/types/Field.ts";
import { Root } from "@/types/ReplyTypeMessage.ts";
import { Employee } from "@/types/Employee";
import { MessageModel } from "@/types/version6/MessageModel.ts";

export async function Login(login: string, password: string) {
  return await finOpsApiClient.post("/Auth/Login", {
    login: login,
    password: password,
  });
}

export async function GetLeftMenuAsync(): Promise<Menu[]> {
  const response = await finOpsApiClient.get("/Menu/GetMenuList");
  return response.data;
}

export async function GetHandbook(handbookCode: number): Promise<Handbook[]> {
  const response = await finOpsApiClient.get(
    `SDFO/GetHandbook?handbookCode=${handbookCode}`,
  );
  return response.data;
}

export async function GetMessagesAsync(
  filter?: MessageFilter,
): Promise<Message[]> {
  const response = await finOpsApiClient.get(`Message/GetMessages`, {
    params: {
      filter: JSON.stringify(filter),
    },
  });
  return response.data;
}

export async function GetMessageById(id?: number) {
  const response = await finOpsApiClient.get(`Message/GetMessageById`, {
    params: {
      messageId: id,
    },
  });

  return response.data;
}

export async function GetMessageV6ById(id?: number): Promise<MessageModel> {
  const response = await finOpsApiClient.get(`Message/GetMessageV6ById`, {
    params: {
      messageId: id,
    },
  });

  return response.data;
}

export async function GetMessageByIdJson(id?: number) {
  const response = await finOpsApiClient.get(`Message/GetMessageByIdJson`, {
    params: {
      messageId: id,
    },
  });

  return response.data;
}

export async function GetAnswer(id?: number) {
  const response = await finOpsApiClient.get(`Message/GetAnswer`, {
    params: {
      dataCode: id,
    },
  });

  return response.data;
}

export async function GetFields(messageVersion?: Guid): Promise<Field[]> {
  const response = await finOpsApiClient.get(`SDFO/GetFields`, {
    params: {
      messageVersion: messageVersion,
    },
  });

  return response.data;
}

export async function GetHandbookWithVersion(
  dataCode?: number,
  messageVersion?: Guid,
): Promise<Handbook[]> {
  const response = await finOpsApiClient.get(`SDFO/GetHandbookWithVersion`, {
    params: {
      dataCode: dataCode,
      messageVersion: messageVersion,
    },
  });

  return response.data;
}

export async function ToNextStage(id?: number) {
  const response = await finOpsApiClient.get(`Message/ToNextStage`, {
    params: {
      dataCode: id,
    },
  });

  return response.data;
}

export async function ToPreviousStage(id?: number) {
  const response = await finOpsApiClient.get(`Message/ToPreviousStage`, {
    params: {
      dataCode: id,
    },
  });

  return response.data;
}

export async function Exclude(id?: number) {
  const response = await finOpsApiClient.get(`Message/Exclude`, {
    params: {
      dataCode: id,
    },
  });

  return response.data;
}

export async function AddAnswer(root: Root) {
  const response = await finOpsApiClient.post(`Message/AddAnswer`, root);

  return response.data;
}

export async function UpdateAnswer(root: Root, id: number) {
  const response = await finOpsApiClient.post(`Message/UpdateAnswer`, root, {
    params: {
      dataCode: id,
    },
  });

  return response.data;
}

export async function getCurrentUser(): Promise<Employee> {
  const response = await finOpsApiClient.get("SDFO/GetEmployee");
  return response.data;
}

export async function getUserRole(): Promise<number> {
  const response = await finOpsApiClient.get("SDFO/GetRolesGroup");
  return response.data;
}

export async function UpdateMessage(
  messId: number,
  xml: string,
): Promise<string> {
  console.log(xml);
  const response = await finOpsApiClient.post(
    `Message/UpdateMessage`,
    JSON.stringify(xml),
    {
      params: {
        messageId: messId,
      },
      headers: {
        "Content-Type": "application/json",
      },
    },
  );

  return response.data;
}

export async function UpdateMessageV6(
  messId: number,
  data: MessageModel,
): Promise<string> {
  const response = await finOpsApiClient.post(`Message/UpdateMessageV6`, data, {
    params: {
      messageId: messId,
    },
    headers: {
      "Content-Type": "application/json",
    },
  });

  return response.data;
}

export async function GetError(id?: number) {
  const response = await finOpsApiClient.get(`Message/GetError`, {
    params: {
      errorCode: id,
    },
  });

  return response.data;
}

export async function SendMessages(messagesId?: Array<number>) {
  const response = await finOpsApiClient.post(
    `Message/SendMessages`,
    messagesId,
  );

  return response.data;
}

export async function GetRelationMessagesTree(messageId?: number) {
  const response = await finOpsApiClient.get(
    `Message/GetRelationMessagesTree`,
    {
      params: {
        messageId: messageId,
      },
    },
  );
  return response.data;
}

export async function GetMessageFormInfo(pmessid?: number){
  const response = await finOpsApiClient.get(
    `Message/GetMessageFormInfo`,
    {
      params: {
        pmessid: pmessid,
      },
    },
  );
  return response.data;
}