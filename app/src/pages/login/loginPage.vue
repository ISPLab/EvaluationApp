<template>
    <div>
        <h1>Login</h1>
        <form @submit.prevent="login">
            <label>Username:</label>
            <input type="text" v-model="username" />
            <br />
            <label>Password:</label>
            <input type="password" v-model="password" />
            <br />
            <button type="submit">Submit</button>
            <div v-if="error" style="color: red">{{ error }}</div>
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