<template>
    <div class="login-page">
      <h1 class="title">Login</h1>
      <form @submit.prevent="login" class="login-form">
        <div class="form-group">
          <label for="username" class="label">Username:</label>
          <input type="text" v-model="username" id="username" class="input" />
        </div>
        <div class="form-group">
          <label for="password" class="label">Password:</label>
          <input type="password" v-model="password" id="password" class="input" />
        </div>
        <button type="submit" class="submit-button">Submit</button>
        <div v-if="error" class="error-message">{{ error }}</div>
      </form>
    </div>
  </template>
  


<script>
import store from '../../store';
export default {
    data() {
        return {
            username: '',
            password: '',
            error: ''
        }
    },
    methods: {
        login() {
            // Call API to authenticate user
            // For demonstration purposes, we'll use a mock API
            const users = [
                { username: 'john', password: 'hello', active: true },
                { username: 'jane', password: 'world', active: false },
                { username: 'user', password: 'pass', active: true },
            ]
            const user = users.find((u) => u.password === this.password)
            if (user && user.active) {
                // Login successful, redirect to /welcome
                store.commit('SET_AUTH', {
                    isAuthenticated: true,
                    isActive: true,
                    username: this.username
                });
                this.$router.push('/welcome')
            } else {
                // Login failed, show error message
                this.error = 'We could not log you in. Please check your username/password and try again.'
                this.password = ''
            }
        }
    }
}
</script>

<style scoped>
.login-page {
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
  margin-bottom: 20px;
}

.login-form {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.form-group {
  margin-bottom: 20px;
}

.label {
  font-size: 16px;
  font-weight: bold;
  margin-bottom: 10px;
}

.input {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.submit-button {
  background-color: #4CAF50;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.submit-button:hover {
  background-color: #3e8e41;
}

.error-message {
  color: red;
  font-size: 14px;
  margin-top: 10px;
}
</style>