<template>
  <form @submit.prevent="handleLogin">
    <input v-model="email" type="email" placeholder="email" />
    <input v-model="password" type="password" placeholder="password" />
    <button>Login</button>
  </form>

  <p>email: {{ email }}</p>
  <p>password: {{ password }}</p>
</template>

<script>
export default {
  data() {
    return {
        loading: false,
        message: "",
      email: "",
      password: "",
    };
  },
  computed: {
      loggedIn() {
          return this.$store.state.auth.status.loggedIn;
      },
  },
  created() {
      if(this.loggedIn){
          this.$router.push("/")
      }
  },
  methods: {
    handleLogin() {
      const user = { email: this.email, password: this.password };
      this.$store.dispatch("auth/login", user).then(
        () => {
          this.$router.push("/");
        },
        (error) => {
          this.message =
            (error.response &&
              error.response.data &&
              error.response.data.message) ||
            error.message ||
            error.toString();
        }
      );
    },
  },
};
</script>

<style>
</style>