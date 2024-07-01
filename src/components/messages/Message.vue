<!--<script setup lang="ts">-->
<!--&lt;!&ndash;import { onMounted, ref } from "vue";&ndash;&gt;-->
<!--&lt;!&ndash;import { useRoute } from "vue-router";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  GetMessageById,&ndash;&gt;-->
<!--&lt;!&ndash;  GetFields,&ndash;&gt;-->
<!--&lt;!&ndash;  ToNextStage,&ndash;&gt;-->
<!--&lt;!&ndash;  ToPreviousStage,&ndash;&gt;-->
<!--&lt;!&ndash;  Exclude,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/api/finOpsAPI.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import { XMLBuilder, XMLParser } from "fast-xml-parser";&ndash;&gt;-->
<!--&lt;!&ndash;import { plainToClass } from "class-transformer";&ndash;&gt;-->
<!--&lt;!&ndash;import { Participant, Reference, Root } from "@/types/Root.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import { GetHandbookWithVersion, UpdateMessage } from "@/api/finOpsAPI.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import { Field } from "@/types/Field.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import { Guid } from "guid-typescript";&ndash;&gt;-->
<!--&lt;!&ndash;import { Handbook } from "@/types/Handbook.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import { getDateFromString } from "@/utilities/getDateFromString.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLastName,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLastName,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLastName.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantFirstName,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantFirstName,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantFirstName.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantMiddleName,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantMiddleName,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantMiddleName.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantSetFIO,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantSetFIO,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantSetFIO.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getDocumentIdentityHandbook,&ndash;&gt;-->
<!--&lt;!&ndash;  setDocumentIdentityHandbook,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetDocumentIdentity.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantDocNumber,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDocNumber,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantDocNumber.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantDocSeries,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDocSeries,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantDocSeries.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantDocumentIssuedBy,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDocumentIssuedBy,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantDocumentIssuedBy.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantDocumentDate,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDocumentDate,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantDocumentDate.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantDateOfBirth,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDateOfBirth,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantDateOfBirth.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantPlaceOfBirth,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantPlaceOfBirth,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantPlaceOfBirth.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLegalAddressCountry,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressCountry,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLegalAddressCountry.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLegalAddressAreaCode,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressAreaCode,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLegalAddressAreaCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLegalAddressRegionCode,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressRegionCode,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLegalAddressRegionCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLegalAddressCityCode,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressCityCode,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLegalAddressCityCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLegalAddressStreet,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressStreet,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLegalAddressStreet.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLegalAddressHouse,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressHouse,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLegalAddressHouse.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLegalAddressOffice,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressOffice,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLegalAddressOffice.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantLegalAddressPostCode,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressPostCode,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantLegalAddressPostCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantActualAddressCountry,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressCountry,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantActualAddressCountry.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantActualAddressAreaCode,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressAreaCode,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantActualAddressAreaCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantActualAddressRegionCode,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressRegionCode,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantActualAddressRegionCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantActualAddressCityCode,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressCityCode,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantActualAddressCityCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantActualAddressStreet,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressStreet,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantActualAddressStreet.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantActualAddressHouse,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressHouse,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantActualAddressHouse.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantActualAddressOffice,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressOffice,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantActualAddressOffice.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import {&ndash;&gt;-->
<!--&lt;!&ndash;  getParticipantActualAddressPostCode,&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressPostCode,&ndash;&gt;-->
<!--&lt;!&ndash;} from "@/utilities/getsetParticipantActualAddressPostCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import { useToast } from "primevue/usetoast";&ndash;&gt;-->
<!--&lt;!&ndash;import { getCountryCode } from "@/utilities/getCountryCode.ts";&ndash;&gt;-->
<!--&lt;!&ndash;import { checkUserRole } from "@/services/accessRight.ts";&ndash;&gt;-->

<!--&lt;!&ndash;const isOperator = ref<boolean>(false);&ndash;&gt;-->
<!--&lt;!&ndash;const isResponsible = ref<boolean>(false);&ndash;&gt;-->

<!--&lt;!&ndash;const route = useRoute();&ndash;&gt;-->
<!--&lt;!&ndash;const message = ref<Root>({} as Root);&ndash;&gt;-->
<!--&lt;!&ndash;const selectedParticipant = ref<Participant>();&ndash;&gt;-->
<!--&lt;!&ndash;const selectedReference = ref<Reference>();&ndash;&gt;-->
<!--&lt;!&ndash;const messageFields = ref<Field[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const messageVersion = ref<Guid>();&ndash;&gt;-->
<!--&lt;!&ndash;const toast = useToast();&ndash;&gt;-->

<!--&lt;!&ndash;const handbookOperationView = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const operationView = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookOperationStatus = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const operationStatus = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const transactionDate = ref<Date>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookReasonFiling = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const reasonFiling = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookCounterMeasure = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const counterMeasure = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookOrganisationCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const organisationCode = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookOrganisationOPF = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const organisationOPF = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookOrganisationArea = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const organisationArea = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookOrganisationDistrict = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const organisationDistrict = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookOperationType = ref<Handbook[]>();&ndash;&gt;-->
<!--&lt;!&ndash;const operationType = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookMerchTypes = ref<Handbook[]>();&ndash;&gt;-->
<!--&lt;!&ndash;const merchType = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookOperationEknp = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const operationEknp = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookCurrencyCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const currencyCode = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookOperationReason = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const operationReason = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookSuspicionFirst = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const suspicionFirst = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookSuspicionSecond = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const suspicionSecond = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipant = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participant = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookIsClientSubject = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const clientSubject = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantKind = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantKind = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantResidence = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantResidence = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantType = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantType = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantForeignPerson = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantForeignPerson = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantBankCountry = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantBankCountry = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantMoneyTransferSystem = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantMoneyTransferSystem = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantDocumentCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantDocumentCode = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantLegalAddressCountry = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantLegalAddressCountry = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantLegalAddressAreaCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantLegalAddressAreaCode = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantLegalAddressRegionCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantLegalAddressRegionCode = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantLegalAddressCityCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantLegalAddressCity = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantActualAddressCountry = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantActualAddressCountry = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantActualAddressAreaCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantActualAddressAreaCode = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantActualAddressRegionCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantActualAddressRegionCode = ref<Handbook | undefined>();&ndash;&gt;-->
<!--&lt;!&ndash;const handbookParticipantActualAddressCityCode = ref<Handbook[]>([]);&ndash;&gt;-->
<!--&lt;!&ndash;const participantActualAddressCityCode = ref<Handbook | undefined>();&ndash;&gt;-->

<!--&lt;!&ndash;const operationNumber = ref<number>();&ndash;&gt;-->
<!--&lt;!&ndash;const merchRegInfo = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantCount = ref<number>();&ndash;&gt;-->
<!--&lt;!&ndash;const operationAmount = ref<number>();&ndash;&gt;-->
<!--&lt;!&ndash;const operationAmountTenge = ref<number>();&ndash;&gt;-->
<!--&lt;!&ndash;const docOperationDate = ref<Date>();&ndash;&gt;-->
<!--&lt;!&ndash;const docOperationNumber = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const descriptionDifficulties = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const moreInformation = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantBankCity = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantBankName = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantBankCode = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantBankAccountNumber = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantIIN = ref<number>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantLastName = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantFirstName = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantMiddleName = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantDocumentNumber = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantDocumentSeries = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantDocumentIssuedBy = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantDocumentDate = ref<Date>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantDateOfBirth = ref<Date>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantPlaceOfBirth = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantLegalAddressStreet = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantLegalAddressHouse = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantLegalAddressOffice = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantLegalAddressPostCode = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantPhoneNumber = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantEmail = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantActualAddressStreet = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantActualAddressHouse = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantActualAddressOffice = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantActualAddressPostCode = ref<string>();&ndash;&gt;-->
<!--&lt;!&ndash;const participantAdditionalInfo = ref<string>();&ndash;&gt;-->

<!--&lt;!&ndash;const isImpossibleSetFIO = ref<boolean>(false);&ndash;&gt;-->
<!--&lt;!&ndash;const impossibleSetEknp = ref<boolean>();&ndash;&gt;-->
<!--&lt;!&ndash;const isReasonFilingFishilyOperation = ref<boolean>(false);&ndash;&gt;-->
<!--&lt;!&ndash;const is1811MerchType = ref<boolean>(false);&ndash;&gt;-->
<!--&lt;!&ndash;const sfmIsPerson = ref<boolean>();&ndash;&gt;-->

<!--&lt;!&ndash;const referenceOperationNumber = ref<number>();&ndash;&gt;-->
<!--&lt;!&ndash;const referenceDocOperationDate = ref<Date>();&ndash;&gt;-->
<!--&lt;!&ndash;const referenceDocOperationNumber = ref<number>();&ndash;&gt;-->
<!--&lt;!&ndash;const referenceId = ref<number>();&ndash;&gt;-->

<!--&lt;!&ndash;const props = defineProps<{&ndash;&gt;-->
<!--&lt;!&ndash;  editable?: string;&ndash;&gt;-->
<!--&lt;!&ndash;}>();&ndash;&gt;-->

<!--&lt;!&ndash;function referenceDataTableSelected() {&ndash;&gt;-->
<!--&lt;!&ndash;  referenceOperationNumber.value =&ndash;&gt;-->
<!--&lt;!&ndash;    selectedReference.value?.ReferenceOperationNumber!;&ndash;&gt;-->
<!--&lt;!&ndash;  referenceDocOperationDate.value = getDateFromString(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedReference.value?.ReferenceDocOperationDate!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  referenceDocOperationNumber.value =&ndash;&gt;-->
<!--&lt;!&ndash;    selectedReference.value?.ReferenceDocOperationNumber!;&ndash;&gt;-->
<!--&lt;!&ndash;  referenceId.value = selectedReference.value?.ReferenceId!;&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;function referenceDataTableUnselected() {&ndash;&gt;-->
<!--&lt;!&ndash;  referenceOperationNumber.value = undefined;&ndash;&gt;-->
<!--&lt;!&ndash;  referenceDocOperationDate.value = undefined;&ndash;&gt;-->
<!--&lt;!&ndash;  referenceDocOperationNumber.value = undefined;&ndash;&gt;-->
<!--&lt;!&ndash;  referenceId.value = undefined;&ndash;&gt;-->
<!--&lt;!&ndash;  selectedReference.value = undefined;&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;function referenceDeleteEvent() {&ndash;&gt;-->
<!--&lt;!&ndash;  if (!selectedReference.value) {&ndash;&gt;-->
<!--&lt;!&ndash;    toast.add({&ndash;&gt;-->
<!--&lt;!&ndash;      severity: "error",&ndash;&gt;-->
<!--&lt;!&ndash;      summary: "Ошибка",&ndash;&gt;-->
<!--&lt;!&ndash;      detail: "Выберите запись",&ndash;&gt;-->
<!--&lt;!&ndash;      life: 3000,&ndash;&gt;-->
<!--&lt;!&ndash;    });&ndash;&gt;-->
<!--&lt;!&ndash;    return;&ndash;&gt;-->
<!--&lt;!&ndash;  }&ndash;&gt;-->

<!--&lt;!&ndash;  message.value.References.Reference =&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.References.Reference.filter(&ndash;&gt;-->
<!--&lt;!&ndash;      (a) => a.ReferenceId !== selectedReference.value?.ReferenceId!,&ndash;&gt;-->
<!--&lt;!&ndash;    );&ndash;&gt;-->
<!--&lt;!&ndash;  referenceDataTableUnselected();&ndash;&gt;-->
<!--&lt;!&ndash;  console.log(message.value);&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;function referenceAddEvent() {&ndash;&gt;-->
<!--&lt;!&ndash;  // let rf = new Reference();&ndash;&gt;-->
<!--&lt;!&ndash;  // rf.ReferenceDocOperationDate = referenceDocOperationDate.value?.toLocaleDateString()!;&ndash;&gt;-->
<!--&lt;!&ndash;  // rf.ReferenceDocOperationNumber = referenceDocOperationNumber.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  // rf.ReferenceOperationNumber = referenceOperationNumber.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  // rf.ReferenceId = message.value.References.Reference.length + 1;&ndash;&gt;-->

<!--&lt;!&ndash;  message.value?.References?.Reference?.push({&ndash;&gt;-->
<!--&lt;!&ndash;    ReferenceDocOperationDate:&ndash;&gt;-->
<!--&lt;!&ndash;      referenceDocOperationDate.value?.toLocaleDateString()!,&ndash;&gt;-->
<!--&lt;!&ndash;    ReferenceDocOperationNumber: referenceDocOperationNumber.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    ReferenceOperationNumber: referenceOperationNumber.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    ReferenceId: message.value.References.Reference.length + 1,&ndash;&gt;-->
<!--&lt;!&ndash;  });&ndash;&gt;-->
<!--&lt;!&ndash;  referenceDataTableUnselected();&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;function getDataCode(fieldName?: string): number {&ndash;&gt;-->
<!--&lt;!&ndash;  return messageFields.value?.find((a) => a.id === fieldName)?.datacode!;&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;function isReasonFilingFishilyOperationEvent() {&ndash;&gt;-->
<!--&lt;!&ndash;  isReasonFilingFishilyOperation.value = [2, 4, 8, 11, 3, 14].includes(&ndash;&gt;-->
<!--&lt;!&ndash;    reasonFiling.value?.code?.toString()!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;function participantDataTableClicked() {&ndash;&gt;-->
<!--&lt;!&ndash;  participant.value = handbookParticipant.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === selectedParticipant!.value!.MemberId,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  clientSubject.value = handbookIsClientSubject.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === selectedParticipant.value!.IsClientSubject,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantKind.value = handbookParticipantKind.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === selectedParticipant.value!.ParticipantsView,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantResidence.value = handbookParticipantResidence.value.find((a) =>&ndash;&gt;-->
<!--&lt;!&ndash;    a.shortName?.startsWith(selectedParticipant.value!.Residence),&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantType.value = handbookParticipantType.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantForeignPerson.value = handbookParticipantForeignPerson.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === selectedParticipant.value!.ForeignPerson,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantBankCountry.value = handbookParticipantBankCountry.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) =>&ndash;&gt;-->
<!--&lt;!&ndash;      a.shortName?.startsWith(&ndash;&gt;-->
<!--&lt;!&ndash;        selectedParticipant.value!.CorrespondentBank.BankCountry,&ndash;&gt;-->
<!--&lt;!&ndash;      ),&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantBankCity.value =&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.CorrespondentBank.BankCity;&ndash;&gt;-->
<!--&lt;!&ndash;  participantBankName.value = selectedParticipant.value!.CorrespondentBank.Name;&ndash;&gt;-->
<!--&lt;!&ndash;  participantMoneyTransferSystem.value =&ndash;&gt;-->
<!--&lt;!&ndash;    handbookParticipantMoneyTransferSystem.value!.find(&ndash;&gt;-->
<!--&lt;!&ndash;      (a) => a.code === parseInt(selectedParticipant.value!.MoneyTransSys),&ndash;&gt;-->
<!--&lt;!&ndash;    );&ndash;&gt;-->
<!--&lt;!&ndash;  participantBankCode.value = selectedParticipant.value!.CorrespondentBank.Code;&ndash;&gt;-->
<!--&lt;!&ndash;  participantBankAccountNumber.value =&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.CorrespondentBank.AccountNumber;&ndash;&gt;-->
<!--&lt;!&ndash;  participantIIN.value = selectedParticipant.value!.IndividualIssue;&ndash;&gt;-->
<!--&lt;!&ndash;  participantLastName.value = getParticipantLastName(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantFirstName.value = getParticipantFirstName(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantMiddleName.value = getParticipantMiddleName(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  isImpossibleSetFIO.value = getParticipantSetFIO(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantDocumentCode.value = getDocumentIdentityHandbook(&ndash;&gt;-->
<!--&lt;!&ndash;    handbookParticipantDocumentCode.value,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantDocumentNumber.value = getParticipantDocNumber(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantDocumentSeries.value = getParticipantDocSeries(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantDocumentIssuedBy.value = getParticipantDocumentIssuedBy(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantDocumentDate.value = getParticipantDocumentDate(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantDateOfBirth.value = getParticipantDateOfBirth(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantPlaceOfBirth.value = getParticipantPlaceOfBirth(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantLegalAddressCountry.value = getParticipantLegalAddressCountry(&ndash;&gt;-->
<!--&lt;!&ndash;    handbookParticipantLegalAddressCountry.value,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantLegalAddressAreaCode.value = getParticipantLegalAddressAreaCode(&ndash;&gt;-->
<!--&lt;!&ndash;    handbookParticipantLegalAddressAreaCode.value,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantLegalAddressRegionCode.value =&ndash;&gt;-->
<!--&lt;!&ndash;    getParticipantLegalAddressRegionCode(&ndash;&gt;-->
<!--&lt;!&ndash;      handbookParticipantLegalAddressRegionCode.value,&ndash;&gt;-->
<!--&lt;!&ndash;      selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;      selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    );&ndash;&gt;-->
<!--&lt;!&ndash;  participantLegalAddressCity.value = getParticipantLegalAddressCityCode(&ndash;&gt;-->
<!--&lt;!&ndash;    handbookParticipantLegalAddressCityCode.value,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantLegalAddressStreet.value = getParticipantLegalAddressStreet(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantLegalAddressHouse.value = getParticipantLegalAddressHouse(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantLegalAddressOffice.value = getParticipantLegalAddressOffice(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantLegalAddressPostCode.value = getParticipantLegalAddressPostCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantPhoneNumber.value = selectedParticipant.value!.PhoneNumber;&ndash;&gt;-->
<!--&lt;!&ndash;  participantEmail.value = selectedParticipant.value!.Email;&ndash;&gt;-->
<!--&lt;!&ndash;  participantActualAddressCountry.value = getParticipantActualAddressCountry(&ndash;&gt;-->
<!--&lt;!&ndash;    handbookParticipantActualAddressCountry.value,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantActualAddressAreaCode.value = getParticipantActualAddressAreaCode(&ndash;&gt;-->
<!--&lt;!&ndash;    handbookParticipantActualAddressAreaCode.value,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantActualAddressRegionCode.value =&ndash;&gt;-->
<!--&lt;!&ndash;    getParticipantActualAddressRegionCode(&ndash;&gt;-->
<!--&lt;!&ndash;      handbookParticipantActualAddressRegionCode.value,&ndash;&gt;-->
<!--&lt;!&ndash;      selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;      selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    );&ndash;&gt;-->
<!--&lt;!&ndash;  participantActualAddressCityCode.value = getParticipantActualAddressCityCode(&ndash;&gt;-->
<!--&lt;!&ndash;    handbookParticipantActualAddressCityCode.value,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantActualAddressStreet.value = getParticipantActualAddressStreet(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantActualAddressHouse.value = getParticipantActualAddressHouse(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantActualAddressOffice.value = getParticipantActualAddressOffice(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantActualAddressPostCode.value = getParticipantActualAddressPostCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  participantAdditionalInfo.value =&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value!.AdditionalInformation;&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;function changedParticipantFields() {&ndash;&gt;-->
<!--&lt;!&ndash;  if (selectedParticipant?.value == undefined) {&ndash;&gt;-->
<!--&lt;!&ndash;    return;&ndash;&gt;-->
<!--&lt;!&ndash;  }&ndash;&gt;-->

<!--&lt;!&ndash;  let prtc = message.value.Participants.Participant.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.MemberId === selectedParticipant.value!.MemberId,&ndash;&gt;-->
<!--&lt;!&ndash;  )!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.MemberId = participant.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.IsClientSubject = clientSubject.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.ParticipantsView = participantKind.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.Residence = getCountryCode(participantResidence.value!)!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.ParticipantsType = participantType.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.ForeignPerson = participantForeignPerson.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.CorrespondentBank.BankCountry = getCountryCode(&ndash;&gt;-->
<!--&lt;!&ndash;    participantBankCountry.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  )!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.CorrespondentBank.BankCity = participantBankCity.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.CorrespondentBank.Name = participantBankName.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.MoneyTransSys = participantMoneyTransferSystem.value?.code?.toString()!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.CorrespondentBank.Code = participantBankCode.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.CorrespondentBank.AccountNumber = participantBankAccountNumber.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.IndividualIssue = participantIIN.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLastName(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLastName.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantFirstName(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantFirstName.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantMiddleName(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantMiddleName.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantSetFIO(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    isImpossibleSetFIO.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setDocumentIdentityHandbook(&ndash;&gt;-->
<!--&lt;!&ndash;    participantDocumentCode.value!,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDocNumber(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantDocumentNumber.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDocSeries(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantDocumentSeries.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDocumentIssuedBy(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantDocumentIssuedBy.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDocumentDate(&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    participantDocumentDate.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantDateOfBirth(&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    participantDateOfBirth.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantPlaceOfBirth(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantPlaceOfBirth.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressCountry(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLegalAddressCountry.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressAreaCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLegalAddressAreaCode.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressRegionCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLegalAddressRegionCode.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressCityCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLegalAddressCity.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressStreet(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLegalAddressStreet.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressHouse(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLegalAddressHouse.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressOffice(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLegalAddressOffice.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantLegalAddressPostCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantLegalAddressPostCode.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.PhoneNumber = participantPhoneNumber.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.Email = participantEmail.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressCountry(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantActualAddressCountry.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressAreaCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantActualAddressAreaCode.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressRegionCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantActualAddressRegionCode.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressCityCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantActualAddressCityCode.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressStreet(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantActualAddressStreet.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressHouse(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantActualAddressHouse.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressOffice(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantActualAddressOffice.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  setParticipantActualAddressPostCode(&ndash;&gt;-->
<!--&lt;!&ndash;    selectedParticipant.value.ParticipantsType,&ndash;&gt;-->
<!--&lt;!&ndash;    prtc,&ndash;&gt;-->
<!--&lt;!&ndash;    participantActualAddressPostCode.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  prtc.AdditionalInformation = participantAdditionalInfo.value!;&ndash;&gt;-->

<!--&lt;!&ndash;  //console.log(message.value);&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;async function getHandbooksWithVersion() {&ndash;&gt;-->
<!--&lt;!&ndash;  // ТАБ: Сведения о форме ФМ-1&ndash;&gt;-->
<!--&lt;!&ndash;  handbookOperationView.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("MessageType"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  operationView.value = handbookOperationView.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.MessageInformation?.DocumentType,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookOperationStatus.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("OperationStatus"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  operationStatus.value = handbookOperationStatus.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.MessageInformation?.OperationStatusId,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  transactionDate.value = getDateFromString(&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.MessageInformation?.TransactionDate,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookReasonFiling.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("MessageReason"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  reasonFiling.value = handbookReasonFiling.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.MessageInformation?.ReasonFilingId,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  isReasonFilingFishilyOperation.value = [2, 4, 8, 11, 3, 14].includes(&ndash;&gt;-->
<!--&lt;!&ndash;    reasonFiling.value?.code!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookCounterMeasure.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("CounterMeasure"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  counterMeasure.value = handbookCounterMeasure.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) =>&ndash;&gt;-->
<!--&lt;!&ndash;      a.code === parseInt(message.value.MessageInformation?.CounterMeasure),&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookOrganisationCode.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("SfmCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  organisationCode.value = handbookOrganisationCode.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.PersonalData.OrganisationCode,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookOrganisationOPF.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("SfmOpfCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  organisationOPF.value = handbookOrganisationOPF.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.PersonalData.OrganisationOPF,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookOrganisationArea.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("SfmAreaCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  organisationArea.value = handbookOrganisationArea.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) =>&ndash;&gt;-->
<!--&lt;!&ndash;      a.code === parseInt(message.value.PersonalData.OrganisationArea["@Code"]),&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookOrganisationDistrict.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("SfmRegionCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  organisationDistrict.value = handbookOrganisationDistrict.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) =>&ndash;&gt;-->
<!--&lt;!&ndash;      a.code ===&ndash;&gt;-->
<!--&lt;!&ndash;      parseInt(message.value.PersonalData.OrganisationDistrict["@Code"]),&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  // ТАБ: Операция&ndash;&gt;-->
<!--&lt;!&ndash;  operationNumber.value = message.value.MessageInformation?.OperationNumber;&ndash;&gt;-->

<!--&lt;!&ndash;  handbookOperationType.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("OperationType"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  operationType.value = handbookOperationType.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.MessageInformation?.ViewOperationId,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookMerchTypes.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("AssetCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  merchType.value = handbookMerchTypes.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code?.toString() === message.value.MessageInformation?.MerchTypes,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  is1811MerchType.value = merchType.value?.code == 1811;&ndash;&gt;-->

<!--&lt;!&ndash;  merchRegInfo.value = message.value.MessageInformation?.MerchReginfo;&ndash;&gt;-->

<!--&lt;!&ndash;  handbookOperationEknp.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("OperationEknp"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  operationEknp.value = handbookOperationEknp.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) =>&ndash;&gt;-->
<!--&lt;!&ndash;      a.code?.toString() == message.value.MessageInformation?.EknpId["#text"],&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  impossibleSetEknp.value =&ndash;&gt;-->
<!--&lt;!&ndash;    String(message.value.MessageInformation?.EknpId["@IsEknpNotSetup"]) ===&ndash;&gt;-->
<!--&lt;!&ndash;    "true";&ndash;&gt;-->

<!--&lt;!&ndash;  participantCount.value = message.value.MessageInformation?.ParticipantCount;&ndash;&gt;-->

<!--&lt;!&ndash;  handbookCurrencyCode.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("OperationCurrency"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  currencyCode.value = handbookCurrencyCode.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.MessageInformation?.CurrencyCodeId,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  operationAmount.value = message.value.MessageInformation?.AmountCurrency;&ndash;&gt;-->

<!--&lt;!&ndash;  operationAmountTenge.value =&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.MessageInformation?.AmountCurrencyTenge;&ndash;&gt;-->

<!--&lt;!&ndash;  handbookOperationReason.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("OperationReason"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  operationReason.value = handbookOperationReason.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.MessageInformation?.DocOperationReason,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  docOperationDate.value = getDateFromString(&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.MessageInformation?.DocOperationDate,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  docOperationNumber.value =&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.MessageInformation?.DocOperationNumber;&ndash;&gt;-->

<!--&lt;!&ndash;  handbookSuspicionFirst.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("SuspicionSign1"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  suspicionFirst.value = handbookSuspicionFirst.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) => a.code === message.value.MessageInformation?.SuspicionFirst,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookSuspicionSecond.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("SuspicionSign2"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->
<!--&lt;!&ndash;  suspicionSecond.value = handbookSuspicionSecond.value.find(&ndash;&gt;-->
<!--&lt;!&ndash;    (a) =>&ndash;&gt;-->
<!--&lt;!&ndash;      a.code === parseInt(message.value.MessageInformation?.SuspicionSecond),&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  descriptionDifficulties.value =&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.MessageInformation?.DescriptionDifficulties;&ndash;&gt;-->

<!--&lt;!&ndash;  moreInformation.value = message.value.MessageInformation?.MoreInformation;&ndash;&gt;-->

<!--&lt;!&ndash;  // ТАБ: Участники&ndash;&gt;-->
<!--&lt;!&ndash;  handbookParticipant.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("Participant"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookIsClientSubject.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("ParticipantIsSfmClient"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantKind.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("ParticipantKind"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantResidence.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("ParticipantResidence"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantType.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("ParticipantType"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantForeignPerson.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("ParticipantForeignPerson"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantBankCountry.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("ParticipantBankCountry"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantMoneyTransferSystem.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("ParticipantMoneyTransferSystem"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantDocumentCode.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("IEParticipantDocumentCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantLegalAddressCountry.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("IEParticipantLegalAddressCountry"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantLegalAddressAreaCode.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("IEParticipantLegalAddressAreaCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantLegalAddressRegionCode.value =&ndash;&gt;-->
<!--&lt;!&ndash;    await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;      getDataCode("IEParticipantLegalAddressRegionCode"),&ndash;&gt;-->
<!--&lt;!&ndash;      messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;    );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantLegalAddressCityCode.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("IEParticipantLegalAddressCityCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantActualAddressCountry.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("IEParticipantActualAddressCountry"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantActualAddressAreaCode.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("IEParticipantActualAddressAreaCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantActualAddressRegionCode.value =&ndash;&gt;-->
<!--&lt;!&ndash;    await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;      getDataCode("IEParticipantActualAddressRegionCode"),&ndash;&gt;-->
<!--&lt;!&ndash;      messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;    );&ndash;&gt;-->

<!--&lt;!&ndash;  handbookParticipantActualAddressCityCode.value = await GetHandbookWithVersion(&ndash;&gt;-->
<!--&lt;!&ndash;    getDataCode("IEParticipantActualAddressCityCode"),&ndash;&gt;-->
<!--&lt;!&ndash;    messageVersion.value,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  sfmIsPerson.value =&ndash;&gt;-->
<!--&lt;!&ndash;    String(message.value.PersonalData.AdditionalAcData["@IsAc"]) == "true";&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;async function saveMessage() {&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.OperationStatusId =&ndash;&gt;-->
<!--&lt;!&ndash;    operationStatus.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.TransactionDate = `${transactionDate.value?.toLocaleDateString()!} ${transactionDate.value?.toLocaleTimeString()!}`;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.ReasonFilingId = reasonFiling.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.CounterMeasure =&ndash;&gt;-->
<!--&lt;!&ndash;    counterMeasure.value?.code!.toString()!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.OperationNumber = operationNumber.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.ViewOperationId =&ndash;&gt;-->
<!--&lt;!&ndash;    operationType.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.MerchTypes =&ndash;&gt;-->
<!--&lt;!&ndash;    merchType.value?.code!.toString()!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.MerchReginfo = merchRegInfo.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.EknpId["#text"] =&ndash;&gt;-->
<!--&lt;!&ndash;    operationEknp.value === undefined&ndash;&gt;-->
<!--&lt;!&ndash;      ? ""&ndash;&gt;-->
<!--&lt;!&ndash;      : operationEknp.value?.code!.toString()!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.EknpId["@IsEknpNotSetup"] =&ndash;&gt;-->
<!--&lt;!&ndash;    impossibleSetEknp.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.ParticipantCount = participantCount.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.CurrencyCodeId = currencyCode.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.AmountCurrency = operationAmount.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.AmountCurrencyTenge =&ndash;&gt;-->
<!--&lt;!&ndash;    operationAmountTenge.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.DocOperationReason =&ndash;&gt;-->
<!--&lt;!&ndash;    operationReason.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.DocOperationDate =&ndash;&gt;-->
<!--&lt;!&ndash;    docOperationDate.value?.toLocaleDateString()!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.DocOperationNumber =&ndash;&gt;-->
<!--&lt;!&ndash;    docOperationNumber.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.SuspicionFirst =&ndash;&gt;-->
<!--&lt;!&ndash;    suspicionFirst.value?.code!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.SuspicionSecond =&ndash;&gt;-->
<!--&lt;!&ndash;    suspicionSecond.value?.code!.toString()!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.DescriptionDifficulties =&ndash;&gt;-->
<!--&lt;!&ndash;    descriptionDifficulties.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.MessageInformation!.MoreInformation = moreInformation.value!;&ndash;&gt;-->
<!--&lt;!&ndash;  message.value.PersonalData!.AdditionalAcData["@IsAc"] = String(&ndash;&gt;-->
<!--&lt;!&ndash;    sfmIsPerson.value!,&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  // console.log(message.value);&ndash;&gt;-->

<!--&lt;!&ndash;  const builder = new XMLBuilder({&ndash;&gt;-->
<!--&lt;!&ndash;    ignoreAttributes: false,&ndash;&gt;-->
<!--&lt;!&ndash;    attributeNamePrefix: "@",&ndash;&gt;-->
<!--&lt;!&ndash;    suppressBooleanAttributes: false,&ndash;&gt;-->
<!--&lt;!&ndash;  });&ndash;&gt;-->
<!--&lt;!&ndash;  const output = builder.build(message.value);&ndash;&gt;-->

<!--&lt;!&ndash;  let result = await UpdateMessage(&ndash;&gt;-->
<!--&lt;!&ndash;    parseInt(<string>route.params.id),&ndash;&gt;-->
<!--&lt;!&ndash;    btoa(unescape(encodeURIComponent(`<Root>${output.toString()}</Root>`))),&ndash;&gt;-->
<!--&lt;!&ndash;  );&ndash;&gt;-->

<!--&lt;!&ndash;  if (result == "0")&ndash;&gt;-->
<!--&lt;!&ndash;    toast.add({&ndash;&gt;-->
<!--&lt;!&ndash;      severity: "success",&ndash;&gt;-->
<!--&lt;!&ndash;      summary: "Успешно",&ndash;&gt;-->
<!--&lt;!&ndash;      detail: "Данные сохранены",&ndash;&gt;-->
<!--&lt;!&ndash;      life: 3000,&ndash;&gt;-->
<!--&lt;!&ndash;    });&ndash;&gt;-->
<!--&lt;!&ndash;  else&ndash;&gt;-->
<!--&lt;!&ndash;    toast.add({&ndash;&gt;-->
<!--&lt;!&ndash;      severity: "error",&ndash;&gt;-->
<!--&lt;!&ndash;      summary: "Ошибка",&ndash;&gt;-->
<!--&lt;!&ndash;      detail: `Ошибка при сохранении. Код ошибки: ${result}`,&ndash;&gt;-->
<!--&lt;!&ndash;      life: 6000,&ndash;&gt;-->
<!--&lt;!&ndash;    });&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;function closeWindow() {&ndash;&gt;-->
<!--&lt;!&ndash;  window.close();&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;async function toNextStage() {&ndash;&gt;-->
<!--&lt;!&ndash;  let result1 = await ToNextStage(parseInt(<string>route.params.id)!);&ndash;&gt;-->

<!--&lt;!&ndash;  if (result1 == "0")&ndash;&gt;-->
<!--&lt;!&ndash;    toast.add({&ndash;&gt;-->
<!--&lt;!&ndash;      severity: "success",&ndash;&gt;-->
<!--&lt;!&ndash;      summary: "Успешно",&ndash;&gt;-->
<!--&lt;!&ndash;      detail: "Документ успешно передан на следующую стадию",&ndash;&gt;-->
<!--&lt;!&ndash;      life: 3000,&ndash;&gt;-->
<!--&lt;!&ndash;    });&ndash;&gt;-->
<!--&lt;!&ndash;  else&ndash;&gt;-->
<!--&lt;!&ndash;    toast.add({&ndash;&gt;-->
<!--&lt;!&ndash;      severity: "error",&ndash;&gt;-->
<!--&lt;!&ndash;      summary: "Ошибка",&ndash;&gt;-->
<!--&lt;!&ndash;      detail: `Ошибка при передачи. Код ошибки: ${result1}`,&ndash;&gt;-->
<!--&lt;!&ndash;      life: 6000,&ndash;&gt;-->
<!--&lt;!&ndash;    });&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;async function toPreviousStage() {&ndash;&gt;-->
<!--&lt;!&ndash;  let result2 = await ToPreviousStage(parseInt(<string>route.params.id)!);&ndash;&gt;-->

<!--&lt;!&ndash;  if (result2 == "0")&ndash;&gt;-->
<!--&lt;!&ndash;    showSuccessToast("Документ успешно передан на прерыдущию стадию");&ndash;&gt;-->
<!--&lt;!&ndash;  else showErrorToast(`Ошибка при передачи. Код ошибки: ${result2}`);&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;async function exclude() {&ndash;&gt;-->
<!--&lt;!&ndash;  let re = await Exclude(parseInt(<string>route.params.id)!);&ndash;&gt;-->

<!--&lt;!&ndash;  if (re == "0") showSuccessToast("Документ успешно исключен");&ndash;&gt;-->
<!--&lt;!&ndash;  else&ndash;&gt;-->
<!--&lt;!&ndash;    showErrorToast("При исключении произошло ошибка. Код ошибки: (" + `${re})`);&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;const showSuccessToast = (text: string) => {&ndash;&gt;-->
<!--&lt;!&ndash;  toast.add({&ndash;&gt;-->
<!--&lt;!&ndash;    severity: "success",&ndash;&gt;-->
<!--&lt;!&ndash;    summary: "Успешно",&ndash;&gt;-->
<!--&lt;!&ndash;    detail: text,&ndash;&gt;-->
<!--&lt;!&ndash;    life: 3000,&ndash;&gt;-->
<!--&lt;!&ndash;  });&ndash;&gt;-->
<!--&lt;!&ndash;};&ndash;&gt;-->

<!--&lt;!&ndash;const showErrorToast = (text: string) => {&ndash;&gt;-->
<!--&lt;!&ndash;  toast.add({&ndash;&gt;-->
<!--&lt;!&ndash;    severity: "error",&ndash;&gt;-->
<!--&lt;!&ndash;    summary: "Ошибка",&ndash;&gt;-->
<!--&lt;!&ndash;    detail: text,&ndash;&gt;-->
<!--&lt;!&ndash;    life: 6000,&ndash;&gt;-->
<!--&lt;!&ndash;  });&ndash;&gt;-->
<!--&lt;!&ndash;};&ndash;&gt;-->

<!--&lt;!&ndash;async function fetchData() {&ndash;&gt;-->
<!--&lt;!&ndash;  let xmlString = await GetMessageById(parseInt(<string>route.params.id));&ndash;&gt;-->
<!--&lt;!&ndash;  const parser = new XMLParser({&ndash;&gt;-->
<!--&lt;!&ndash;    ignoreAttributes: false,&ndash;&gt;-->
<!--&lt;!&ndash;    attributeNamePrefix: "@",&ndash;&gt;-->
<!--&lt;!&ndash;    numberParseOptions: {&ndash;&gt;-->
<!--&lt;!&ndash;      leadingZeros: false,&ndash;&gt;-->
<!--&lt;!&ndash;      hex: true,&ndash;&gt;-->
<!--&lt;!&ndash;    },&ndash;&gt;-->
<!--&lt;!&ndash;  });&ndash;&gt;-->
<!--&lt;!&ndash;  let msgJSON = parser.parse(xmlString);&ndash;&gt;-->
<!--&lt;!&ndash;  message.value = plainToClass(Root, msgJSON.Root as object);&ndash;&gt;-->
<!--&lt;!&ndash;  messageVersion.value = Guid.parse(message.value.Version);&ndash;&gt;-->

<!--&lt;!&ndash;  if (&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.Participants?.Participant != undefined &&&ndash;&gt;-->
<!--&lt;!&ndash;    !Array.isArray(message.value.Participants?.Participant)&ndash;&gt;-->
<!--&lt;!&ndash;  ) {&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.Participants.Participant = [&ndash;&gt;-->
<!--&lt;!&ndash;      message.value.Participants.Participant,&ndash;&gt;-->
<!--&lt;!&ndash;    ];&ndash;&gt;-->
<!--&lt;!&ndash;  }&ndash;&gt;-->

<!--&lt;!&ndash;  // if (message.value?.References?.Reference == undefined) {&ndash;&gt;-->
<!--&lt;!&ndash;  //   message.value.References = [];&ndash;&gt;-->
<!--&lt;!&ndash;  //   message.value.References.Reference = [];&ndash;&gt;-->
<!--&lt;!&ndash;  //   // console.log('кірді');&ndash;&gt;-->
<!--&lt;!&ndash;  // }&ndash;&gt;-->

<!--&lt;!&ndash;  if (&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.References?.Reference != undefined &&&ndash;&gt;-->
<!--&lt;!&ndash;    !Array.isArray(message.value.References?.Reference)&ndash;&gt;-->
<!--&lt;!&ndash;  ) {&ndash;&gt;-->
<!--&lt;!&ndash;    message.value.References.Reference = [message.value.References.Reference];&ndash;&gt;-->
<!--&lt;!&ndash;  }&ndash;&gt;-->

<!--&lt;!&ndash;  // if (!Array.isArray(message.value.References?.Reference)) {&ndash;&gt;-->
<!--&lt;!&ndash;  //   message.value.References.Reference = [message.value.References.Reference];&ndash;&gt;-->
<!--&lt;!&ndash;  // }&ndash;&gt;-->

<!--&lt;!&ndash;  messageFields.value = await GetFields(messageVersion.value);&ndash;&gt;-->
<!--&lt;!&ndash;  await getHandbooksWithVersion();&ndash;&gt;-->
<!--&lt;!&ndash;  // console.log(JSON.stringify(message.value))&ndash;&gt;-->
<!--&lt;!&ndash;  // console.log(message.value.References.Reference);&ndash;&gt;-->
<!--&lt;!&ndash;  console.log(message.value);&ndash;&gt;-->
<!--&lt;!&ndash;  // console.log(message.value.Participants.Participant);&ndash;&gt;-->
<!--&lt;!&ndash;}&ndash;&gt;-->

<!--&lt;!&ndash;const tooltipOptions = (str: string) => {&ndash;&gt;-->
<!--&lt;!&ndash;  return {&ndash;&gt;-->
<!--&lt;!&ndash;    value: str,&ndash;&gt;-->
<!--&lt;!&ndash;    showDelay: 1000,&ndash;&gt;-->
<!--&lt;!&ndash;    hideDelay: 300,&ndash;&gt;-->
<!--&lt;!&ndash;    class: "tw-text-[12px]",&ndash;&gt;-->
<!--&lt;!&ndash;  };&ndash;&gt;-->
<!--&lt;!&ndash;};&ndash;&gt;-->

<!--&lt;!&ndash;onMounted(async () => {&ndash;&gt;-->
<!--&lt;!&ndash;  await fetchData();&ndash;&gt;-->
<!--&lt;!&ndash;  isResponsible.value = await checkUserRole(4);&ndash;&gt;-->
<!--&lt;!&ndash;  isOperator.value = await checkUserRole(2);&ndash;&gt;-->
<!--&lt;!&ndash;});&ndash;&gt;-->
<!--</script>-->

<template>
  <!--  <div class="tw-min-h-screen tw-grid tw-grid-rows-[64px_40px_1fr_auto]">-->
  <!--    <ScrollTop />-->
  <!--    <MainHeader />-->
  <!--    <div-->
  <!--      class="tw-h-[40px] tw-ml-2 tw-flex tw-items-center tw-justify-between tw-w-[120px]"-->
  <!--      v-if="isOperator && props.editable == 'true'"-->
  <!--    >-->
  <!--      <span v-tooltip.right="tooltipOptions('Сохранить')">-->
  <!--        <an-outlined-save class="m-top-menu-icon" @click="saveMessage" />-->
  <!--      </span>-->
  <!--      <span v-tooltip.right="tooltipOptions('Передать следущую стадию')">-->
  <!--        <bs-arrow-right-circle class="m-top-menu-icon" @click="toNextStage" />-->
  <!--      </span>-->
  <!--      <span v-tooltip.right="tooltipOptions('Закрыть')">-->
  <!--        <an-outlined-close-circle-->
  <!--          class="m-top-menu-icon"-->
  <!--          @click="closeWindow"-->
  <!--        />-->
  <!--      </span>-->
  <!--    </div>-->
  <!--    <div-->
  <!--      class="tw-h-[40px] tw-ml-2 tw-flex tw-items-center tw-justify-between tw-w-[120px]"-->
  <!--      v-if="isResponsible"-->
  <!--    >-->
  <!--      <span v-tooltip.right="tooltipOptions('Передать на предыдущую стадию')">-->
  <!--        <bs-arrow-left-circle-->
  <!--          class="m-top-menu-icon"-->
  <!--          @click="toPreviousStage"-->
  <!--        />-->
  <!--      </span>-->
  <!--      <span v-tooltip.right="tooltipOptions('Исключить из обработки')">-->
  <!--        <an-outlined-minus-circle class="m-top-menu-icon" @click="exclude" />-->
  <!--      </span>-->
  <!--      <span v-tooltip.right="tooltipOptions('Закрыть')">-->
  <!--        <an-outlined-close-circle-->
  <!--          class="m-top-menu-icon"-->
  <!--          @click="closeWindow"-->
  <!--        />-->
  <!--      </span>-->
  <!--    </div>-->

  <!--    <TabView-->
  <!--      class="tw-h-full tw-bg-slate-100"-->
  <!--      :pt="{-->
  <!--        panelcontainer:-->
  <!--          'tw-w-[60%] tw-m-auto tw-my-4 tw-drop-shadow-md tw-rounded-lg tw-grid tw-py-4',-->
  <!--      }"-->
  <!--    >-->
  <!--      <TabPanel header="Сведения о форме ФМ-1">-->
  <!--        <Accordion :activeIndex="[0]" :multiple="true">-->
  <!--          <AccordionTab header="">-->
  <!--            <grid-container2-col>-->
  <!--              <field-name name="1.1 Номер формы ФМ-1" />-->
  <!--              <div>-->
  <!--                <InputNumber-->
  <!--                  inputId="withoutgrouping"-->
  <!--                  :useGrouping="false"-->
  <!--                  :model-value="message.MessageInformation?.MessageNumber"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="1.2 Дата формы ФМ-1" />-->
  <!--              <div>-->
  <!--                <InputText-->
  <!--                  type="text"-->
  <!--                  :model-value="message.MessageInformation?.LastModifyDate"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="1.3 Вид документа" />-->
  <!--              <div>-->
  <!--                <Dropdown-->
  <!--                  :model-value="operationView"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                  :options="handbookOperationView"-->
  <!--                  optionLabel="shortName"-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="1.4 Состояние операции" />-->
  <!--              <div>-->
  <!--                <Dropdown-->
  <!--                  v-model="operationStatus"-->
  <!--                  class="tw-w-full"-->
  <!--                  :options="handbookOperationStatus"-->
  <!--                  optionLabel="shortName"-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="Дата и время операции" />-->
  <!--              <div>-->
  <!--                <Calendar-->
  <!--                  v-model="transactionDate"-->
  <!--                  showIcon-->
  <!--                  class="tw-w-full"-->
  <!--                  :showOnFocus="false"-->
  <!--                  showTime-->
  <!--                  hourFormat="24"-->
  <!--                />-->
  <!--              </div>-->
  <!--            </grid-container2-col>-->
  <!--            <Fieldset legend="1.5 Основание для подачи сообщения">-->
  <!--              <grid-container2-col>-->
  <!--                <field-name name="1. Основание для подачи сообщения" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="reasonFiling"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookReasonFiling"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    @update:model-value="isReasonFilingFishilyOperationEvent"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name-->
  <!--                  name="4. Мера противодействия при совпадении с перечным организаций и лиц"-->
  <!--                  v-if="isReasonFilingFishilyOperation"-->
  <!--                />-->
  <!--                <div v-if="isReasonFilingFishilyOperation">-->
  <!--                  <Dropdown-->
  <!--                    v-model="counterMeasure"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookCounterMeasure"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->
  <!--            </Fieldset>-->
  <!--          </AccordionTab>-->

  <!--          <AccordionTab header="1.1.2 Связь с иной формой">-->
  <!--            <DataTable-->
  <!--              :value="message.References?.Reference"-->
  <!--              size="small"-->
  <!--              v-model:selection="selectedReference"-->
  <!--              selectionMode="single"-->
  <!--              @row-select="referenceDataTableSelected"-->
  <!--              @row-unselect="referenceDataTableUnselected"-->
  <!--            >-->
  <!--              <template #empty>-->
  <!--                <div-->
  <!--                  class="tw-flex tw-justify-center tw-items-center tw-my-[20px]"-->
  <!--                >-->
  <!--                  <div class="tw-italic">Нет данных</div>-->
  <!--                </div>-->
  <!--              </template>-->
  <!--              <Column field="ReferenceOperationNumber" header="Номер"></Column>-->
  <!--              <Column field="ReferenceDocOperationDate" header="Дата"></Column>-->
  <!--              <Column-->
  <!--                field="ReferenceDocOperationNumber"-->
  <!--                header="Номер операции"-->
  <!--              ></Column>-->
  <!--            </DataTable>-->

  <!--            <Fieldset legend="Детализация" :toggleable="true">-->
  <!--              <grid-container2-col>-->
  <!--                <field-name name="2.1 Номер связанной формы ФМ-1" />-->
  <!--                <div>-->
  <!--                  <InputNumber-->
  <!--                    v-model="referenceOperationNumber"-->
  <!--                    class="tw-w-full"-->
  <!--                    :useGrouping="false"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="2.2 Дата связанной формы ФМ-1" />-->
  <!--                <div>-->
  <!--                  <Calendar-->
  <!--                    showIcon-->
  <!--                    :showOnFocus="false"-->
  <!--                    class="tw-w-full"-->
  <!--                    v-model="referenceDocOperationDate"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="Номер операции в связанной форме" />-->
  <!--                <div>-->
  <!--                  <InputNumber-->
  <!--                    v-model="referenceDocOperationNumber"-->
  <!--                    class="tw-w-full"-->
  <!--                    :useGrouping="false"-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->

  <!--              <div class="tw-flex tw-justify-between tw-mt-[10px]">-->
  <!--                <Button-->
  <!--                  label="Добавить"-->
  <!--                  class="tw-bg-[--primary-color] tw-border-[--primary-color]"-->
  <!--                  @click="referenceAddEvent"-->
  <!--                  disabled-->
  <!--                >-->
  <!--                </Button>-->
  <!--                <Button-->
  <!--                  label="Удалить"-->
  <!--                  severity="secondary"-->
  <!--                  @click="referenceDeleteEvent"-->
  <!--                  disabled-->
  <!--                >-->
  <!--                </Button>-->
  <!--              </div>-->
  <!--            </Fieldset>-->
  <!--          </AccordionTab>-->

  <!--          <AccordionTab-->
  <!--            header="2 Сведения о субъекте финансового мониторинга, направившим форму ФМ-1"-->
  <!--          >-->
  <!--            <grid-container2-col>-->
  <!--              <field-name name="2.1 Код субъекта финансового мониторинга" />-->
  <!--              <div>-->
  <!--                <Dropdown-->
  <!--                  v-model="organisationCode"-->
  <!--                  class="tw-w-full"-->
  <!--                  :options="handbookOrganisationCode"-->
  <!--                  optionLabel="shortName"-->
  <!--                  panel-class="tw-w-[200px]"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->
  <!--            </grid-container2-col>-->

  <!--            <Fieldset legend="2.2 Субъект финансового мониторинга">-->
  <!--              <grid-container2-col>-->
  <!--                <field-name name="1.1 Организационная форма" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="organisationOPF"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookOrganisationOPF"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="1.2 Наименование" />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    type="text"-->
  <!--                    :model-value="message.PersonalData?.Organisation"-->
  <!--                    class="tw-w-full"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->
  <!--            </Fieldset>-->

  <!--            <grid-container2-col class="tw-mt-[10px]">-->
  <!--              <field-name name="2.4 ИИН/БИН" />-->
  <!--              <div>-->
  <!--                <InputText-->
  <!--                  type="text"-->
  <!--                  :model-value="message.PersonalData?.IINBIN"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->
  <!--            </grid-container2-col>-->

  <!--            <Fieldset legend="2.5 Адрес места нахождения">-->
  <!--              <grid-container2-col>-->
  <!--                <field-name name="1. Область" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="organisationArea"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookOrganisationArea"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="2. Район" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="organisationDistrict"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookOrganisationDistrict"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="4. Наименование улицы / проспекта / мр-на" />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    type="text"-->
  <!--                    :model-value="message.PersonalData?.OrganisationStreet"-->
  <!--                    class="tw-w-full"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="5. Номер дома" />-->
  <!--                <div>-->
  <!--                  <InputNumber-->
  <!--                    :model-value="message.PersonalData?.OrganisationHouse"-->
  <!--                    class="tw-w-full"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="6. Номер квартиры/офиса" />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    :model-value="message.PersonalData?.OrganisationOffice"-->
  <!--                    class="tw-w-full"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="7. Почтовой индекс" />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    :model-value="-->
  <!--                      message.PersonalData?.OrganisationPostalIndex.toString()-->
  <!--                    "-->
  <!--                    class="tw-w-full"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->
  <!--            </Fieldset>-->

  <!--            <Fieldset-->
  <!--              legend="2.6 Документ, удостоверяющий личность (для физических лиц)"-->
  <!--            >-->
  <!--              <grid-container2-col>-->
  <!--                <field-name-->
  <!--                  name="2.6.1. Номер и серия документа, удостоверяющего личность (для физических лиц)"-->
  <!--                />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    :model-value="-->
  <!--                      message.PersonalData?.AdditionalAcData?.NumberDocIdentity-->
  <!--                    "-->
  <!--                    class="tw-w-full"-->
  <!--                    disabled-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->
  <!--            </Fieldset>-->
  <!--          </AccordionTab>-->

  <!--          <AccordionTab header="2.7 Ответственное должностное лицо">-->
  <!--            <grid-container2-col>-->
  <!--              <field-name name="1. Фамилия" />-->
  <!--              <div>-->
  <!--                <InputText-->
  <!--                  :model-value="message.PersonalData?.SecondName"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="2. Имя" />-->
  <!--              <div>-->
  <!--                <InputText-->
  <!--                  :model-value="message.PersonalData?.FirstName"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="3. Отчество" />-->
  <!--              <div>-->
  <!--                <InputText-->
  <!--                  :model-value="message.PersonalData?.MiddleName"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name-->
  <!--                name="2.7.1 Должность ответсвенного должностного лица"-->
  <!--              />-->
  <!--              <div>-->
  <!--                <InputText-->
  <!--                  :model-value="message.PersonalData?.JobName"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="2.8 Контактные телефоны" />-->
  <!--              <div>-->
  <!--                <InputText-->
  <!--                  :model-value="message.PersonalData?.Phone"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="2.9 Электронная почта" />-->
  <!--              <div>-->
  <!--                <InputText-->
  <!--                  :model-value="message.PersonalData?.Email"-->
  <!--                  class="tw-w-full"-->
  <!--                  disabled-->
  <!--                />-->
  <!--              </div>-->
  <!--            </grid-container2-col>-->
  <!--          </AccordionTab>-->
  <!--        </Accordion>-->
  <!--      </TabPanel>-->

  <!--      <TabPanel header="Операция">-->
  <!--        <Fieldset legend="3. Операция">-->
  <!--          <grid-container2-col>-->
  <!--            <field-name name="3.1 Номер операции" />-->
  <!--            <div>-->
  <!--              <InputNumber-->
  <!--                v-model="operationNumber"-->
  <!--                class="tw-w-full"-->
  <!--                :use-grouping="false"-->
  <!--              />-->
  <!--            </div>-->
  <!--          </grid-container2-col>-->
  <!--        </Fieldset>-->

  <!--        <Fieldset legend="3.2 Код вида операции">-->
  <!--          <grid-container2-col>-->
  <!--            <field-name name="1. Код" />-->
  <!--            <div>-->
  <!--              <Dropdown-->
  <!--                v-model="operationType"-->
  <!--                class="tw-w-full"-->
  <!--                :options="handbookOperationType"-->
  <!--                optionLabel="shortName"-->
  <!--                panel-class="tw-w-[200px]"-->
  <!--                @update:model-value="-->
  <!--                  is1811MerchType = operationType!.code == 1811-->
  <!--                "-->
  <!--              />-->
  <!--            </div>-->
  <!--          </grid-container2-col>-->
  <!--          <Fieldset-->
  <!--            legend="2 Информация об имуществе, подлежащего обязательной государственной регистрации"-->
  <!--            v-if="is1811MerchType"-->
  <!--          >-->
  <!--            <grid-container2-col>-->
  <!--              <field-name name="2.1 Вид имущество" />-->
  <!--              <div>-->
  <!--                <Dropdown-->
  <!--                  v-model="merchType"-->
  <!--                  class="tw-w-full"-->
  <!--                  :options="handbookMerchTypes"-->
  <!--                  optionLabel="shortName"-->
  <!--                  panel-class="tw-w-[200px]"-->
  <!--                />-->
  <!--              </div>-->

  <!--              <field-name name="2.2 Регистрационный номер имущества" />-->
  <!--              <div>-->
  <!--                <InputText v-model="merchRegInfo" class="tw-w-full" />-->
  <!--              </div>-->
  <!--            </grid-container2-col>-->
  <!--          </Fieldset>-->
  <!--        </Fieldset>-->

  <!--        <Fieldset legend="3.3 Код назначения платежа">-->
  <!--          <grid-container2-col>-->
  <!--            <field-name name="Код назначения платежа" />-->
  <!--            <div>-->
  <!--              <Dropdown-->
  <!--                v-model="operationEknp"-->
  <!--                class="tw-w-full"-->
  <!--                :options="handbookOperationEknp"-->
  <!--                optionLabel="shortName"-->
  <!--                panel-class="tw-w-[200px]"-->
  <!--                :disabled="impossibleSetEknp"-->
  <!--              />-->
  <!--            </div>-->

  <!--            <field-name name="Невозможно установить" />-->
  <!--            <div>-->
  <!--              <Checkbox v-model="impossibleSetEknp" :binary="true" />-->
  <!--            </div>-->
  <!--          </grid-container2-col>-->
  <!--        </Fieldset>-->

  <!--        <grid-container2-col class="tw-mt-[10px]">-->
  <!--          <field-name name="3.4 Количество участников операции" />-->
  <!--          <div>-->
  <!--            <InputNumber v-model="participantCount" class="tw-w-full" />-->
  <!--          </div>-->

  <!--          <field-name name="3.5 Код валюты операции" />-->
  <!--          <div>-->
  <!--            <Dropdown-->
  <!--              v-model="currencyCode"-->
  <!--              class="tw-w-full"-->
  <!--              :options="handbookCurrencyCode"-->
  <!--              optionLabel="shortName"-->
  <!--              panel-class="tw-w-[200px]"-->
  <!--            />-->
  <!--          </div>-->

  <!--          <field-name name="3.6 Сумма операции в валюте её проведения" />-->
  <!--          <div>-->
  <!--            <InputNumber-->
  <!--              v-model="operationAmount"-->
  <!--              class="tw-w-full"-->
  <!--              locale="kz-KZ"-->
  <!--              :minFractionDigits="2"-->
  <!--            />-->
  <!--          </div>-->

  <!--          <field-name name="3.7 Сумма операции в тенге" />-->
  <!--          <div>-->
  <!--            <InputNumber-->
  <!--              v-model="operationAmountTenge"-->
  <!--              class="tw-w-full"-->
  <!--              locale="kz-KZ"-->
  <!--              :minFractionDigits="2"-->
  <!--            />-->
  <!--          </div>-->

  <!--          <field-name name="3.8 Основание совершения операции" />-->
  <!--          <div>-->
  <!--            <Dropdown-->
  <!--              v-model="operationReason"-->
  <!--              class="tw-w-full"-->
  <!--              :options="handbookOperationReason"-->
  <!--              optionLabel="shortName"-->
  <!--              panel-class="tw-w-[200px]"-->
  <!--            />-->
  <!--          </div>-->
  <!--        </grid-container2-col>-->

  <!--        <Fieldset-->
  <!--          legend="3.9 Дата и номер документа, на основании которого осуществляется операция"-->
  <!--        >-->
  <!--          <grid-container2-col>-->
  <!--            <field-name-->
  <!--              name="1. Дата документа, на основании которого осуществляется операция"-->
  <!--            />-->
  <!--            <div>-->
  <!--              <Calendar-->
  <!--                v-model="docOperationDate"-->
  <!--                showIcon-->
  <!--                class="tw-w-full"-->
  <!--                :showOnFocus="false"-->
  <!--                hourFormat="24"-->
  <!--              />-->
  <!--            </div>-->

  <!--            <field-name-->
  <!--              name="2. Номер документа, на основании которого осуществляется операция"-->
  <!--            />-->
  <!--            <div>-->
  <!--              <InputText-->
  <!--                type="text"-->
  <!--                v-model="docOperationNumber"-->
  <!--                class="tw-w-full"-->
  <!--              />-->
  <!--            </div>-->
  <!--          </grid-container2-col>-->
  <!--        </Fieldset>-->

  <!--        <grid-container2-col-->
  <!--          class="tw-mt-[10px]"-->
  <!--          v-if="isReasonFilingFishilyOperation"-->
  <!--        >-->
  <!--          <field-name name="3.10 Код признака подозрительности операции" />-->
  <!--          <div>-->
  <!--            <Dropdown-->
  <!--              v-model="suspicionFirst"-->
  <!--              class="tw-w-full"-->
  <!--              :options="handbookSuspicionFirst"-->
  <!--              optionLabel="shortName"-->
  <!--              panel-class="tw-w-[200px]"-->
  <!--            />-->
  <!--          </div>-->

  <!--          <field-name-->
  <!--            name="3.11 1-й дополнительный код признака подозрительности операции"-->
  <!--          />-->
  <!--          <div>-->
  <!--            <Dropdown-->
  <!--              v-model="suspicionSecond"-->
  <!--              class="tw-w-full"-->
  <!--              :options="handbookSuspicionSecond"-->
  <!--              optionLabel="shortName"-->
  <!--              panel-class="tw-w-[200px]"-->
  <!--            />-->
  <!--          </div>-->

  <!--          &lt;!&ndash;          Керек кезде жаса &ndash;&gt;-->
  <!--          &lt;!&ndash;          <field-name name="3.12 2-й дополнительный код признака подозрительности операции" v-if="false" />&ndash;&gt;-->
  <!--          &lt;!&ndash;          <div v-if="false">&ndash;&gt;-->
  <!--          &lt;!&ndash;            <InputText type="text" :model-value="message.MessageInformation?.SuspicionThird"&ndash;&gt;-->
  <!--          &lt;!&ndash;                       class="tw-w-full" />&ndash;&gt;-->
  <!--          &lt;!&ndash;          </div>&ndash;&gt;-->

  <!--          <field-name-->
  <!--            name="3.13 Описание возникших затруднений квалификации операции как подозрительной"-->
  <!--          />-->
  <!--          <div>-->
  <!--            <InputText-->
  <!--              type="text"-->
  <!--              v-model="descriptionDifficulties"-->
  <!--              class="tw-w-full"-->
  <!--            />-->
  <!--          </div>-->
  <!--        </grid-container2-col>-->

  <!--        <grid-container2-col class="tw-mt-[10px]">-->
  <!--          <field-name name="3.14 Дополнительная информация по операции" />-->
  <!--          <div>-->
  <!--            <Textarea-->
  <!--              v-model="moreInformation"-->
  <!--              rows="5"-->
  <!--              cols="30"-->
  <!--              class="tw-w-full"-->
  <!--            />-->
  <!--          </div>-->
  <!--        </grid-container2-col>-->
  <!--      </TabPanel>-->

  <!--      <TabPanel header="Участники">-->
  <!--        <div class="tw-w-full">-->
  <!--          <DataTable-->
  <!--            :value="message.Participants?.Participant"-->
  <!--            size="small"-->
  <!--            v-model:selection="selectedParticipant"-->
  <!--            selectionMode="single"-->
  <!--            @row-select="participantDataTableClicked"-->
  <!--            scrollable-->
  <!--            class="tw-w-[57.5vw]"-->
  <!--          >-->
  <!--            <Column-->
  <!--              field="MemberId"-->
  <!--              header="Участник"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="IsClientSubject"-->
  <!--              header="Клиент СФМ"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="ParticipantsView"-->
  <!--              header="Вид участника"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="Residence"-->
  <!--              header="Резиденство"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="ParticipantsType"-->
  <!--              header="Тип участника операции"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="CorrespondentBank['@IsOffshore']"-->
  <!--              header="Банк/филиал находится в офшорной зоне"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="CorrespondentBank.BankCountry"-->
  <!--              header="Местонахождение филиала"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="CorrespondentBank.Name"-->
  <!--              header="Наименование банка/филиала"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="CorrespondentBank.Code"-->
  <!--              header="Код банка/филиала"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="CorrespondentBank.AccountNumber"-->
  <!--              header="Номер счета участника"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--            <Column-->
  <!--              field="IndividualIssue"-->
  <!--              header="ИИН/БИН"-->
  <!--              class="tw-min-w-[200px]"-->
  <!--            ></Column>-->
  <!--          </DataTable>-->

  <!--          <Accordion :activeIndex="0">-->
  <!--            <AccordionTab header="Детализация">-->
  <!--              <grid-container2-col>-->
  <!--                <field-name name="4.1 Участник" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="participant"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookParticipant"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    @change="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name-->
  <!--                  name="4.2 Клиент субъекта финансового мониторинга"-->
  <!--                />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="clientSubject"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookIsClientSubject"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    @change="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="4.3 Вид участника" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="participantKind"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookParticipantKind"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    @change="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="4.4 Резиденство" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="participantResidence"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookParticipantResidence"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    @change="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="4.5 Тип участника операции" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="participantType"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookParticipantType"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    @change="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="4.6 Иностранное публичное должностное лицо" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="participantForeignPerson"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookParticipantForeignPerson"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    @change="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->

  <!--              <Fieldset legend="4.7 Банк участника операции">-->
  <!--                <grid-container2-col>-->
  <!--                  <field-name name="1.1 Местонахождение филиала" />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantBankCountry"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantBankCountry"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="Населенный пункт" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantBankCity"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="1.2 Наименование банка/филиала" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantBankName"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="1.2.1 Наименование СДП" />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantMoneyTransferSystem"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantMoneyTransferSystem"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="1.3 Код банка/филиала" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantBankCode"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="1.4 Номер счета участника" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantBankAccountNumber"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->
  <!--                </grid-container2-col>-->

  <!--                &lt;!&ndash;                todo: FIX THIS LATER &ndash;&gt;-->
  <!--                <Fieldset-->
  <!--                  legend="1.5 Сведения о корреспондентских счетах, участвующих в операции"-->
  <!--                >-->
  <!--                  <DataTable-->
  <!--                    :value="message.References?.Reference"-->
  <!--                    size="small"-->
  <!--                    v-model:selection="selectedReference"-->
  <!--                    selectionMode="single"-->
  <!--                    @row-select="referenceDataTableSelected"-->
  <!--                    @row-unselect="referenceDataTableUnselected"-->
  <!--                  >-->
  <!--                    <template #empty>-->
  <!--                      <div-->
  <!--                        class="tw-flex tw-justify-center tw-items-center tw-my-[20px]"-->
  <!--                      >-->
  <!--                        <div class="tw-italic">Нет данных</div>-->
  <!--                      </div>-->
  <!--                    </template>-->
  <!--                    <Column-->
  <!--                      field="BankCountry"-->
  <!--                      header="Местонахождение банка"-->
  <!--                    ></Column>-->
  <!--                    <Column-->
  <!--                      field="BankName"-->
  <!--                      header="Наименование банка"-->
  <!--                    ></Column>-->
  <!--                  </DataTable>-->
  <!--                </Fieldset>-->
  <!--              </Fieldset>-->

  <!--              <grid-container2-col class="tw-mt-[10px]">-->
  <!--                <field-name name="4.13 ИИН/БИН" />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    v-model="participantIIN"-->
  <!--                    class="tw-w-full"-->
  <!--                    @update:model-value="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->

  <!--              <Fieldset legend="4.14 ФИО">-->
  <!--                <grid-container2-col>-->
  <!--                  <field-name name="1.1 Фамилия" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantLastName"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                      :disabled="isImpossibleSetFIO"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="1.2 Имя" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantFirstName"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                      :disabled="isImpossibleSetFIO"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="1.3 Отчество" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantMiddleName"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                      :disabled="isImpossibleSetFIO"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="2.1 Невозможно установить" />-->
  <!--                  <div>-->
  <!--                    <Checkbox-->
  <!--                      v-model="isImpossibleSetFIO"-->
  <!--                      :binary="true"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->
  <!--                </grid-container2-col>-->
  <!--              </Fieldset>-->

  <!--              <grid-container2-col class="tw-mt-[10px]">-->
  <!--                <field-name name="4.15 Документ, удостоверяющий личность" />-->
  <!--                <div>-->
  <!--                  <Dropdown-->
  <!--                    v-model="participantDocumentCode"-->
  <!--                    class="tw-w-full"-->
  <!--                    :options="handbookParticipantDocumentCode"-->
  <!--                    optionLabel="shortName"-->
  <!--                    panel-class="tw-w-[200px]"-->
  <!--                    @change="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->

  <!--              <Fieldset-->
  <!--                legend="4.16 Номер и серия документа, удостоверяющего личность"-->
  <!--              >-->
  <!--                <grid-container2-col>-->
  <!--                  <field-name name="1 Номер" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantDocumentNumber"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="2 Серия (при наличии)" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantDocumentSeries"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->
  <!--                </grid-container2-col>-->
  <!--              </Fieldset>-->

  <!--              <grid-container2-col class="tw-mt-[10px]">-->
  <!--                <field-name-->
  <!--                  name="4.17 Кем выдан документ, удостоверяющий личность"-->
  <!--                />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    v-model="participantDocumentIssuedBy"-->
  <!--                    class="tw-w-full"-->
  <!--                    @update:model-value="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name-->
  <!--                  name="4.18 Когда выдан документ, удостоверяющий личность"-->
  <!--                />-->
  <!--                <div>-->
  <!--                  <Calendar-->
  <!--                    v-model="participantDocumentDate"-->
  <!--                    showIcon-->
  <!--                    class="tw-w-full"-->
  <!--                    :showOnFocus="false"-->
  <!--                    hourFormat="24"-->
  <!--                    @update:model-value="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="4.19 Дата рождения" />-->
  <!--                <div>-->
  <!--                  <Calendar-->
  <!--                    v-model="participantDateOfBirth"-->
  <!--                    showIcon-->
  <!--                    class="tw-w-full"-->
  <!--                    :showOnFocus="false"-->
  <!--                    hourFormat="24"-->
  <!--                    @update:model-value="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="4.20 Место рождения" />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    v-model="participantPlaceOfBirth"-->
  <!--                    class="tw-w-full"-->
  <!--                    @update:model-value="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->

  <!--              <Fieldset legend="4.21 Юридический адрес">-->
  <!--                <grid-container2-col>-->
  <!--                  <field-name name="Страна" />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantLegalAddressCountry"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantLegalAddressCountry"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name-->
  <!--                    name="1. Область (в том числе гг. Алматы и Астана)"-->
  <!--                  />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantLegalAddressAreaCode"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantLegalAddressAreaCode"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="2. Район" />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantLegalAddressRegionCode"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantLegalAddressRegionCode"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="3. Населенный пункт" />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantLegalAddressCity"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantLegalAddressCityCode"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name-->
  <!--                    name="4. Наименование улицы / проспекта / мр-на"-->
  <!--                  />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantLegalAddressStreet"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="5. Номер дома" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantLegalAddressHouse"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="6. Номер квартиры / офиса" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantLegalAddressOffice"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="7. Почтовый индекс" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantLegalAddressPostCode"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->
  <!--                </grid-container2-col>-->
  <!--              </Fieldset>-->

  <!--              <grid-container2-col class="tw-mt-[10px]">-->
  <!--                <field-name name="4.22 Номер контактного телефона" />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    v-model="participantPhoneNumber"-->
  <!--                    class="tw-w-full"-->
  <!--                    @update:model-value="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->

  <!--                <field-name name="4.23 Электронная почта" />-->
  <!--                <div>-->
  <!--                  <InputText-->
  <!--                    v-model="participantEmail"-->
  <!--                    class="tw-w-full"-->
  <!--                    @update:model-value="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->

  <!--              <Fieldset legend="4.24 Фактический адрес">-->
  <!--                <grid-container2-col>-->
  <!--                  <field-name name="Страна" />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantActualAddressCountry"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantActualAddressCountry"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name-->
  <!--                    name="1. Область (в том числе гг. Алматы и Астана)"-->
  <!--                  />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantActualAddressAreaCode"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantActualAddressAreaCode"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="2. Район" />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantActualAddressRegionCode"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantActualAddressRegionCode"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="3. Населенный пункт" />-->
  <!--                  <div>-->
  <!--                    <Dropdown-->
  <!--                      v-model="participantActualAddressCityCode"-->
  <!--                      class="tw-w-full"-->
  <!--                      :options="handbookParticipantActualAddressCityCode"-->
  <!--                      optionLabel="shortName"-->
  <!--                      panel-class="tw-w-[200px]"-->
  <!--                      @change="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name-->
  <!--                    name="4. Наименование улицы / проспекта / мр-на"-->
  <!--                  />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantActualAddressStreet"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="5. Номер дома" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantActualAddressHouse"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="6. Номер квартиры / офиса" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantActualAddressOffice"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->

  <!--                  <field-name name="7. Почтовый индекс" />-->
  <!--                  <div>-->
  <!--                    <InputText-->
  <!--                      v-model="participantActualAddressPostCode"-->
  <!--                      class="tw-w-full"-->
  <!--                      @update:model-value="changedParticipantFields"-->
  <!--                    />-->
  <!--                  </div>-->
  <!--                </grid-container2-col>-->
  <!--              </Fieldset>-->

  <!--              <grid-container2-col class="tw-mt-[10px]">-->
  <!--                <field-name-->
  <!--                  name="4.25 Дополнительная информации об участнике операции"-->
  <!--                />-->
  <!--                <div>-->
  <!--                  <Textarea-->
  <!--                    v-model="participantAdditionalInfo"-->
  <!--                    rows="5"-->
  <!--                    cols="30"-->
  <!--                    class="tw-w-full"-->
  <!--                    @update:model-value="changedParticipantFields"-->
  <!--                  />-->
  <!--                </div>-->
  <!--              </grid-container2-col>-->
  <!--            </AccordionTab>-->
  <!--          </Accordion>-->
  <!--        </div>-->
  <!--      </TabPanel>-->
  <!--    </TabView>-->
  <!--  </div>-->
</template>

<!--<style scoped></style>-->
