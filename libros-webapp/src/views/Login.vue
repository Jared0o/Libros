<template>
  <form class="form" @submit.prevent="handleLogin">
    <input class="input" v-model="email" type="email" placeholder="email" />
    <input class="input" v-model="password" type="password" placeholder="password" />
    <button class="btn">Login</button>
  </form>
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
  .form {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

  }

  .input {
    margin: 5px;
    font-size: 16px;
  }

  .btn {
    font-size: 16px;
  }
</style>