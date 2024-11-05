// api.service.js
import axios from 'axios';
import store from '../store';
//import router from '@/router';

const api = axios.create({
  baseURL: 'http://localhost:5144/api/'
});

const userService = {

  async login(username, password) {
    try {
      const response = await api.post('/login', {
        username: username,
        password: password
      })
      console.log(response.data)
      return response.data;
    } catch (error) {
      console.error(error)
    }
  },  


  async getUsers() {
    try {
      
      console.log('getUsers');
      const response = await api.get('/users',
       {
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'User': store.state.auth.username,
            'UserId': store.state.auth.id
          }}
      );
      return response.data;
    } catch (error) {
     console.error(error);  
     throw error;  
    }
  },

  async getUser(id) {
    try {
      const response = await api.get(`/user/${id}`);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },

  async createUser(user) {
    try {
      const response = await api.post('/user', user);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },

  async updateUser(user) {
    try {
      const response = await api.put(`/user/${user.id}`, user);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },
  async updateUsers(users) {
    try {
      const response = await api.post('/users', users);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },
  async deleteUser(id) {
    try {
      await api.delete(`/user/${id}`);
    } catch (error) {
      console.error(error);
    }
  }
};

export default userService;