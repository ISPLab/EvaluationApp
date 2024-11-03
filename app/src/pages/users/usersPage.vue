<template>
  <div class="admin-page">
    <h1 class="title">Users Administration Page</h1>
    <div v-if="modifiedUsers.length > 0" class="notification-panel">
  <span class="notification-message">One or more users have been modified.</span>
  <button @click="saveModifiedUsers" class="save-button">Save Changes</button>
</div>
    <table class="users-table">
      <tr>
        <th>Username</th>
        <th>Status</th>
      </tr>
      <tr v-for="user in users" :key="user.id" class="user-row" @click="showUserPanel(user)" >
        <td class="username">{{ user.username }}</td>
        <td class="status">{{ user.active ? 'Active' : 'Inactive' }}</td>
      </tr>
    </table>
    <div v-if="showPanel" class="user-panel">
      <span class="username-label">Username: {{ selectedUser.username }}</span>
      <div class="status-checkbox">
        <input type="checkbox" v-model="selectedUser.active" id="active" />
        <label for="active">Active</label>
      </div>
      <button @click="saveChanges" class="save-button">Save Changes</button>
    </div>    
  </div>

</template>

<script>
import { ref, reactive } from 'vue';

export default {
  setup() {
    const users = reactive([
      { id: 1, username: 'someuser1', active: true },
      { id: 2, username: 'someuser2', active: false },
      // ...
    ]);

    const showPanel = ref(false);
    const selectedUser = ref(null);
    const modifiedUsers = ref([]);
    const showUserPanel = (user) => {
      showPanel.value = true;
      selectedUser.value = user;
    };

    const saveChanges = () => {
      // один из следующих сценариев (на усмотрение кандидата)
      // 1. Обновление данных пользователя в базе данных
      // 2. Отправка запроса на сервер для обновления данных пользователя
      // 3. Вывод сообщения об успешном обновлении данных пользователя
      console.log('User profile updated');
      addModifiedUser(selectedUser.value);
      showPanel.value = false;
    };

    const addModifiedUser =(user) => {
      // ...
      modifiedUsers.value.push(user);
    };
    const saveModifiedUsers = () => {
      // ...
      modifiedUsers.value = [];
    }

    return {
      users,
      showPanel,
      selectedUser,
      showUserPanel,
      saveChanges,
      modifiedUsers,
      saveModifiedUsers
    };
  },
};
</script>

<style>
.user-panel {
  position: absolute;
  background-color: #fff;
  border: 1px solid #ddd;
  padding: 10px;
  width: 200px;
}
</style>

<style scoped>
.admin-page {
  max-width: 800px;
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

.users-table {
  width: 100%;
  border-collapse: collapse;
}

.users-table th {
  background-color: #f0f0f0;
  padding: 10px;
  border: 1px solid #ddd;
}

.users-table td {
  padding: 10px;
  border: 1px solid #ddd;
}

.user-row {
  cursor: pointer;
}

.username {
  font-weight: bold;
}

.status {
  color: #666;
}

.user-panel {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: #fff;
  padding: 20px;
  border: 1px solid #ddd;
  border-radius: 10px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.username-label {
  font-size: 18px;
  font-weight: bold;
  margin-bottom: 20px;
}

.status-checkbox {
  margin-bottom: 20px;
}
.status-checkbox > * {
  margin: 10px;
}

.save-button {
  background-color: #4CAF50;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.save-button:hover {
  background-color: #3e8e41;
}

.notification-panel {
  position: fixed;
  top: 0;
  right: 0;
  background-color: #f7f7f7;
  padding: 15px;
  border: 1px solid #ddd;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  width: 300px;
  z-index: 1000;
}

.notification-message {
  font-size: 16px;
  font-weight: bold;
  color: #333;
  margin-bottom: 10px;
}

.save-button {
  background-color: #4CAF50;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.save-button:hover {
  background-color: #3e8e41;
}
</style>