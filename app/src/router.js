import WelcomePage from './pages/welcome/welcomePage';
import UsersPage from './pages/users/usersPage.vue';
import LoginPage from './pages/login/loginPage';
import { createMemoryHistory, createRouter } from 'vue-router'

import store from './store';

const routes = [
      {
        path: '/welcome',
        name: 'welcome',
        component: WelcomePage,
        meta: {
          requiresAuth: true,
          requiresActive: true,
        },
      },
      {
        path: '/login',
        name: 'login',
        component: LoginPage,
      },
      {
        path: '/users',
        name: 'users',
        component: UsersPage,
        meta: {
          requiresAuth: false,
          requiresActive: false,
        },
      },
      {
        path: '/',
        redirect: '/welcome',
      },
    ];

  const router = createRouter({
    history: createMemoryHistory(),
    routes,
  })

  router.beforeEach((to, from, next) => {
    if (to.meta.requiresAuth && !store.state.auth.isAuthenticated) {
      next({ name: 'login' });
    } else if (to.meta.requiresActive && !store.state.auth.isActive) {
      next({ name: 'login' });
    } else if (to.meta.requiresAuth && store.state.auth.isAuthenticated && store.state.auth.isActive && to.name !== 'welcome') {
      next({ name: 'welcome' });
    } else {
      next();
    }
  });

export default router;