<script setup>
import { defineProps, ref } from 'vue'
import RoomList from './RoomList.vue'

const props = defineProps({
  hotels: {
    type: Array,
    required: true
  }
})

const placeholderImage = 'https://via.placeholder.com/300x200?text=Hotel+Image'
const expandedHotelId = ref(null)

const toggleRoomList = (hotelId) => {
  expandedHotelId.value = expandedHotelId.value === hotelId ? null : hotelId
}
</script>

<template>
  <div class="hotel-list-container">
    <div v-if="!hotels || hotels.length === 0" class="no-hotels">
      No hotels found.
    </div>
    <div class="hotel-grid" v-else>
      <div v-for="hotel in hotels" :key="hotel.id" class="hotel-card">
        <img class="hotel-image" :src="hotel.imageUrl || placeholderImage" alt="Hotel Image" />
        <div class="hotel-content">
          <h2 class="hotel-name">{{ hotel.name }}</h2>
          <p class="hotel-location">{{ hotel.location }}</p>
          <p class="hotel-description">{{ hotel.description }}</p>

          <button class="check-btn" @click="toggleRoomList(hotel.id)">
            {{ expandedHotelId === hotel.id ? 'Hide Rooms' : 'Check Availability' }}
          </button>

          <RoomList
            v-if="expandedHotelId === hotel.id"
            :hotel="hotel"
            @close="expandedHotelId = null"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.hotel-list-container {
  padding: 20px;
  max-width: 1200px;
  margin: auto;
}

.hotel-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(340px, 1fr));
  gap: 20px;
}

.hotel-card {
  background: #fff;
  border-radius: 12px;
  overflow: hidden;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.07);
  transition: transform 0.2s ease;
  display: flex;
  flex-direction: column;
}

.hotel-card:hover {
  transform: translateY(-5px);
}

.hotel-image {
  width: 100%;
  height: 200px;
  object-fit: cover;
}

.hotel-content {
  padding: 16px;
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.hotel-name {
  margin: 0;
  font-size: 1.4rem;
  font-weight: bold;
  color: #003580;
}

.hotel-location {
  color: #555;
  font-size: 0.95rem;
}

.hotel-description {
  font-size: 0.9rem;
  color: #333;
  line-height: 1.4;
  margin-bottom: 8px;
}

.check-btn {
  align-self: start;
  background-color: #0071c2;
  color: white;
  border: none;
  padding: 8px 16px;
  border-radius: 8px;
  font-weight: 600;
  font-size: 0.95rem;
  cursor: pointer;
  transition: background-color 0.2s ease;
}

.check-btn:hover {
  background-color: #005fa3;
}

.no-hotels {
  text-align: center;
  color: #888;
  font-size: 1.2rem;
  padding: 40px 0;
}
</style>
