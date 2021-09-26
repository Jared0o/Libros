import AuthService from '../services/auth.service';
import jwtDecode from 'jwt-decode';

const user = JSON.parse(localStorage.getItem('user'));

const initialState = user
  ? { status: { loggedIn: true }, user, token: user.token }
  : { status: { loggedIn: false }, user: null, token: null };

  export const auth = {
    namespaced: true,
    state: initialState,
    actions: {
        login({ commit }, user) {
          return AuthService.login(user).then(
            user => {
              commit('loginSuccess', user);
              return Promise.resolve(user);
            },
            error => {
              commit('loginFailure');
              return Promise.reject(error);
            }
          );
        },

        logout({commit}){
          AuthService.logout();
          commit("logoutSuccess");
        },
    },
    mutations: {
        loginSuccess(state, user) {
          state.status.loggedIn = true;
          state.user = jwtDecode(user.token)
          state.token = user.token
        },
        loginFailure(state) {
          state.status.loggedIn = false;
          state.user = null;
          state.token = null;
        },

        checkLogin(state, token){
          state.status.loggedIn = true;
          state.user = jwtDecode(token)
          state.token = token
        },

        logoutSuccess(state){
          state.status.loggedIn = false;
          state.user = null;
          state.token = null 
        }
    }
};