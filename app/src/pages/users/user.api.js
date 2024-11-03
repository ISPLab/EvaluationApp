// api.service.js
import axios from 'axios';

const api = axios.create({
  baseURL: 'https://your-api-url.com/api'
});

const userService = {
  async getUsers() {
    try {
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

  async updateUser(id, user) {
    try {
      const response = await api.put(`/user/${id}`, user);
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