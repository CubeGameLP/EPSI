<template>
  <q-input
    v-model="filter"
    outlined
    label="Filter"
    dense
    @keyup.enter="onFilter"
  />
</template>

<script setup lang="ts">
import { ref, defineProps } from 'vue';

const props = defineProps<{
  onFilterChange: (filter: string) => void;
}>();

const filter = ref('');

function onFilter() {
  props.onFilterChange(filter.value);
}
</script>
