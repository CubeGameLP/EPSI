<template>
  <q-table :rows="data" :columns="columns" row-key="ItemID" flat bordered>
    <template #body-cell-ItemName="slotProps">
      <q-td>{{ slotProps.row.ItemName }}</q-td>
    </template>
    <template #body-cell-RoomName="slotProps">
      <q-td>{{ slotProps.row.RoomName }}</q-td>
    </template>
    <template #body-cell-ShelfID="slotProps">
      <q-td>{{ slotProps.row.ShelfID }}</q-td>
    </template>
    <template #body-cell-ItemAmount="slotProps">
      <q-td>{{ slotProps.row.ItemAmount }}</q-td>
    </template>
  </q-table>
</template>

<script setup lang="ts">
import { defineProps, ref } from 'vue';
import type { ItemDTO } from 'src/types/ItemDTO';

const columns = ref([
  {
    name: 'itemName',
    align: 'left' as 'left' | 'right' | 'center',
    label: 'Item Name',
    field: 'itemName',
  },
  {
    name: 'roomName',
    align: 'left' as 'left' | 'right' | 'center',
    label: 'Room Name',
    field: 'roomName',
  },
  {
    name: 'shelfID',
    align: 'left' as 'left' | 'right' | 'center',
    label: 'Shelf ID',
    field: 'shelfID',
  },
  {
    name: 'itemAmount',
    align: 'right' as 'left' | 'right' | 'center',
    label: 'Item Amount',
    field: 'itemAmount',
  },
]);

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const props = defineProps<{
  data: ItemDTO[];
}>();
</script>
