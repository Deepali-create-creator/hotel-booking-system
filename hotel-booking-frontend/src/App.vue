<script setup>
import HomePage from './components/HomePage.vue';
</script>

<template>
<HomePage></HomePage>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
html, body {
  margin: 0;
  padding: 0;
  overflow-x: hidden; /* Prevent global horizontal scroll */
  box-sizing: border-box;
  width: 100%;
}


</style>
