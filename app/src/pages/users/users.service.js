// api.service.js
import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5144/api/'
});

const userService = {
  async getUsers() {
    try {
      console.log('getUsers');
      const response = await api.get('/user');
      return response.data;
    } catch (error) {
      console.error(error);
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