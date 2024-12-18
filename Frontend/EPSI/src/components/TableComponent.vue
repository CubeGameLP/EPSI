<template>
  <q-table
    :rows="data"
    :columns="columns"
    row-key="ItemID"
    flat
    bordered
    @row-click="(evt, row) => openDialog(evt, row)"
  >
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

  <ChangeAmountComponent
    v-if="isDialogVisible"
    :data="selectedItem"
    @update="updateItemAmount"
    @close="closeDialog"
  />
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';
import ChangeAmountComponent from './ChangeAmountComponent.vue';
import type { ItemDTO } from 'src/types/ItemDTO';

const props = defineProps<{
  data: ItemDTO[];
}>();

watch(
  () => props.data,
  (newData) => {
    console.log('Table data updated:', newData);
  },
);

const columns = ref([
  {
    name: 'itemName',
    align: 'left' as const,
    label: 'Item Name',
    field: 'itemName',
  },
  {
    name: 'roomName',
    align: 'left' as const,
    label: 'Room Name',
    field: 'roomName',
  },
  {
    name: 'shelfID',
    align: 'left' as const,
    label: 'Shelf ID',
    field: 'shelfID',
  },
  {
    name: 'itemAmount',
    align: 'right' as const,
    label: 'Item Amount',
    field: 'itemAmount',
  },
]);

let selectedItem: ItemDTO | null;
const isDialogVisible = ref(false);

const openDialog = (_evt: Event, row: ItemDTO) => {
  selectedItem = row;
  isDialogVisible.value = true;
};

const closeDialog = () => {
  isDialogVisible.value = false;
  selectedItem = null;
};

const updateItemAmount = (payload: {
  itemID: number;
  shelfID: string;
  amountDifference: number;
}) => {
  console.log('Update payload:', payload);
};
</script>
