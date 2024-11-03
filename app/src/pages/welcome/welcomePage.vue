<template>
    <div class="welcome-page">
      <h1 class="title">Welcome, {{ username }}!</h1>
      <p class="description">This page is for authenticated users only.</p>
      <div class="actions">
           <button @click="goToUsers" class="button">Go to Users</button>
      </div>
    </div>
  </template>
  
  <script>
  import { computed } from 'vue';
  //import { useRouter } from 'vue-router';
  import { useStore } from 'vuex';
  import { useRouter } from "vue-router";
  
  export default {
    name: 'WelcomePage',
    setup() {
      const router = useRouter();
      const store = useStore();
  
      const username = computed(() => store.state.auth.username);
  
      const goToUsers = () => {
        console.log('Go to Users');
        router.push({ name: 'users' });
      };
  
      return {
        username,
        goToUsers,
      };
    },
  };
  </script>
  <style scoped>
  .welcome-page {
    max-width: 400px;
    margin: 40px auto;
    padding: 20px;
    background-color: #f9f9f9;
    border: 1px solid #ddd;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  }
  
  .title {
    font-size: 24px;
    font-weight: bold;
    margin-bottom: 10px;
  }
  
  .description {
    font-size: 16px;
    color: #666;
    margin-bottom: 20px;
  }
  
  .actions {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }
  
  .button {
    background-color: #4CAF50;
    color: #fff;
    padding: 10px 20px;
    border: none;
    border-radius: 5px;
    cursor: pointer;
  }
  
  .button:hover {
    background-color: #3e8e41;
  }
  </style>