import axios from 'axios';
import type { ItemDTO } from '@/src/types/ItemDTO';

const API_URL = 'https://localhost:7237/Testdata/GetAllData';

export const fetchTestData = async (filter = ''): Promise<ItemDTO[]> => {
  try {
    const response = await axios.get<ItemDTO[]>(API_URL, {
      params: { filter },
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
    throw error;
  }
};
