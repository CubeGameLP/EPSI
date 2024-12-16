<template>
  <q-dialog v-model="isVisible" persistent>
    <q-card>
      <q-card-section>
        <div class="text-h6">Update Item</div>
      </q-card-section>
      <q-card-section class="q-pt-none">
        <div class="q-gutter-md">
          <div><strong>Item:</strong> {{ itemName }}</div>
          <div><strong>Room:</strong> {{ roomName }}</div>
          <div><strong>Shelf:</strong> {{ shelfID }}</div>
        </div>
        <div class="row items-center q-gutter-sm">
          <q-btn flat round icon="remove" @click="decreaseAmount" />
          <q-input
            v-model.number="localItemAmount"
            type="number"
            dense
            class="col"
          />
          <q-btn flat round icon="add" @click="increaseAmount" />
        </div>
      </q-card-section>
      <q-card-actions class="items-end">
        <q-btn flat label="Cancel" color="primary" @click="onClose" />
        <q-btn flat label="OK" color="primary" @click="confirmUpdate" />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';
import { defineProps, defineEmits } from 'vue';

const props = defineProps<{
  readonly isVisible: boolean;
  readonly itemName: string;
  readonly roomName: string;
  readonly shelfID: string;
  readonly itemAmount: number;
  readonly itemID: number;
}>();

const emit = defineEmits<{
  (
    e: 'update',
    payload: { itemID: number; shelfID: string; amountDifference: number },
  ): void;
  (e: 'close'): void;
}>();

// Lokaler Zustand
const isVisible = ref(props.isVisible);
const localItemAmount = ref(props.itemAmount);

// Beobachte die Sichtbarkeit des Dialogs
watch(
  () => props.isVisible,
  (newVal) => {
    isVisible.value = newVal;
  },
);

// Funktionen
const decreaseAmount = () => {
  localItemAmount.value = Math.max(0, localItemAmount.value - 1);
};

const increaseAmount = () => {
  localItemAmount.value += 1;
};

const confirmUpdate = () => {
  const amountDifference = localItemAmount.value - props.itemAmount;
  emit('update', {
    itemID: props.itemID,
    shelfID: props.shelfID,
    amountDifference,
  });
  emit('close');
};

const onClose = () => {
  emit('close');
};
</script>
