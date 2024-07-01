<script setup lang="ts">

</script>

<template>
  <div
    class="tw-h-[64px] tw-bg-[#008b8a] tw-flex tw-items-center tw-justify-between tw-px-[10px]"
  >
    <div class="tw-flex tw-items-center">
      <div>
        <a href="/">
          <img
            alt="/"
            src="https://hcsbk.kz/local/templates/.default/images/logo-otbasy-bank_white.svg"
            class="logo-otbasy"
            width="150"
          />
        </a>
      </div>
      <div class="tw-ml-[12px] tw-flex tw-justify-center tw-flex-col">
        <div class="tw-text-[21px] tw-font-bold tw-text-white">Планы</div>
      </div>
    </div>

    <div>
    </div>
  </div>
</template>

<style scoped>
.our-text-bl {
  text-decoration: none;
  color: white !important;
  margin-left: 10px;
  margin-right: 10px;
  transition: 0.5s;
  position: relative;
  display: inline-flex;
  gap: 5px;
  align-items: center;
  cursor: pointer;
}

.our-text-bl::after {
  position: absolute;
  content: "";
  top: 100%;
  left: 0;
  width: 100%;
  height: 1px;
  background: white;
  transform: scaleX(0);
  transform-origin: right;
  transition: transform 0.5s;
}

.our-text-bl:hover {
  color: #95a5a6;
}

.our-text-bl:hover::after {
  transform: scaleX(1);
  transform-origin: left;
}
</style>
