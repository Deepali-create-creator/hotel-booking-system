<template>
  <div class="hotel-search">
    <select v-model="searchLocation">
      <option value="">Select a location</option>
      <option v-for="loc in locations" :key="loc" :value="loc">{{ loc }}</option>
    </select>

    <input v-model="searchName" placeholder="Hotel name (optional)" />
    <button @click="searchHotels">Search</button>
  </div>
</template>

<script>
import { ref, onMounted } from 'vue'
import axios from 'axios'

export default {
  emits: ['search-results'],
  setup(props, { emit }) {
    const searchName = ref('')
    const searchLocation = ref('')
    const locations = ref([])

    const fetchLocations = async () => {
      try {
        const res = await axios.get('https://localhost:7237/api/Hotel/locations')
        locations.value = res.data
      } catch (err) {
        console.error('Failed to fetch locations', err)
      }
    }

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

    onMounted(fetchLocations)

    return { searchName, searchLocation, searchHotels, locations }
  }
}
</script>

<style scoped>
.hotel-search {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.hotel-search select,
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

  .hotel-search select,
  .hotel-search input {
    flex: 1;
  }
}
</style>
