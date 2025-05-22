<script setup>
import { ref, onMounted } from 'vue'
import HotelSearch from '../components/HotelSearch.vue'
import HotelList from '../components/HotelList.vue'
import AuthModal from '../components/AuthModal.vue'
import LoginForm from '../components/LoginForm.vue'
import RegisterForm from '../components/RegisterForm.vue'

const hotels = ref([])
const showLogin = ref(false)
const showRegister = ref(false)
const user = ref(null)

onMounted(() => {
  const storedUser = localStorage.getItem('user')
  if (storedUser) {
    user.value = JSON.parse(storedUser)
  }
})

const handleSearchResults = (results) => {
  hotels.value = results
}

const logout = () => {
  localStorage.removeItem('user')
  user.value = null
  window.location.reload()
}
</script>

<template>
  <div class="home-page">
    <!-- Header like Booking.com -->
    <header class="main-header">
      <div class="header-container">
        <div class="logo">Booking.com</div>
        <nav class="nav-links">
          <a href="#">Stays</a>
          <a href="#">Flights</a>
          <a href="#">Car Rentals</a>
        </nav>
        <div class="auth-controls">
          <template v-if="user">
            <span class="welcome">Welcome, {{ user.email }}</span>
            <button @click="logout">Logout</button>
          </template>
          <template v-else>
            <button @click="showLogin = true">Login</button>
            <button @click="showRegister = true">Register</button>
          </template>
        </div>
      </div>
    </header>

    <!-- Hero Section -->
    <section class="hero">
      <div class="hero-content">
        <h1>Find your next stay</h1>
        <p>Search deals on hotels, homes, and much more...</p>
      </div>

      <!-- Overlapping Search Bar -->
      <div class="search-container">
        <HotelSearch @search-results="handleSearchResults" />
      </div>
    </section>

    <!-- Content Section -->
    <section class="content">
      <HotelList :hotels="hotels" />
    </section>

    <!-- Modals -->
    <AuthModal v-if="showLogin" @close="showLogin = false">
      <LoginForm />
    </AuthModal>
    <AuthModal v-if="showRegister" @close="showRegister = false">
      <RegisterForm />
    </AuthModal>
  </div>
</template>

<style scoped>
.home-page {
  width: 100vw;
  overflow-x: hidden;
}

/* Header */
.main-header {
  background-color: #003580;
  color: white;
  padding: 16px 40px;
  display: flex;
  justify-content: center;
  width: 100%;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.15);
  position: relative;
  z-index: 20;
}

.header-container {
  max-width: 1200px;
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.logo {
  font-size: 1.8rem;
  font-weight: bold;
}

.nav-links {
  display: flex;
  gap: 20px;
}

.nav-links a {
  color: white;
  text-decoration: none;
  font-weight: 500;
}

.auth-controls {
  display: flex;
  gap: 10px;
  align-items: center;
}

.auth-controls button {
  background: white;
  color: #003580;
  padding: 8px 16px;
  border: none;
  border-radius: 6px;
  font-weight: bold;
  cursor: pointer;
}

.auth-controls button:hover {
  background: #e6f0ff;
}

.welcome {
  font-weight: bold;
  color: white;
}

/* Hero */
.hero {
  background-color: #003580;
  width: 100%;
  height: 50vh;
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
}

.hero-content {
  text-align: center;
  color: white;
  padding: 0 20px;
}

/* Search Bar */
.search-container {
  position: absolute;
  bottom: -40px;
  left: 50%;
  transform: translateX(-50%);
  width: 90%;
  max-width: 900px;
  background: white;
  padding: 20px;
  border-radius: 12px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
  z-index: 10;
}

/* Content */
.content {
  background-color: white;
  padding-top: 80px; /* space for floating search bar */
  padding-left: 20px;
  padding-right: 20px;
  min-height: 50vh;
}
</style>
