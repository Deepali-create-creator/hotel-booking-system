<template>
  <div>
    <h2>Login</h2>
    <form @submit.prevent="handleLogin">
      <input v-model="email" type="email" placeholder="Email" required />
      <input v-model="password" type="password" placeholder="Password" required />
      <button type="submit">Login</button>
      <p v-if="message" :style="{ color: isError ? 'red' : 'green' }">{{ message }}</p>
    </form>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const email = ref('')
const password = ref('')
const message = ref('')
const isError = ref(false)

const handleLogin = async () => {
  try {
    const response = await fetch('https://localhost:7237/api/auth/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        email: email.value,
        password: password.value
      })
    })

    const data = await response.json()

    if (response.ok && data.status) {
      isError.value = false
      message.value = 'Login successful'

       // ✅ Store user in localStorage
      localStorage.setItem('user', JSON.stringify(data.user))

      // Reload to reflect logged-in UI
      window.location.reload()
    } else {
      isError.value = true
      message.value = data.message || 'Login failed'
      alert("Login failed");
    }
  } catch (error) {
    isError.value = true
    message.value = 'An error occurred during login'
    alert("Login failed");
  }
}
</script>
