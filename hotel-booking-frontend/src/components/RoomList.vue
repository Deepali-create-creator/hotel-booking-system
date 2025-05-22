<template>
  <div class="room-list">
    <h3>Rooms for {{ hotel.name }}</h3>
    <ul>
      <li v-for="room in hotel.rooms" :key="room.id" class="room-item">
        {{ room.roomType }} - ₹{{ room.price }} 
        <span v-if="room.isAvailable">✔ Available</span>
        <span v-else>❌ Not Available</span>

        <button 
          v-if="room.isAvailable && bookingRoomId !== room.id" 
          class="book-btn" 
          @click="startBooking(room.id)"
        >
          Book
        </button>

        <!-- Booking form -->
        <div v-if="bookingRoomId === room.id" class="booking-form">
          <input v-model="guestName" placeholder="Your Name" />
          <input v-model="guestEmail" type="email" placeholder="Your Email" />
          <input v-model="checkInDate" type="date" placeholder="Check-in Date" />
          <input v-model="checkOutDate" type="date" placeholder="Check-out Date" />

          <button @click="submitBooking(room.id, hotel.id)">Submit</button>
          <button @click="cancelBooking">Cancel</button>

          <p v-if="bookingMessage" :class="{ 'success-msg': bookingSuccess, 'error-msg': !bookingSuccess }">
            {{ bookingMessage }}
          </p>
        </div>
      </li>
    </ul>
    <button class="close-btn" @click="$emit('close')">Close</button>
  </div>
</template>

<script setup>
import { defineProps, ref } from 'vue'
import axios from 'axios'

const props = defineProps({
  hotel: Object
})

// Booking form state
const bookingRoomId = ref(null)
const guestName = ref('')
const guestEmail = ref('')
const checkInDate = ref('')
const checkOutDate = ref('')
const bookingMessage = ref('')
const bookingSuccess = ref(false)

const startBooking = (roomId) => {
  bookingRoomId.value = roomId
  bookingMessage.value = ''
  bookingSuccess.value = false
  guestName.value = ''
  guestEmail.value = ''
  checkInDate.value = ''
  checkOutDate.value = ''
}

const cancelBooking = () => {
  bookingRoomId.value = null
  bookingMessage.value = ''
  bookingSuccess.value = false
}

const submitBooking = async (roomId, hotelId) => {
  if (!guestName.value || !guestEmail.value || !checkInDate.value || !checkOutDate.value) {
    bookingMessage.value = "All fields are required."
    bookingSuccess.value = false
    return
  }

  try {
    await axios.post('https://localhost:7237/api/Booking', {
      roomId,
      hotelId,
      guestName: guestName.value,
      guestEmail: guestEmail.value,
      checkInDate: checkInDate.value,
      checkOutDate: checkOutDate.value
    })
    bookingMessage.value = 'Room booked successfully! ✅'
    bookingSuccess.value = true
  } catch (error) {
    console.error('Booking failed:', error)
    bookingMessage.value = 'Failed to book the room. ❌'
    bookingSuccess.value = false
  }
}
</script>

<style scoped>
.room-list {
  background: #fff;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 10px;
  margin-top: 15px;
}

.room-item {
  margin-bottom: 10px;
}

.book-btn {
  margin-left: 10px;
  background-color: #0071c2;
  color: white;
  border: none;
  padding: 4px 10px;
  border-radius: 5px;
  cursor: pointer;
  font-size: 0.9rem;
}

.book-btn:hover {
  background-color: #005b9f;
}

.booking-form {
  margin-top: 10px;
  display: flex;
  flex-direction: column;
  gap: 8px;
  max-width: 300px;
}

.booking-form input {
  padding: 8px;
  border-radius: 6px;
  border: 1px solid #ccc;
}

.booking-form button {
  padding: 8px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  font-weight: bold;
}

.booking-form button:first-of-type {
  background-color: #0071c2;
  color: white;
}

.booking-form button:first-of-type:hover {
  background-color: #005b9f;
}

.booking-form button:last-of-type {
  background-color: #ccc;
}

.booking-form button:last-of-type:hover {
  background-color: #aaa;
}

.success-msg {
  color: green;
}

.error-msg {
  color: red;
}

.close-btn {
  margin-top: 10px;
  padding: 6px 12px;
  background: #ccc;
  border: none;
  border-radius: 6px;
  cursor: pointer;
}
</style>
