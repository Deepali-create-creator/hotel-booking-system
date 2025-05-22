<!-- src/components/AuthModal.vue -->
<template>
  <div class="modal-overlay" @click.self="close">
    <div class="modal-content">
      <button class="close-btn" @click="close">×</button>
      <slot />
    </div>
  </div>
</template>

<script setup>
const emit = defineEmits(['close'])
const close = () => emit('close')
</script>

<style scoped>
.modal-overlay {
  position: fixed;
  top: 0; left: 0;
  width: 100vw; height: 100vh;
  background: rgba(0,0,0,0.5);
  display: flex; justify-content: center; align-items: center;
  z-index: 1000;
}

.modal-content {
  background: white;
  border-radius: 12px;
  padding: 30px;
  min-width: 400px;
  position: relative;
}

.close-btn {
  position: absolute;
  top: 10px; right: 15px;
  font-size: 1.5rem;
  background: none;
  border: none;
  cursor: pointer;
}
</style>
