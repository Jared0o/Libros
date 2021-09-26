<template>
  <div id="nav">
    <router-link to="/">Home</router-link> ||
    <router-link v-if="!loggedIn" to="/login">Logowanie</router-link> ||
    <router-link v-if="!loggedIn" to="/register">Rejestracja</router-link>
    <router-link @click="handlerLogout" v-if="loggedIn" to="/">Wyloguj</router-link
    >
  </div>
</template>

<script>
export default {
  name: "Navigation",

  computed: {
    loggedIn() {
      return this.$store.state.auth.status.loggedIn;
    },
    getUser() {
      return this.$store.state.auth.user;
    },
  },

  created() {
    const token = localStorage.getItem("token");
    if (token) {
      this.$store.commit("auth/checkLogin", token);
    } else {
      this.$store.commit("auth/loginFailure");
    }
  },

  methods: {
    handlerLogout() {
      this.$store.dispatch("auth/logout").then(() => {
        this.$router.push("/login");
      });
    },
  },
};
</script>

<style lang="scss">
#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>