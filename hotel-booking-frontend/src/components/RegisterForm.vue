<template>
  <div>
    <h2>Register</h2>
    <form @submit.prevent="handleRegister">
      <input v-model="email" type="email" placeholder="Email" required />
      <input v-model="password" type="password" placeholder="Password" required />
      <button type="submit">Register</button>
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

const handleRegister = async () => {
  try {
    const response = await fetch('https://localhost:7237/api/auth/register', {
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

    if (response.ok) {
      isError.value = false
      message.value = data.message || 'Registration successful'
      email.value = ''
      password.value = ''
      alert("User registered successfully");
    } else {
      isError.value = true
      message.value = data.message || 'Registration failed'
      alert("User registeration failed! try again");

    }
  } catch (error) {
    isError.value = true
    message.value = 'An error occurred while registering'
    alert("User registeration failed! try again");
  }
}
</script>
