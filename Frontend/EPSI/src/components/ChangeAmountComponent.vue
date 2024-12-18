<template>
  <q-dialog v-model="dialogVisible">
    <q-card>
      <q-card-section>
        <div class="text-h6">Change Amount</div>
      </q-card-section>
      <q-card-section class="q-pt-none">
        <div class="q-gutter-md">
          <div>
            <strong>Item:</strong>
            {{ ParsedData.itemName || 'No Data' }}
          </div>
          <div>
            <strong>Room:</strong> {{ ParsedData.roomName || 'No Data' }}
          </div>
          <div>
            <strong>Shelf:</strong> {{ ParsedData.shelfID || 'No Data' }}
          </div>
        </div>
        <div class="row items-center q-gutter-sm">
          <q-btn flat round icon="remove" @click="decreaseAmount" />
          <q-input
            :model-value="localItemAmount"
            type="text"
            dense
            class="col"
          />
          <q-btn flat round icon="add" @click="increaseAmount" />
        </div>
      </q-card-section>
      <q-card-actions>
        <q-btn flat label="Cancel" color="primary" @click="onClose" />
        <q-btn flat label="OK" color="primary" @click="confirmUpdate" />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script setup lang="ts">
import { watch } from 'vue';
import { defineProps, defineEmits } from 'vue';
import { ItemDTO } from '../types/ItemDTO';

const props = defineProps<{
  data: ItemDTO | null;
}>();

const emit = defineEmits<{
  (
    e: 'update',
    payload: { itemID: number; shelfID: string; amountDifference: number },
  ): void;
  (e: 'close'): void;
}>();

let dialogVisible = false;
let ParsedData = JSON.parse(JSON.stringify(props.data));
let localItemAmount: number = 0;

watch(
  () => props.data,
  (newData) => {
    if (newData) {
      dialogVisible = true;
    }
  },
  { immediate: true },
);

const decreaseAmount = () => {
  localItemAmount = Math.max(-ParsedData.itemAmount, localItemAmount - 1);
};

const increaseAmount = () => {
  localItemAmount += 1;
};

const confirmUpdate = () => {
  const amountDifference = localItemAmount;
  emit('update', {
    itemID: props.data?.ItemID ?? 0,
    shelfID: String(props.data?.ShelfID),
    amountDifference,
  });
  onClose();
};

const onClose = () => {
  dialogVisible = false;
  emit('close');
};
</script>
