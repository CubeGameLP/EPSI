<template>
  <q-page padding>
    <q-card>
      <q-card-section>
        <FilterComponent :on-filter-change="handleFilterChange" />
      </q-card-section>
      <q-separator />
      <q-card-section>
        <TableComponent :data="data" />
      </q-card-section>
    </q-card>
  </q-page>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import FilterComponent from 'components/FilterComponent.vue';
import TableComponent from 'components/TableComponent.vue';
import { fetchTestData } from 'src/services/apiService';
import type { ItemDTO } from 'src/types/ItemDTO';

const data = ref<ItemDTO[]>([]);

async function handleFilterChange(filter: string) {
  console.log('Filter:', filter); // Überprüfen, ob der Filter korrekt empfangen wird
  try {
    data.value = await fetchTestData(filter);
  } catch (error) {
    console.error('Failed to load data:', error);
  }
}

onMounted(async () => {
  await handleFilterChange('');
});
</script>
