<template>
  <div class="hotel-search">
    <input v-model="searchLocation" placeholder="Where are you going?" />
    <input v-model="searchName" placeholder="Hotel name (optional)" />
    <button @click="searchHotels">Search</button>
  </div>
</template>

<script>
import { ref } from 'vue'
import axios from 'axios'

export default {
  emits: ['search-results'],
  setup(props, { emit }) {
    const searchName = ref('')
    const searchLocation = ref('')

    const searchHotels = async () => {
    try {
      const res = await axios.get('https://localhost:7237/api/Hotel/search', {
        params: {
          name: searchName.value.trim(),
          location: searchLocation.value.trim()
        }
      })
      emit('search-results', res.data)
    } catch (err) {
      console.error('Failed to fetch hotels', err)
    }
  }


    return { searchName, searchLocation, searchHotels }
  }
}
</script>



<style scoped>
.hotel-search {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.hotel-search input {
  padding: 12px;
  border-radius: 6px;
  border: 1px solid #ccc;
  font-size: 16px;
}

.hotel-search button {
  padding: 12px;
  background-color: #0071c2;
  color: white;
  border: none;
  border-radius: 6px;
  font-weight: bold;
  cursor: pointer;
  font-size: 16px;
}

.hotel-search button:hover {
  background-color: #005fa3;
}

@media (min-width: 768px) {
  .hotel-search {
    flex-direction: row;
    align-items: center;
  }

  .hotel-search input {
    flex: 1;
  }
}
</style>
