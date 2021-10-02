<template>
  <div class="w-full max-w-xs">
  <form class="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
    <div class="mb-4">
      <label class="block text-gray-700 text-sm font-bold mb-2" for="username">
        Email
      </label>
      <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="username" type="text" placeholder="Username">
    </div>
    <div class="mb-6">
      <label class="block text-gray-700 text-sm font-bold mb-2" for="password">
        Hasło
      </label>
      <input class="shadow appearance-none border border-red-500 rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline" id="password" type="password" placeholder="******************">
      <p class="text-red-500 text-xs italic">Please choose a password.</p>
    </div>
    <div class="flex items-center justify-between">
      <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="button">
        Zaloguj
      </button>
      <a class="inline-block align-baseline font-bold text-sm text-blue-500 hover:text-blue-800" href="#">
        Przypomnij hasło
      </a>
    </div>
  </form>
</div>
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