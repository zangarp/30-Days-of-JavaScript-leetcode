<script setup lang="ts">
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import {
  GetFields,
  ToNextStage,
  ToPreviousStage,
  Exclude,
  GetMessageV6ById,
  UpdateMessageV6,
  GetHandbookWithVersion,
} from "@/api/finOpsAPI.ts";
import { plainToClass } from "class-transformer";
// import { Reference } from "@/types/Root.ts";
import {
  MessageModel,
  Reference,
  Participant,
} from "@/types/version6/MessageModel";
import { Field } from "@/types/Field.ts";
import { Guid } from "guid-typescript";
import { Handbook } from "@/types/Handbook.ts";
import { getDateFromString } from "@/utilities/getDateFromString.ts";
import {
  getParticipantLastName,
  setParticipantLastName,
} from "@/utilities/getsetParticipantLastName.ts";
import {
  getParticipantFirstName,
  setParticipantFirstName,
} from "@/utilities/getsetParticipantFirstName.ts";
import {
  getParticipantMiddleName,
  setParticipantMiddleName,
} from "@/utilities/getsetParticipantMiddleName.ts";
import {
  getParticipantSetFIO,
  setParticipantSetFIO,
} from "@/utilities/getsetParticipantSetFIO.ts";
import {
  getDocumentIdentityHandbook,
  setDocumentIdentityHandbook,
} from "@/utilities/getsetDocumentIdentity.ts";
import {
  getParticipantDocNumber,
  setParticipantDocNumber,
} from "@/utilities/getsetParticipantDocNumber.ts";
import {
  getParticipantDocSeries,
  setParticipantDocSeries,
} from "@/utilities/getsetParticipantDocSeries.ts";
import {
  getParticipantDocumentIssuedBy,
  setParticipantDocumentIssuedBy,
} from "@/utilities/getsetParticipantDocumentIssuedBy.ts";
import {
  getParticipantDocumentDate,
  setParticipantDocumentDate,
} from "@/utilities/getsetParticipantDocumentDate.ts";
import {
  getParticipantDateOfBirth,
  setParticipantDateOfBirth,
} from "@/utilities/getsetParticipantDateOfBirth.ts";
import {
  getParticipantPlaceOfBirth,
  setParticipantPlaceOfBirth,
} from "@/utilities/getsetParticipantPlaceOfBirth.ts";
import {
  getParticipantLegalAddressCountry,
  setParticipantLegalAddressCountry,
} from "@/utilities/getsetParticipantLegalAddressCountry.ts";
import {
  getParticipantLegalAddressAreaCode,
  setParticipantLegalAddressAreaCode,
} from "@/utilities/getsetParticipantLegalAddressAreaCode.ts";
import {
  getParticipantLegalAddressRegionCode,
  setParticipantLegalAddressRegionCode,
} from "@/utilities/getsetParticipantLegalAddressRegionCode.ts";
import {
  getParticipantLegalAddressCityCode,
  setParticipantLegalAddressCityCode,
} from "@/utilities/getsetParticipantLegalAddressCityCode.ts";
import {
  getParticipantLegalAddressStreet,
  setParticipantLegalAddressStreet,
} from "@/utilities/getsetParticipantLegalAddressStreet.ts";
import {
  getParticipantLegalAddressHouse,
  setParticipantLegalAddressHouse,
} from "@/utilities/getsetParticipantLegalAddressHouse.ts";
import {
  getParticipantLegalAddressOffice,
  setParticipantLegalAddressOffice,
} from "@/utilities/getsetParticipantLegalAddressOffice.ts";
import {
  getParticipantLegalAddressPostCode,
  setParticipantLegalAddressPostCode,
} from "@/utilities/getsetParticipantLegalAddressPostCode.ts";
import {
  getParticipantActualAddressCountry,
  setParticipantActualAddressCountry,
} from "@/utilities/getsetParticipantActualAddressCountry.ts";
import {
  getParticipantActualAddressAreaCode,
  setParticipantActualAddressAreaCode,
} from "@/utilities/getsetParticipantActualAddressAreaCode.ts";
import {
  getParticipantActualAddressRegionCode,
  setParticipantActualAddressRegionCode,
} from "@/utilities/getsetParticipantActualAddressRegionCode.ts";
import {
  getParticipantActualAddressCityCode,
  setParticipantActualAddressCityCode,
} from "@/utilities/getsetParticipantActualAddressCityCode.ts";
import {
  getParticipantActualAddressStreet,
  setParticipantActualAddressStreet,
} from "@/utilities/getsetParticipantActualAddressStreet.ts";
import {
  getParticipantActualAddressHouse,
  setParticipantActualAddressHouse,
} from "@/utilities/getsetParticipantActualAddressHouse.ts";
import {
  getParticipantActualAddressOffice,
  setParticipantActualAddressOffice,
} from "@/utilities/getsetParticipantActualAddressOffice.ts";
import {
  getParticipantActualAddressPostCode,
  setParticipantActualAddressPostCode,
} from "@/utilities/getsetParticipantActualAddressPostCode.ts";
import { useToast } from "primevue/usetoast";
import { getCountryCode } from "@/utilities/getCountryCode.ts";
import { checkUserRole } from "@/services/accessRight.ts";

const isOperator = ref<boolean>(false);
const isResponsible = ref<boolean>(false);

const route = useRoute();
let message = ref<MessageModel>({} as MessageModel);
const selectedParticipant = ref<Participant>();
const selectedReference = ref<Reference>();
const messageFields = ref<Field[]>([]);
const messageVersion = ref<Guid>();
const toast = useToast();

const handbookOperationView = ref<Handbook[]>([]);
const operationView = ref<Handbook | undefined>();
const handbookOperationStatus = ref<Handbook[]>([]);
const operationStatus = ref<Handbook | undefined>();
const transactionDate = ref<Date>();
const handbookReasonFiling = ref<Handbook[]>([]);
const reasonFiling = ref<Handbook | undefined>();
const handbookCounterMeasure = ref<Handbook[]>([]);
const counterMeasure = ref<Handbook | undefined>();
const handbookOrganisationCode = ref<Handbook[]>([]);
const organisationCode = ref<Handbook | undefined>();
const handbookOrganisationOPF = ref<Handbook[]>([]);
const organisationOPF = ref<Handbook | undefined>();
const handbookOrganisationArea = ref<Handbook[]>([]);
const organisationArea = ref<Handbook | undefined>();
const handbookOrganisationDistrict = ref<Handbook[]>([]);
const organisationDistrict = ref<Handbook | undefined>();
const handbookOperationType = ref<Handbook[]>();
const operationType = ref<Handbook | undefined>();
const handbookMerchTypes = ref<Handbook[]>();
const merchType = ref<Handbook | undefined>();
const handbookOperationEknp = ref<Handbook[]>([]);
const operationEknp = ref<Handbook | undefined>();
const handbookCurrencyCode = ref<Handbook[]>([]);
const currencyCode = ref<Handbook | undefined>();
const handbookOperationReason = ref<Handbook[]>([]);
const operationReason = ref<Handbook | undefined>();
const handbookSuspicionFirst = ref<Handbook[]>([]);
const suspicionFirst = ref<Handbook | undefined>();
const handbookSuspicionSecond = ref<Handbook[]>([]);
const suspicionSecond = ref<Handbook | undefined>();
const handbookParticipant = ref<Handbook[]>([]);
const participant = ref<Handbook | undefined>();
const handbookIsClientSubject = ref<Handbook[]>([]);
const clientSubject = ref<Handbook | undefined>();
const handbookParticipantKind = ref<Handbook[]>([]);
const participantKind = ref<Handbook | undefined>();
const handbookParticipantResidence = ref<Handbook[]>([]);
const participantResidence = ref<Handbook | undefined>();
const handbookParticipantType = ref<Handbook[]>([]);
const participantType = ref<Handbook | undefined>();
const handbookParticipantForeignPerson = ref<Handbook[]>([]);
const participantForeignPerson = ref<Handbook | undefined>();
const handbookParticipantBankCountry = ref<Handbook[]>([]);
const participantBankCountry = ref<Handbook | undefined>();
const handbookParticipantMoneyTransferSystem = ref<Handbook[]>([]);
const participantMoneyTransferSystem = ref<Handbook | undefined>();
const handbookParticipantDocumentCode = ref<Handbook[]>([]);
const participantDocumentCode = ref<Handbook | undefined>();
const handbookParticipantLegalAddressCountry = ref<Handbook[]>([]);
const participantLegalAddressCountry = ref<Handbook | undefined>();
const handbookParticipantLegalAddressAreaCode = ref<Handbook[]>([]);
const participantLegalAddressAreaCode = ref<Handbook | undefined>();
const handbookParticipantLegalAddressRegionCode = ref<Handbook[]>([]);
const participantLegalAddressRegionCode = ref<Handbook | undefined>();
const handbookParticipantLegalAddressCityCode = ref<Handbook[]>([]);
const participantLegalAddressCity = ref<Handbook | undefined>();
const handbookParticipantActualAddressCountry = ref<Handbook[]>([]);
const participantActualAddressCountry = ref<Handbook | undefined>();
const handbookParticipantActualAddressAreaCode = ref<Handbook[]>([]);
const participantActualAddressAreaCode = ref<Handbook | undefined>();
const handbookParticipantActualAddressRegionCode = ref<Handbook[]>([]);
const participantActualAddressRegionCode = ref<Handbook | undefined>();
const handbookParticipantActualAddressCityCode = ref<Handbook[]>([]);
const participantActualAddressCityCode = ref<Handbook | undefined>();
const operationNumber = ref<string>();
const merchRegInfo = ref<string>();
const participantCount = ref<string>();
const operationAmount = ref<string>();
const operationAmountTenge = ref<string>();
const docOperationDate = ref<Date>();
const docOperationNumber = ref<string>();
const descriptionDifficulties = ref<string>();
const moreInformation = ref<string>();
const participantBankCity = ref<string>();
const participantBankName = ref<string>();
const participantBankCode = ref<string>();
const participantBankAccountNumber = ref<string>();
const participantIIN = ref<string>();
const participantLastName = ref<string>();
const participantFirstName = ref<string>();
const participantMiddleName = ref<string>();
const participantDocumentNumber = ref<string>();
const participantDocumentSeries = ref<string>();
const participantDocumentIssuedBy = ref<string>();
const participantDocumentDate = ref<Date>();
const participantDateOfBirth = ref<Date>();
const participantPlaceOfBirth = ref<string>();
const participantLegalAddressStreet = ref<string>();
const participantLegalAddressHouse = ref<string>();
const participantLegalAddressOffice = ref<string>();
const participantLegalAddressPostCode = ref<string>();
const participantPhoneNumber = ref<string>();
const participantEmail = ref<string>();
const participantActualAddressStreet = ref<string>();
const participantActualAddressHouse = ref<string>();
const participantActualAddressOffice = ref<string>();
const participantActualAddressPostCode = ref<string>();
const participantAdditionalInfo = ref<string>();

const isImpossibleSetFIO = ref<boolean | undefined>(false);
const impossibleSetEknp = ref<boolean>();
const isReasonFilingFishilyOperation = ref<boolean>(false);
const is1811MerchType = ref<boolean>(false);
const sfmIsPerson = ref<boolean>();
const referenceOperationNumber = ref<string>();
const referenceDocOperationDate = ref<Date>();
const referenceDocOperationNumber = ref<string>();
const referenceId = ref<string>();

const props = defineProps<{
  editable?: string;
}>();

function referenceDataTableSelected() {
  referenceOperationNumber.value =
    selectedReference.value?.referenceOperationNumber!;
  referenceDocOperationDate.value = getDateFromString(
    selectedReference.value?.referenceDocOperationDate!,
  );
  referenceDocOperationNumber.value =
    selectedReference.value?.referenceDocOperationNumber!;
  referenceId.value = selectedReference.value!.referenceId!;
}

function referenceDataTableUnselected() {
  referenceOperationNumber.value = undefined;
  referenceDocOperationDate.value = undefined;
  referenceDocOperationNumber.value = undefined;
  referenceId.value = undefined;
  selectedReference.value = undefined;
}

function referenceDeleteEvent() {
  if (!selectedReference.value) {
    toast.add({
      severity: "error",
      summary: "Ошибка",
      detail: "Выберите запись",
      life: 3000,
    });
    return;
  }

  message!.value!.references!.reference =
    message?.value?.references?.reference?.filter(
      (a) => a.referenceId !== selectedReference.value?.referenceId!,
    );
  referenceDataTableUnselected();
}

function referenceAddEvent() {
  let rf = new Reference();
  rf.referenceDocOperationDate =
    referenceDocOperationDate.value?.toLocaleDateString()!;
  rf.referenceDocOperationNumber = referenceDocOperationNumber.value!;
  rf.referenceOperationNumber = referenceOperationNumber.value!;
  rf.referenceId = (
    message?.value?.references?.reference?.length! + 1
  ).toString()!;

  message.value?.references?.reference?.push(rf);
  referenceDataTableUnselected();
}

function getDataCode(fieldName?: string): number {
  return messageFields.value?.find((a) => a.id === fieldName)?.datacode!;
}

function isReasonFilingFishilyOperationEvent() {
  isReasonFilingFishilyOperation.value = [
    "2",
    "4",
    "8",
    "11",
    "3",
    "14",
  ].includes(reasonFiling.value?.code!);
}

const updateOperationTypeEvent = () => {
  is1811MerchType.value = operationType.value?.code == "1811";
};

function participantDataTableClicked() {
  if (!selectedParticipant.value) return;

  participant.value = handbookParticipant.value.find(
    (a) => a.code === selectedParticipant!.value!.memberId,
  );
  clientSubject.value = handbookIsClientSubject.value.find(
    (a) => a.code === selectedParticipant.value!.isClientSubject,
  );
  participantKind.value = handbookParticipantKind.value.find(
    (a) => a.code === selectedParticipant.value!.participantsView,
  );
  participantResidence.value = handbookParticipantResidence.value.find((a) =>
    a.shortName?.startsWith(selectedParticipant.value!.residence!),
  );
  participantType.value = handbookParticipantType.value.find(
    (a) => a.code === selectedParticipant.value!.participantsType,
  );
  participantForeignPerson.value = handbookParticipantForeignPerson.value.find(
    (a) => a.code === selectedParticipant.value!.foreignPerson,
  );
  participantBankCountry.value = handbookParticipantBankCountry.value.find(
    (a) =>
      a.shortName?.startsWith(
        selectedParticipant.value!.correspondentBank?.bankCountry!,
      ),
  );
  participantBankCity.value =
    selectedParticipant.value!.correspondentBank?.bankCity;
  participantBankName.value =
    selectedParticipant.value!.correspondentBank?.name;
  participantMoneyTransferSystem.value =
    handbookParticipantMoneyTransferSystem.value!.find(
      (a) => a.code === selectedParticipant.value!.moneyTransSys,
    );
  participantBankCode.value =
    selectedParticipant.value!.correspondentBank?.code;
  participantBankAccountNumber.value =
    selectedParticipant.value!.correspondentBank?.accountNumber;
  participantIIN.value = selectedParticipant.value!.individualIssue;
  participantLastName.value = getParticipantLastName(
    selectedParticipant.value!.participantsType,
    selectedParticipant.value,
  );
  participantFirstName.value = getParticipantFirstName(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantMiddleName.value = getParticipantMiddleName(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  isImpossibleSetFIO.value = getParticipantSetFIO(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  )!;
  participantDocumentCode.value = getDocumentIdentityHandbook(
    handbookParticipantDocumentCode.value,
    selectedParticipant.value!.participantsType,
    selectedParticipant.value!,
  );
  participantDocumentNumber.value = getParticipantDocNumber(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantDocumentSeries.value = getParticipantDocSeries(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantDocumentIssuedBy.value = getParticipantDocumentIssuedBy(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantDocumentDate.value = getParticipantDocumentDate(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantDateOfBirth.value = getParticipantDateOfBirth(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantPlaceOfBirth.value = getParticipantPlaceOfBirth(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantLegalAddressCountry.value = getParticipantLegalAddressCountry(
    handbookParticipantLegalAddressCountry.value,
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantLegalAddressAreaCode.value = getParticipantLegalAddressAreaCode(
    handbookParticipantLegalAddressAreaCode.value,
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantLegalAddressRegionCode.value =
    getParticipantLegalAddressRegionCode(
      handbookParticipantLegalAddressRegionCode.value,
      selectedParticipant.value!,
      selectedParticipant.value!.participantsType,
    );
  participantLegalAddressCity.value = getParticipantLegalAddressCityCode(
    handbookParticipantLegalAddressCityCode.value,
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantLegalAddressStreet.value = getParticipantLegalAddressStreet(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantLegalAddressHouse.value = getParticipantLegalAddressHouse(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantLegalAddressOffice.value = getParticipantLegalAddressOffice(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantLegalAddressPostCode.value = getParticipantLegalAddressPostCode(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantPhoneNumber.value = selectedParticipant.value!.phoneNumber;
  participantEmail.value = selectedParticipant.value!.email;
  participantActualAddressCountry.value = getParticipantActualAddressCountry(
    handbookParticipantActualAddressCountry.value,
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantActualAddressAreaCode.value = getParticipantActualAddressAreaCode(
    handbookParticipantActualAddressAreaCode.value,
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantActualAddressRegionCode.value =
    getParticipantActualAddressRegionCode(
      handbookParticipantActualAddressRegionCode.value,
      selectedParticipant.value!,
      selectedParticipant.value!.participantsType,
    );
  participantActualAddressCityCode.value = getParticipantActualAddressCityCode(
    handbookParticipantActualAddressCityCode.value,
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantActualAddressStreet.value = getParticipantActualAddressStreet(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantActualAddressHouse.value = getParticipantActualAddressHouse(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantActualAddressOffice.value = getParticipantActualAddressOffice(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantActualAddressPostCode.value = getParticipantActualAddressPostCode(
    selectedParticipant.value!,
    selectedParticipant.value!.participantsType,
  );
  participantAdditionalInfo.value =
    selectedParticipant.value!.additionalInformation;
}

function changedParticipantFields() {
  if (selectedParticipant?.value == undefined) {
    return;
  }

  let prtc = message.value.participants?.participant?.find(
    (a) => a.memberId === selectedParticipant.value!.memberId,
  )!;
  prtc.memberId = participant.value?.code!;
  prtc.isClientSubject = clientSubject.value?.code!;
  prtc.participantsView = participantKind.value?.code!;
  prtc.residence = getCountryCode(participantResidence.value!)!;
  prtc.participantsType = participantType.value?.code!;
  prtc.foreignPerson = participantForeignPerson.value?.code!;
  prtc.correspondentBank!.bankCountry = getCountryCode(
    participantBankCountry.value!,
  )!;
  prtc.correspondentBank!.bankCity = participantBankCity.value!;
  prtc.correspondentBank!.name = participantBankName.value!;
  prtc.moneyTransSys = participantMoneyTransferSystem.value?.code?.toString()!;
  prtc.correspondentBank!.code = participantBankCode.value!;
  prtc.correspondentBank!.accountNumber = participantBankAccountNumber.value!;
  prtc.individualIssue = participantIIN.value!;
  setParticipantLastName(
    selectedParticipant.value.participantsType,
    prtc,
    participantLastName.value!,
  );
  setParticipantFirstName(
    selectedParticipant.value.participantsType,
    prtc,
    participantFirstName.value!,
  );
  setParticipantMiddleName(
    selectedParticipant.value.participantsType,
    prtc,
    participantMiddleName.value!,
  );
  setParticipantSetFIO(
    selectedParticipant.value.participantsType,
    prtc,
    isImpossibleSetFIO.value!,
  );
  setDocumentIdentityHandbook(
    participantDocumentCode.value!,
    selectedParticipant.value.participantsType,
    prtc,
  );
  setParticipantDocNumber(
    selectedParticipant.value.participantsType,
    prtc,
    participantDocumentNumber.value!,
  );
  setParticipantDocSeries(
    selectedParticipant.value.participantsType,
    prtc,
    participantDocumentSeries.value!,
  );
  setParticipantDocumentIssuedBy(
    selectedParticipant.value.participantsType,
    prtc,
    participantDocumentIssuedBy.value!,
  );
  setParticipantDocumentDate(
    prtc,
    selectedParticipant.value.participantsType,
    participantDocumentDate.value!,
  );
  setParticipantDateOfBirth(
    prtc,
    selectedParticipant.value.participantsType,
    participantDateOfBirth.value!,
  );
  setParticipantPlaceOfBirth(
    selectedParticipant.value.participantsType,
    prtc,
    participantPlaceOfBirth.value!,
  );
  setParticipantLegalAddressCountry(
    selectedParticipant.value.participantsType,
    prtc,
    participantLegalAddressCountry.value!,
  );
  setParticipantLegalAddressAreaCode(
    selectedParticipant.value.participantsType,
    prtc,
    participantLegalAddressAreaCode.value!,
  );
  setParticipantLegalAddressRegionCode(
    selectedParticipant.value.participantsType,
    prtc,
    participantLegalAddressRegionCode.value!,
  );
  setParticipantLegalAddressCityCode(
    selectedParticipant.value.participantsType,
    prtc,
    participantLegalAddressCity.value!,
  );
  setParticipantLegalAddressStreet(
    selectedParticipant.value.participantsType,
    prtc,
    participantLegalAddressStreet.value!,
  );
  setParticipantLegalAddressHouse(
    selectedParticipant.value.participantsType,
    prtc,
    participantLegalAddressHouse.value!,
  );
  setParticipantLegalAddressOffice(
    selectedParticipant.value.participantsType,
    prtc,
    participantLegalAddressOffice.value!,
  );
  setParticipantLegalAddressPostCode(
    selectedParticipant.value.participantsType,
    prtc,
    participantLegalAddressPostCode.value!,
  );
  prtc.phoneNumber = participantPhoneNumber.value!;
  prtc.email = participantEmail.value!;
  setParticipantActualAddressCountry(
    selectedParticipant.value.participantsType,
    prtc,
    participantActualAddressCountry.value!,
  );
  setParticipantActualAddressAreaCode(
    selectedParticipant.value.participantsType,
    prtc,
    participantActualAddressAreaCode.value!,
  );
  setParticipantActualAddressRegionCode(
    selectedParticipant.value.participantsType,
    prtc,
    participantActualAddressRegionCode.value!,
  );
  setParticipantActualAddressCityCode(
    selectedParticipant.value.participantsType,
    prtc,
    participantActualAddressCityCode.value!,
  );
  setParticipantActualAddressStreet(
    selectedParticipant.value.participantsType,
    prtc,
    participantActualAddressStreet.value!,
  );
  setParticipantActualAddressHouse(
    selectedParticipant.value.participantsType,
    prtc,
    participantActualAddressHouse.value!,
  );
  setParticipantActualAddressOffice(
    selectedParticipant.value.participantsType,
    prtc,
    participantActualAddressOffice.value!,
  );
  setParticipantActualAddressPostCode(
    selectedParticipant.value.participantsType,
    prtc,
    participantActualAddressPostCode.value!,
  );
  prtc.additionalInformation = participantAdditionalInfo.value!;

  console.log(message.value);
}

async function getHandbooksWithVersion() {
  // ТАБ: Сведения о форме ФМ-1
  handbookOperationView.value = await GetHandbookWithVersion(
    getDataCode("MessageType"),
    messageVersion.value,
  );
  operationView.value = handbookOperationView.value.find(
    (a) => a.code === message.value.messageInformation?.documentType,
  );

  handbookOperationStatus.value = await GetHandbookWithVersion(
    getDataCode("OperationStatus"),
    messageVersion.value,
  );
  operationStatus.value = handbookOperationStatus.value.find(
    (a) => a.code === message.value.messageInformation?.operationStatusId,
  );

  transactionDate.value = getDateFromString(
    message.value.messageInformation?.transactionDate!,
  );

  handbookReasonFiling.value = await GetHandbookWithVersion(
    getDataCode("MessageReason"),
    messageVersion.value,
  );
  reasonFiling.value = handbookReasonFiling.value.find(
    (a) => a.code === message.value.messageInformation?.reasonFilingId,
  );
  isReasonFilingFishilyOperation.value = [
    "2",
    "4",
    "8",
    "11",
    "3",
    "14",
  ].includes(reasonFiling.value?.code!);

  handbookCounterMeasure.value = await GetHandbookWithVersion(
    getDataCode("CounterMeasure"),
    messageVersion.value,
  );
  counterMeasure.value = handbookCounterMeasure.value.find(
    (a) => a.code === message.value.messageInformation?.counterMeasure,
  );

  handbookOrganisationCode.value = await GetHandbookWithVersion(
    getDataCode("SfmCode"),
    messageVersion.value,
  );
  organisationCode.value = handbookOrganisationCode.value.find(
    (a) => a.code === message.value.personalData?.organisationCode,
  );

  handbookOrganisationOPF.value = await GetHandbookWithVersion(
    getDataCode("SfmOpfCode"),
    messageVersion.value,
  );
  organisationOPF.value = handbookOrganisationOPF.value.find(
    (a) => a.code === message.value.personalData?.organisationOPF,
  );

  handbookOrganisationArea.value = await GetHandbookWithVersion(
    getDataCode("SfmAreaCode"),
    messageVersion.value,
  );
  organisationArea.value = handbookOrganisationArea.value.find(
    (a) => a.code === message.value.personalData?.organisationArea?.code,
  );

  handbookOrganisationDistrict.value = await GetHandbookWithVersion(
    getDataCode("SfmRegionCode"),
    messageVersion.value,
  );
  organisationDistrict.value = handbookOrganisationDistrict.value.find(
    (a) => a.code === message.value.personalData?.organisationDistrict?.code,
  );

  // ТАБ: Операция
  operationNumber.value = message.value.messageInformation?.operationNumber;

  handbookOperationType.value = await GetHandbookWithVersion(
    getDataCode("OperationType"),
    messageVersion.value,
  );
  operationType.value = handbookOperationType.value.find(
    (a) => a.code === message.value.messageInformation?.viewOperationId,
  );

  handbookMerchTypes.value = await GetHandbookWithVersion(
    getDataCode("AssetCode"),
    messageVersion.value,
  );
  merchType.value = handbookMerchTypes.value.find(
    (a) => a.code === message.value.messageInformation?.merchTypes,
  );
  is1811MerchType.value = merchType.value?.code == "1811";

  merchRegInfo.value = message.value.messageInformation?.merchReginfo;

  handbookOperationEknp.value = await GetHandbookWithVersion(
    getDataCode("OperationEknp"),
    messageVersion.value,
  );
  operationEknp.value = handbookOperationEknp.value.find(
    (a) => a.code == message.value.messageInformation?.eknpId?.text,
  );

  impossibleSetEknp.value =
    String(message.value.messageInformation?.eknpId?.isEknpNotSetup) === "true";

  participantCount.value = message.value.messageInformation?.participantCount;

  handbookCurrencyCode.value = await GetHandbookWithVersion(
    getDataCode("OperationCurrency"),
    messageVersion.value,
  );
  currencyCode.value = handbookCurrencyCode.value.find(
    (a) => a.code === message.value.messageInformation?.currencyCodeId,
  );

  operationAmount.value = message.value.messageInformation?.amountCurrency;

  operationAmountTenge.value =
    message.value.messageInformation?.amountCurrencyTenge;

  handbookOperationReason.value = await GetHandbookWithVersion(
    getDataCode("OperationReason"),
    messageVersion.value,
  );
  operationReason.value = handbookOperationReason.value.find(
    (a) => a.code === message.value.messageInformation?.docOperationReason,
  );

  docOperationDate.value = getDateFromString(
    message.value.messageInformation?.docOperationDate!,
  );

  docOperationNumber.value =
    message.value.messageInformation?.docOperationNumber;

  handbookSuspicionFirst.value = await GetHandbookWithVersion(
    getDataCode("SuspicionSign1"),
    messageVersion.value,
  );
  suspicionFirst.value = handbookSuspicionFirst.value.find(
    (a) => a.code === message.value.messageInformation?.suspicionFirst,
  );

  handbookSuspicionSecond.value = await GetHandbookWithVersion(
    getDataCode("SuspicionSign2"),
    messageVersion.value,
  );
  suspicionSecond.value = handbookSuspicionSecond.value.find(
    (a) => a.code === message.value.messageInformation?.suspicionSecond,
  );

  descriptionDifficulties.value =
    message.value.messageInformation?.descriptionDifficulties;

  moreInformation.value = message.value.messageInformation?.moreInformation;

  // ТАБ: Участники
  handbookParticipant.value = await GetHandbookWithVersion(
    getDataCode("Participant"),
    messageVersion.value,
  );

  handbookIsClientSubject.value = await GetHandbookWithVersion(
    getDataCode("ParticipantIsSfmClient"),
    messageVersion.value,
  );

  handbookParticipantKind.value = await GetHandbookWithVersion(
    getDataCode("ParticipantKind"),
    messageVersion.value,
  );

  handbookParticipantResidence.value = await GetHandbookWithVersion(
    getDataCode("ParticipantResidence"),
    messageVersion.value,
  );

  handbookParticipantType.value = await GetHandbookWithVersion(
    getDataCode("ParticipantType"),
    messageVersion.value,
  );

  handbookParticipantForeignPerson.value = await GetHandbookWithVersion(
    getDataCode("ParticipantForeignPerson"),
    messageVersion.value,
  );

  handbookParticipantBankCountry.value = await GetHandbookWithVersion(
    getDataCode("ParticipantBankCountry"),
    messageVersion.value,
  );

  handbookParticipantMoneyTransferSystem.value = await GetHandbookWithVersion(
    getDataCode("ParticipantMoneyTransferSystem"),
    messageVersion.value,
  );

  handbookParticipantDocumentCode.value = await GetHandbookWithVersion(
    getDataCode("IEParticipantDocumentCode"),
    messageVersion.value,
  );

  handbookParticipantLegalAddressCountry.value = await GetHandbookWithVersion(
    getDataCode("IEParticipantLegalAddressCountry"),
    messageVersion.value,
  );

  handbookParticipantLegalAddressAreaCode.value = await GetHandbookWithVersion(
    getDataCode("IEParticipantLegalAddressAreaCode"),
    messageVersion.value,
  );

  handbookParticipantLegalAddressRegionCode.value =
    await GetHandbookWithVersion(
      getDataCode("IEParticipantLegalAddressRegionCode"),
      messageVersion.value,
    );

  handbookParticipantLegalAddressCityCode.value = await GetHandbookWithVersion(
    getDataCode("IEParticipantLegalAddressCityCode"),
    messageVersion.value,
  );

  handbookParticipantActualAddressCountry.value = await GetHandbookWithVersion(
    getDataCode("IEParticipantActualAddressCountry"),
    messageVersion.value,
  );

  handbookParticipantActualAddressAreaCode.value = await GetHandbookWithVersion(
    getDataCode("IEParticipantActualAddressAreaCode"),
    messageVersion.value,
  );

  handbookParticipantActualAddressRegionCode.value =
    await GetHandbookWithVersion(
      getDataCode("IEParticipantActualAddressRegionCode"),
      messageVersion.value,
    );

  handbookParticipantActualAddressCityCode.value = await GetHandbookWithVersion(
    getDataCode("IEParticipantActualAddressCityCode"),
    messageVersion.value,
  );

  sfmIsPerson.value =
    message.value.personalData?.additionalAcData?.isAc == true;
}

async function saveMessage() {
  message.value.messageInformation!.operationStatusId =
    operationStatus.value?.code!;
  message.value.messageInformation!.transactionDate = `${transactionDate.value?.toLocaleDateString()!} ${transactionDate.value?.toLocaleTimeString()!}`;
  message.value.messageInformation!.reasonFilingId = reasonFiling.value?.code!;
  message.value.messageInformation!.counterMeasure =
    counterMeasure.value?.code!;
  message.value.messageInformation!.operationNumber = operationNumber.value!;
  message.value.messageInformation!.viewOperationId =
    operationType.value?.code!;
  message.value.messageInformation!.merchTypes =
    merchType.value?.code!.toString()!;
  message.value.messageInformation!.merchReginfo = merchRegInfo.value!;
  message.value.messageInformation!.eknpId!.text =
    operationEknp.value === undefined ? "" : operationEknp.value?.code!;
  message.value.messageInformation!.eknpId!.isEknpNotSetup =
    impossibleSetEknp.value!;
  message.value.messageInformation!.participantCount = participantCount.value!;
  message.value.messageInformation!.currencyCodeId = currencyCode.value?.code!;
  message.value.messageInformation!.amountCurrency = operationAmount.value!;
  message.value.messageInformation!.amountCurrencyTenge =
    operationAmountTenge.value!;
  message.value.messageInformation!.docOperationReason =
    operationReason.value?.code!;
  message.value.messageInformation!.docOperationDate =
    docOperationDate.value?.toLocaleDateString()!;
  message.value.messageInformation!.docOperationNumber =
    docOperationNumber.value!;
  message.value.messageInformation!.suspicionFirst =
    suspicionFirst.value?.code!;
  message.value.messageInformation!.suspicionSecond =
    suspicionSecond.value?.code!;
  message.value.messageInformation!.descriptionDifficulties =
    descriptionDifficulties.value!;
  message.value.messageInformation!.moreInformation = moreInformation.value!;
  message.value.personalData!.additionalAcData!.isAc = sfmIsPerson.value!;
  // message.value.messageInformation!.OperationNumber = operationNumber.value!;
  // message.value.messageInformation!.ViewOperationId =
  //   operationType.value?.code!;
  // message.value.messageInformation!.MerchTypes =
  //   merchType.value?.code!.toString()!;
  // message.value.messageInformation!.MerchReginfo = merchRegInfo.value!;
  // message.value.messageInformation!.EknpId["#text"] =
  //   operationEknp.value === undefined
  //     ? ""
  //     : operationEknp.value?.code!.toString()!;
  // message.value.messageInformation!.EknpId["@IsEknpNotSetup"] =
  //   impossibleSetEknp.value!;
  // message.value.messageInformation!.ParticipantCount = participantCount.value!;
  // message.value.messageInformation!.CurrencyCodeId = currencyCode.value?.code!;
  // message.value.messageInformation!.AmountCurrency = operationAmount.value!;
  // message.value.messageInformation!.AmountCurrencyTenge =
  //   operationAmountTenge.value!;
  // message.value.messageInformation!.DocOperationReason =
  //   operationReason.value?.code!;
  // message.value.messageInformation!.DocOperationDate =
  //   docOperationDate.value?.toLocaleDateString()!;
  // message.value.messageInformation!.DocOperationNumber =
  //   docOperationNumber.value!;
  // message.value.messageInformation!.SuspicionFirst =
  //   suspicionFirst.value?.code!;
  // message.value.messageInformation!.SuspicionSecond =
  //   suspicionSecond.value?.code!.toString()!;
  // message.value.messageInformation!.DescriptionDifficulties =
  //   descriptionDifficulties.value!;
  // message.value.messageInformation!.MoreInformation = moreInformation.value!;
  // message.value.PersonalData!.AdditionalAcData["@IsAc"] = String(
  //   sfmIsPerson.value!,
  // );

  let result = await UpdateMessageV6(
    parseInt(<string>route.params.id),
    message.value,
  );

  if (result == "0")
    toast.add({
      severity: "success",
      summary: "Успешно",
      detail: "Данные сохранены",
      life: 3000,
    });
  else
    toast.add({
      severity: "error",
      summary: "Ошибка",
      detail: `Ошибка при сохранении. Код ошибки: ${result}`,
      life: 6000,
    });
}

function closeWindow() {
  window.close();
}

async function toNextStage() {
  let result1 = await ToNextStage(parseInt(<string>route.params.id)!);

  if (result1 == "0")
    toast.add({
      severity: "success",
      summary: "Успешно",
      detail: "Документ успешно передан на следующую стадию",
      life: 3000,
    });
  else
    toast.add({
      severity: "error",
      summary: "Ошибка",
      detail: `Ошибка при передачи. Код ошибки: ${result1}`,
      life: 6000,
    });
}

async function toPreviousStage() {
  let result2 = await ToPreviousStage(parseInt(<string>route.params.id)!);

  if (result2 == "0")
    showSuccessToast("Документ успешно передан на прерыдущию стадию");
  else showErrorToast(`Ошибка при передачи. Код ошибки: ${result2}`);
}

async function exclude() {
  let re = await Exclude(parseInt(<string>route.params.id)!);

  if (re == "0") showSuccessToast("Документ успешно исключен");
  else
    showErrorToast("При исключении произошло ошибка. Код ошибки: (" + `${re})`);
}

const showSuccessToast = (text: string) => {
  toast.add({
    severity: "success",
    summary: "Успешно",
    detail: text,
    life: 3000,
  });
};

const showErrorToast = (text: string) => {
  toast.add({
    severity: "error",
    summary: "Ошибка",
    detail: text,
    life: 6000,
  });
};

async function fetchData(): Promise<void> {
  let msgV6JSON = await GetMessageV6ById(parseInt(<string>route.params.id));
  message.value = plainToClass(MessageModel, msgV6JSON as object);
  messageVersion.value = Guid.parse(message.value.version!);

  messageFields.value = await GetFields(messageVersion.value);
  await getHandbooksWithVersion();

  console.log(message.value);
}

const tooltipOptions = (str: string) => {
  return {
    value: str,
    showDelay: 1000,
    hideDelay: 300,
    class: "tw-text-[12px]",
  };
};

onMounted(async () => {
  await fetchData();
  isResponsible.value = await checkUserRole(4);
  isOperator.value = await checkUserRole(2);
});
</script>

<template>
  <div class="tw-min-h-screen tw-grid tw-grid-rows-[64px_40px_1fr_auto]">
    <ScrollTop />
    <MainHeader />
    <div
      class="tw-h-[40px] tw-ml-2 tw-flex tw-items-center tw-justify-between tw-w-[120px]"
      v-if="isOperator && props.editable == 'true'"
    >
      <span v-tooltip.right="tooltipOptions('Сохранить')">
        <an-outlined-save class="m-top-menu-icon" @click="saveMessage" />
      </span>
      <span v-tooltip.right="tooltipOptions('Передать следущую стадию')">
        <bs-arrow-right-circle class="m-top-menu-icon" @click="toNextStage" />
      </span>
      <span v-tooltip.right="tooltipOptions('Закрыть')">
        <an-outlined-close-circle
          class="m-top-menu-icon"
          @click="closeWindow"
        />
      </span>
    </div>
    <div
      class="tw-h-[40px] tw-ml-2 tw-flex tw-items-center tw-justify-between tw-w-[120px]"
      v-if="isResponsible"
    >
      <span v-tooltip.right="tooltipOptions('Передать на предыдущую стадию')">
        <bs-arrow-left-circle
          class="m-top-menu-icon"
          @click="toPreviousStage"
        />
      </span>
      <span v-tooltip.right="tooltipOptions('Исключить из обработки')">
        <an-outlined-minus-circle class="m-top-menu-icon" @click="exclude" />
      </span>
      <span v-tooltip.right="tooltipOptions('Закрыть')">
        <an-outlined-close-circle
          class="m-top-menu-icon"
          @click="closeWindow"
        />
      </span>
    </div>

    <TabView
      class="tw-h-full tw-bg-slate-100"
      :pt="{
        panelcontainer:
          'tw-w-[60%] tw-m-auto tw-my-4 tw-drop-shadow-md tw-rounded-lg tw-grid tw-py-4',
      }"
    >
      <TabPanel header="Сведения о форме ФМ-1">
        <Accordion :activeIndex="[0]" :multiple="true">
          <AccordionTab header="">
            <grid-container2-col>
              <field-name name="1.1 Номер формы ФМ-1" />
              <div>
                <o-input-number
                  :model-value="message.messageInformation?.messageNumber"
                  disabled
                />
              </div>

              <field-name name="1.2 Дата формы ФМ-1" />
              <div>
                <InputText
                  type="text"
                  :model-value="message.messageInformation?.lastModifyDate"
                  class="tw-w-full"
                  disabled
                />
              </div>

              <field-name name="1.3 Вид документа" />
              <div>
                <Dropdown
                  :model-value="operationView"
                  class="tw-w-full"
                  disabled
                  :options="handbookOperationView"
                  optionLabel="shortName"
                />
              </div>

              <field-name name="1.4 Состояние операции" />
              <div>
                <Dropdown
                  v-model="operationStatus"
                  class="tw-w-full"
                  :options="handbookOperationStatus"
                  optionLabel="shortName"
                />
              </div>

              <field-name name="Дата и время операции" />
              <div>
                <Calendar
                  v-model="transactionDate"
                  showIcon
                  class="tw-w-full"
                  :showOnFocus="false"
                  showTime
                  hourFormat="24"
                />
              </div>
            </grid-container2-col>

            <Fieldset legend="1.5 Основание для подачи сообщения">
              <grid-container2-col>
                <field-name name="1. Основание для подачи сообщения" />
                <div>
                  <Dropdown
                    v-model="reasonFiling"
                    class="tw-w-full"
                    :options="handbookReasonFiling"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    @update:model-value="isReasonFilingFishilyOperationEvent"
                  />
                </div>

                <field-name
                  name="4. Мера противодействия при совпадении с перечным организаций и лиц"
                  v-if="isReasonFilingFishilyOperation"
                />
                <div v-if="isReasonFilingFishilyOperation">
                  <Dropdown
                    v-model="counterMeasure"
                    class="tw-w-full"
                    :options="handbookCounterMeasure"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                  />
                </div>
              </grid-container2-col>
            </Fieldset>
          </AccordionTab>

          <AccordionTab header="1.1.2 Связь с иной формой">
            <DataTable
              :value="message.references?.reference"
              size="small"
              v-model:selection="selectedReference"
              selectionMode="single"
              @row-select="referenceDataTableSelected"
              @row-unselect="referenceDataTableUnselected"
            >
              <template #empty>
                <div
                  class="tw-flex tw-justify-center tw-items-center tw-my-[20px]"
                >
                  <div class="tw-italic">Нет данных</div>
                </div>
              </template>
              <Column field="referenceOperationNumber" header="Номер"></Column>
              <Column field="referenceDocOperationDate" header="Дата"></Column>
              <Column
                field="referenceDocOperationNumber"
                header="Номер операции"
              ></Column>
            </DataTable>

            <Fieldset legend="Детализация" :toggleable="true">
              <grid-container2-col>
                <field-name name="2.1 Номер связанной формы ФМ-1" />
                <div>
                  <OInputNumber
                    :model-value="referenceOperationNumber"
                    @update:model-value="referenceOperationNumber = $event"
                    :useGrouping="false"
                  />
                </div>

                <field-name name="2.2 Дата связанной формы ФМ-1" />
                <div>
                  <Calendar
                    showIcon
                    :showOnFocus="false"
                    class="tw-w-full"
                    v-model="referenceDocOperationDate"
                  />
                </div>

                <field-name name="Номер операции в связанной форме" />
                <div>
                  <OInputNumber
                    :model-value="referenceDocOperationNumber"
                    @update:model-value="referenceDocOperationNumber = $event"
                    :useGrouping="false"
                  />
                </div>
              </grid-container2-col>

              <div class="tw-flex tw-justify-between tw-mt-[10px]">
                <Button
                  label="Добавить"
                  class="tw-bg-[--primary-color] tw-border-[--primary-color]"
                  @click="referenceAddEvent"
                >
                </Button>
                <Button
                  label="Удалить"
                  severity="secondary"
                  @click="referenceDeleteEvent"
                >
                </Button>
              </div>
            </Fieldset>
          </AccordionTab>

          <AccordionTab
            header="2 Сведения о субъекте финансового мониторинга, направившим форму ФМ-1"
          >
            <grid-container2-col>
              <field-name name="2.1 Код субъекта финансового мониторинга" />
              <div>
                <Dropdown
                  v-model="organisationCode"
                  class="tw-w-full"
                  :options="handbookOrganisationCode"
                  optionLabel="shortName"
                  panel-class="tw-w-[200px]"
                  disabled
                />
              </div>
            </grid-container2-col>

            <Fieldset legend="2.2 Субъект финансового мониторинга">
              <grid-container2-col>
                <field-name name="1.1 Организационная форма" />
                <div>
                  <Dropdown
                    v-model="organisationOPF"
                    class="tw-w-full"
                    :options="handbookOrganisationOPF"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    disabled
                  />
                </div>

                <field-name name="1.2 Наименование" />
                <div>
                  <InputText
                    type="text"
                    :model-value="message.personalData?.organisation"
                    class="tw-w-full"
                    disabled
                  />
                </div>
              </grid-container2-col>
            </Fieldset>

            <grid-container2-col class="tw-mt-[10px]">
              <field-name name="2.4 ИИН/БИН" />
              <div>
                <InputText
                  type="text"
                  :model-value="message.personalData?.iinbin"
                  class="tw-w-full"
                  disabled
                />
              </div>
            </grid-container2-col>

            <Fieldset legend="2.5 Адрес места нахождения">
              <grid-container2-col>
                <field-name name="1. Область" />
                <div>
                  <Dropdown
                    v-model="organisationArea"
                    class="tw-w-full"
                    :options="handbookOrganisationArea"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    disabled
                  />
                </div>

                <field-name name="2. Район" />
                <div>
                  <Dropdown
                    v-model="organisationDistrict"
                    class="tw-w-full"
                    :options="handbookOrganisationDistrict"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    disabled
                  />
                </div>

                <field-name name="4. Наименование улицы / проспекта / мр-на" />
                <div>
                  <InputText
                    type="text"
                    :model-value="message.personalData?.organisationStreet"
                    class="tw-w-full"
                    disabled
                  />
                </div>

                <field-name name="5. Номер дома" />
                <div>
                  <o-input-number
                    :model-value="message.personalData?.organisationHouse"
                    class="tw-w-full"
                    disabled
                  />
                </div>

                <field-name name="6. Номер квартиры/офиса" />
                <div>
                  <InputText
                    :model-value="message.personalData?.organisationOffice"
                    class="tw-w-full"
                    disabled
                  />
                </div>

                <field-name name="7. Почтовой индекс" />
                <div>
                  <InputText
                    :model-value="message.personalData?.organisationPostalIndex"
                    class="tw-w-full"
                    disabled
                  />
                </div>
              </grid-container2-col>
            </Fieldset>

            <Fieldset
              legend="2.6 Документ, удостоверяющий личность (для физических лиц)"
            >
              <grid-container2-col>
                <field-name
                  name="2.6.1. Номер и серия документа, удостоверяющего личность (для физических лиц)"
                />
                <div>
                  <InputText
                    :model-value="
                      message.personalData?.additionalAcData?.numberDocIdentity
                    "
                    class="tw-w-full"
                    disabled
                  />
                </div>
              </grid-container2-col>
            </Fieldset>
          </AccordionTab>

          <AccordionTab header="2.7 Ответственное должностное лицо">
            <grid-container2-col>
              <field-name name="1. Фамилия" />
              <div>
                <InputText
                  :model-value="message.personalData?.secondName"
                  class="tw-w-full"
                  disabled
                />
              </div>

              <field-name name="2. Имя" />
              <div>
                <InputText
                  :model-value="message.personalData?.firstName"
                  class="tw-w-full"
                  disabled
                />
              </div>

              <field-name name="3. Отчество" />
              <div>
                <InputText
                  :model-value="message.personalData?.middleName"
                  class="tw-w-full"
                  disabled
                />
              </div>

              <field-name
                name="2.7.1 Должность ответсвенного должностного лица"
              />
              <div>
                <InputText
                  :model-value="message.personalData?.jobName"
                  class="tw-w-full"
                  disabled
                />
              </div>

              <field-name name="2.8 Контактные телефоны" />
              <div>
                <InputText
                  :model-value="message.personalData?.phone"
                  class="tw-w-full"
                  disabled
                />
              </div>

              <field-name name="2.9 Электронная почта" />
              <div>
                <InputText
                  :model-value="message.personalData?.email"
                  class="tw-w-full"
                  disabled
                />
              </div>
            </grid-container2-col>
          </AccordionTab>
        </Accordion>
      </TabPanel>

      <TabPanel header="Операция">
        <Fieldset legend="3. Операция">
          <grid-container2-col>
            <field-name name="3.1 Номер операции" />
            <div>
              <OInputNumber
                :model-value="operationNumber"
                @update:model-value="operationNumber = $event"
                :use-grouping="false"
              />
            </div>
          </grid-container2-col>
        </Fieldset>

        <Fieldset legend="3.2 Код вида операции">
          <grid-container2-col>
            <field-name name="1. Код" />
            <div>
              <Dropdown
                v-model="operationType"
                class="tw-w-full"
                :options="handbookOperationType"
                optionLabel="shortName"
                panel-class="tw-w-[200px]"
                @update:model-value="updateOperationTypeEvent"
              />
            </div>
          </grid-container2-col>
          <Fieldset
            legend="2 Информация об имуществе, подлежащего обязательной государственной регистрации"
            v-if="is1811MerchType"
          >
            <grid-container2-col>
              <field-name name="2.1 Вид имущество" />
              <div>
                <Dropdown
                  v-model="merchType"
                  class="tw-w-full"
                  :options="handbookMerchTypes"
                  optionLabel="shortName"
                  panel-class="tw-w-[200px]"
                />
              </div>

              <field-name name="2.2 Регистрационный номер имущества" />
              <div>
                <InputText v-model="merchRegInfo" class="tw-w-full" />
              </div>
            </grid-container2-col>
          </Fieldset>
        </Fieldset>

        <Fieldset legend="3.3 Код назначения платежа">
          <grid-container2-col>
            <field-name name="Код назначения платежа" />
            <div>
              <Dropdown
                v-model="operationEknp"
                class="tw-w-full"
                :options="handbookOperationEknp"
                optionLabel="shortName"
                panel-class="tw-w-[200px]"
                :disabled="impossibleSetEknp"
              />
            </div>

            <field-name name="Невозможно установить" />
            <div>
              <Checkbox v-model="impossibleSetEknp" :binary="true" />
            </div>
          </grid-container2-col>
        </Fieldset>

        <grid-container2-col class="tw-mt-[10px]">
          <field-name name="3.4 Количество участников операции" />
          <div>
            <OInputNumber
              :model-value="participantCount"
              @update:model-value="participantCount = $event"
            />
          </div>

          <field-name name="3.5 Код валюты операции" />
          <div>
            <Dropdown
              v-model="currencyCode"
              class="tw-w-full"
              :options="handbookCurrencyCode"
              optionLabel="shortName"
              panel-class="tw-w-[200px]"
            />
          </div>

          <field-name name="3.6 Сумма операции в валюте её проведения" />
          <div>
            <OInputNumber
              :model-value="operationAmount"
              locale="kz-KZ"
              :minFractionDigits="2"
              @update:model-value="operationAmount = $event"
            />
          </div>

          <field-name name="3.7 Сумма операции в тенге" />
          <div>
            <OInputNumber
              :model-value="operationAmountTenge"
              locale="kz-KZ"
              :minFractionDigits="2"
              @update:model-value="operationAmountTenge = $event"
            />
          </div>

          <field-name name="3.8 Основание совершения операции" />
          <div>
            <Dropdown
              v-model="operationReason"
              class="tw-w-full"
              :options="handbookOperationReason"
              optionLabel="shortName"
              panel-class="tw-w-[200px]"
            />
          </div>
        </grid-container2-col>

        <Fieldset
          legend="3.9 Дата и номер документа, на основании которого осуществляется операция"
        >
          <grid-container2-col>
            <field-name
              name="1. Дата документа, на основании которого осуществляется операция"
            />
            <div>
              <Calendar
                v-model="docOperationDate"
                showIcon
                class="tw-w-full"
                :showOnFocus="false"
                hourFormat="24"
              />
            </div>

            <field-name
              name="2. Номер документа, на основании которого осуществляется операция"
            />
            <div>
              <InputText
                type="text"
                v-model="docOperationNumber"
                class="tw-w-full"
              />
            </div>
          </grid-container2-col>
        </Fieldset>

        <grid-container2-col
          class="tw-mt-[10px]"
          v-if="isReasonFilingFishilyOperation"
        >
          <field-name name="3.10 Код признака подозрительности операции" />
          <div>
            <Dropdown
              v-model="suspicionFirst"
              class="tw-w-full"
              :options="handbookSuspicionFirst"
              optionLabel="shortName"
              panel-class="tw-w-[200px]"
            />
          </div>

          <field-name
            name="3.11 1-й дополнительный код признака подозрительности операции"
          />
          <div>
            <Dropdown
              v-model="suspicionSecond"
              class="tw-w-full"
              :options="handbookSuspicionSecond"
              optionLabel="shortName"
              panel-class="tw-w-[200px]"
            />
          </div>

          <!--                            Керек кезде жаса -->
          <!--                            <field-name name="3.12 2-й дополнительный код признака подозрительности операции" v-if="false" />-->
          <!--                            <div v-if="false">-->
          <!--                              <InputText type="text" :model-value="message.MessageInformation?.SuspicionThird"-->
          <!--                                         class="tw-w-full" />-->
          <!--                            </div>-->

          <field-name
            name="3.13 Описание возникших затруднений квалификации операции как подозрительной"
          />
          <div>
            <InputText
              type="text"
              v-model="descriptionDifficulties"
              class="tw-w-full"
            />
          </div>
        </grid-container2-col>

        <grid-container2-col class="tw-mt-[10px]">
          <field-name name="3.14 Дополнительная информация по операции" />
          <div>
            <Textarea
              v-model="moreInformation"
              rows="5"
              cols="30"
              class="tw-w-full"
            />
          </div>
        </grid-container2-col>
      </TabPanel>

      <TabPanel header="Участники">
        <div class="tw-w-full">
          <DataTable
            :value="message.participants?.participant"
            size="small"
            v-model:selection="selectedParticipant"
            selectionMode="single"
            @row-select="participantDataTableClicked"
            scrollable
            class="tw-w-[57.5vw]"
          >
            <Column
              field="memberId"
              header="Участник"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="isClientSubject"
              header="Клиент СФМ"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="participantsView"
              header="Вид участника"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="residence"
              header="Резиденство"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="participantsType"
              header="Тип участника операции"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="correspondentBank['@IsOffshore']"
              header="Банк/филиал находится в офшорной зоне"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="correspondentBank.BankCountry"
              header="Местонахождение филиала"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="correspondentBank.Name"
              header="Наименование банка/филиала"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="correspondentBank.Code"
              header="Код банка/филиала"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="correspondentBank.accountNumber"
              header="Номер счета участника"
              class="tw-min-w-[200px]"
            ></Column>
            <Column
              field="individualIssue"
              header="ИИН/БИН"
              class="tw-min-w-[200px]"
            ></Column>
          </DataTable>

          <Accordion :activeIndex="0">
            <AccordionTab header="Детализация">
              <grid-container2-col>
                <field-name name="4.1 Участник" />
                <div>
                  <Dropdown
                    v-model="participant"
                    class="tw-w-full"
                    :options="handbookParticipant"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    @change="changedParticipantFields"
                  />
                </div>

                <field-name
                  name="4.2 Клиент субъекта финансового мониторинга"
                />
                <div>
                  <Dropdown
                    v-model="clientSubject"
                    class="tw-w-full"
                    :options="handbookIsClientSubject"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    @change="changedParticipantFields"
                  />
                </div>

                <field-name name="4.3 Вид участника" />
                <div>
                  <Dropdown
                    v-model="participantKind"
                    class="tw-w-full"
                    :options="handbookParticipantKind"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    @change="changedParticipantFields"
                  />
                </div>

                <field-name name="4.4 Резиденство" />
                <div>
                  <Dropdown
                    v-model="participantResidence"
                    class="tw-w-full"
                    :options="handbookParticipantResidence"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    @change="changedParticipantFields"
                  />
                </div>

                <field-name name="4.5 Тип участника операции" />
                <div>
                  <Dropdown
                    v-model="participantType"
                    class="tw-w-full"
                    :options="handbookParticipantType"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    @change="changedParticipantFields"
                  />
                </div>

                <field-name name="4.6 Иностранное публичное должностное лицо" />
                <div>
                  <Dropdown
                    v-model="participantForeignPerson"
                    class="tw-w-full"
                    :options="handbookParticipantForeignPerson"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    @change="changedParticipantFields"
                  />
                </div>
              </grid-container2-col>

              <Fieldset legend="4.7 Банк участника операции">
                <grid-container2-col>
                  <field-name name="1.1 Местонахождение филиала" />
                  <div>
                    <Dropdown
                      v-model="participantBankCountry"
                      class="tw-w-full"
                      :options="handbookParticipantBankCountry"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name name="Населенный пункт" />
                  <div>
                    <InputText
                      v-model="participantBankCity"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="1.2 Наименование банка/филиала" />
                  <div>
                    <InputText
                      v-model="participantBankName"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="1.2.1 Наименование СДП" />
                  <div>
                    <Dropdown
                      v-model="participantMoneyTransferSystem"
                      class="tw-w-full"
                      :options="handbookParticipantMoneyTransferSystem"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name name="1.3 Код банка/филиала" />
                  <div>
                    <InputText
                      v-model="participantBankCode"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="1.4 Номер счета участника" />
                  <div>
                    <InputText
                      v-model="participantBankAccountNumber"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>
                </grid-container2-col>

                <!-- todo: FIX THIS LATER -->
                <Fieldset
                  legend="1.5 Сведения о корреспондентских счетах, участвующих в операции"
                >
                  <DataTable
                    :value="message.references?.reference"
                    size="small"
                    v-model:selection="selectedReference"
                    selectionMode="single"
                    @row-select="referenceDataTableSelected"
                    @row-unselect="referenceDataTableUnselected"
                  >
                    <template #empty>
                      <div
                        class="tw-flex tw-justify-center tw-items-center tw-my-[20px]"
                      >
                        <div class="tw-italic">Нет данных</div>
                      </div>
                    </template>
                    <Column
                      field="BankCountry"
                      header="Местонахождение банка"
                    ></Column>
                    <Column
                      field="BankName"
                      header="Наименование банка"
                    ></Column>
                  </DataTable>
                </Fieldset>
              </Fieldset>

              <grid-container2-col class="tw-mt-[10px]">
                <field-name name="4.13 ИИН/БИН" />
                <div>
                  <InputText
                    v-model="participantIIN"
                    class="tw-w-full"
                    @update:model-value="changedParticipantFields"
                  />
                </div>
              </grid-container2-col>

              <Fieldset legend="4.14 ФИО">
                <grid-container2-col>
                  <field-name name="1.1 Фамилия" />
                  <div>
                    <InputText
                      v-model="participantLastName"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                      :disabled="isImpossibleSetFIO"
                    />
                  </div>

                  <field-name name="1.2 Имя" />
                  <div>
                    <InputText
                      v-model="participantFirstName"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                      :disabled="isImpossibleSetFIO"
                    />
                  </div>

                  <field-name name="1.3 Отчество" />
                  <div>
                    <InputText
                      v-model="participantMiddleName"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                      :disabled="isImpossibleSetFIO"
                    />
                  </div>

                  <field-name name="2.1 Невозможно установить" />
                  <div>
                    <Checkbox
                      v-model="isImpossibleSetFIO"
                      :binary="true"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>
                </grid-container2-col>
              </Fieldset>

              <grid-container2-col class="tw-mt-[10px]">
                <field-name name="4.15 Документ, удостоверяющий личность" />
                <div>
                  <Dropdown
                    v-model="participantDocumentCode"
                    class="tw-w-full"
                    :options="handbookParticipantDocumentCode"
                    optionLabel="shortName"
                    panel-class="tw-w-[200px]"
                    @change="changedParticipantFields"
                  />
                </div>
              </grid-container2-col>

              <Fieldset
                legend="Номер и серия документа, удостоверяющий личность"
              >
                <grid-container2-col>
                  <field-name name="Серия" />
                  <div>
                    <InputText
                      v-model="participantDocumentSeries"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="Номер" />
                  <div>
                    <InputText
                      v-model="participantDocumentNumber"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>
                </grid-container2-col>
              </Fieldset>

              <grid-container2-col class="tw-mt-[10px]">
                <field-name name="4.17 Кем выдан удостоверяющий личность" />
                <div>
                  <InputText
                    v-model="participantDocumentIssuedBy"
                    class="tw-w-full"
                    @update:model-value="changedParticipantFields"
                  />
                </div>

                <field-name name="4.18 Когда выдан удостоверяющий личность" />
                <div>
                  <Calendar
                    v-model="participantDocumentDate"
                    class="tw-w-full"
                    @update:model-value="changedParticipantFields"
                    showIcon
                  />
                </div>

                <field-name name="4.19 Дата рождения" />
                <div>
                  <Calendar
                    v-model="participantDateOfBirth"
                    class="tw-w-full"
                    @update:model-value="changedParticipantFields"
                    showIcon
                  />
                </div>

                <field-name name="4.20 Место рождения" />
                <div>
                  <InputText
                    class="tw-w-full"
                    v-model="participantPlaceOfBirth"
                    @update:model-value="changedParticipantFields"
                  />
                </div>
              </grid-container2-col>

              <Fieldset legend="4.21 Юридический адрес">
                <grid-container2-col>
                  <field-name name="Страна" />
                  <div>
                    <Dropdown
                      v-model="participantLegalAddressCountry"
                      class="tw-w-full"
                      :options="handbookParticipantLegalAddressCountry"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name
                    name="1. Область (в том числе гг. Алматы и Астана)"
                  />
                  <div>
                    <Dropdown
                      v-model="participantLegalAddressAreaCode"
                      class="tw-w-full"
                      :options="handbookParticipantLegalAddressAreaCode"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name name="2. Район" />
                  <div>
                    <Dropdown
                      v-model="participantLegalAddressRegionCode"
                      class="tw-w-full"
                      :options="handbookParticipantLegalAddressRegionCode"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name name="3. Населенный пункт" />
                  <div>
                    <Dropdown
                      v-model="participantLegalAddressCity"
                      class="tw-w-full"
                      :options="handbookParticipantLegalAddressCityCode"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name
                    name="4. Наименование улицы / проспекта / мр-на"
                  />
                  <div>
                    <InputText
                      v-model="participantLegalAddressStreet"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="5. Номер дома" />
                  <div>
                    <InputText
                      v-model="participantLegalAddressHouse"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="6. Номер квартиры / офиса" />
                  <div>
                    <InputText
                      v-model="participantLegalAddressOffice"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="7. Почтовый индекс" />
                  <div>
                    <InputText
                      v-model="participantLegalAddressPostCode"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>
                </grid-container2-col>
              </Fieldset>

              <grid-container2-col class="tw-mt-[10px]">
                <field-name name="4.22 Номер контактного телефона" />
                <div>
                  <InputText
                    v-model="participantPhoneNumber"
                    class="tw-w-full"
                    @update:model-value="changedParticipantFields"
                  />
                </div>

                <field-name name="4.23 Электронная почта" />
                <div>
                  <InputText
                    v-model="participantEmail"
                    class="tw-w-full"
                    @update:model-value="changedParticipantFields"
                  />
                </div>
              </grid-container2-col>

              <Fieldset legend="4.24 Фактический адрес">
                <grid-container2-col>
                  <field-name name="Страна" />
                  <div>
                    <Dropdown
                      v-model="participantActualAddressCountry"
                      class="tw-w-full"
                      :options="handbookParticipantActualAddressCountry"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name
                    name="1. Область (в том числе гг. Алматы и Астана)"
                  />
                  <div>
                    <Dropdown
                      v-model="participantActualAddressAreaCode"
                      class="tw-w-full"
                      :options="handbookParticipantActualAddressAreaCode"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name name="2. Район" />
                  <div>
                    <Dropdown
                      v-model="participantActualAddressRegionCode"
                      class="tw-w-full"
                      :options="handbookParticipantActualAddressRegionCode"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name name="3. Населенный пункт" />
                  <div>
                    <Dropdown
                      v-model="participantActualAddressCityCode"
                      class="tw-w-full"
                      :options="handbookParticipantActualAddressCityCode"
                      optionLabel="shortName"
                      panel-class="tw-w-[200px]"
                      @change="changedParticipantFields"
                    />
                  </div>

                  <field-name
                    name="4. Наименование улицы / проспекта / мр-на"
                  />
                  <div>
                    <InputText
                      v-model="participantActualAddressStreet"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="5. Номер дома" />
                  <div>
                    <InputText
                      v-model="participantActualAddressHouse"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="6. Номер квартиры / офиса" />
                  <div>
                    <InputText
                      v-model="participantActualAddressOffice"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>

                  <field-name name="7. Почтовый индекс" />
                  <div>
                    <InputText
                      v-model="participantActualAddressPostCode"
                      class="tw-w-full"
                      @update:model-value="changedParticipantFields"
                    />
                  </div>
                </grid-container2-col>
              </Fieldset>

              <grid-container2-col class="tw-mt-[10px]">
                <field-name
                  name="4.25 Дополнительная информации об участнике операции"
                />
                <div>
                  <Textarea
                    v-model="participantAdditionalInfo"
                    rows="5"
                    cols="30"
                    class="tw-w-full"
                    @update:model-value="changedParticipantFields"
                  />
                </div>
              </grid-container2-col>
            </AccordionTab>
          </Accordion>
        </div>
      </TabPanel>
    </TabView>
  </div>
</template>

<style scoped></style>
