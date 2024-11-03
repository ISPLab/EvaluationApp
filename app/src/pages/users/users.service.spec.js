// api.service.spec.js
import axios from 'axios';
import userService from '../../services/users.service';

jest.mock('axios');

describe('userService', () => {
  afterEach(() => {
    jest.resetAllMocks();
  });

  describe('getUsers', () => {
    it('should return a list of users', async () => {
      const user = 
        {"id":1,"username":"someuser1","password":"password","isActive":true}
 
      axios.get.mockResolvedValue({ data: user });


      const result = await userService.getUsers();
      result.find((u) => u.username === `someuser1`);
      expect(result).indcludes(user);
    });

    // it('should handle error', async () => {
    //   axios.get.mockRejectedValue(new Error('Error'));
    //   await expect(userService.getUsers()).rejects.toThrow('Error');
    // });
  });
/*
  describe('getUser', () => {
    it('should return a user', async () => {
      const user = { id: 1, name: 'John Doe' };
      axios.get.mockResolvedValue({ data: user });

      const result = await userService.getUser(1);
      expect(result).toEqual(user);
    });

    it('should handle error', async () => {
      axios.get.mockRejectedValue(new Error('Error'));
      await expect(userService.getUser(1)).rejects.toThrow('Error');
    });
  });

  describe('createUser', () => {
    it('should create a new user', async () => {
      const user = { id: 1, name: 'John Doe' };
      axios.post.mockResolvedValue({ data: user });

      const result = await userService.createUser(user);
      expect(result).toEqual(user);
    });

    it('should handle error', async () => {
      axios.post.mockRejectedValue(new Error('Error'));
      await expect(userService.createUser({})).rejects.toThrow('Error');
    });
  });

  describe('updateUser', () => {
    it('should update a user', async () => {
      const user = { id: 1, name: 'John Doe' };
      axios.put.mockResolvedValue({ data: user });

      const result = await userService.updateUser(1, user);
      expect(result).toEqual(user);
    });

    it('should handle error', async () => {
      axios.put.mockRejectedValue(new Error('Error'));
      await expect(userService.updateUser(1, {})).rejects.toThrow('Error');
    });
  });

  describe('deleteUser', () => {
    it('should delete a user', async () => {
      axios.delete.mockResolvedValue();

      await userService.deleteUser(1);
      expect(axios.delete).toHaveBeenCalledTimes(1);
    });

    it('should handle error', async () => {
      axios.delete.mockRejectedValue(new Error('Error'));
      await expect(userService.deleteUser(1)).rejects.toThrow('Error');
    });
  });*/
});