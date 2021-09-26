<template>
    <form class="form" @submit.prevent="handlerRegister">
        <input class="input" v-model="email" type="email" placeholder="Email" />
        <input class="input" v-model="firstName" type="text" placeholder="Imię" />
        <input class="input" v-model="lastName" type="text" placeholder="Nazwisko" />
        <input class="input" v-model="password" type="password" placeholder="Hasło" />
        <button class="btn">Login</button>
  </form>
</template>

<script>
export default {
    name: "Register",

    data() {
    return {
        loading: false,
        message: "",
        firstName: "",
        lastName: "",
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
      handlerRegister() {
          const user = {email: this.email, firstName: this.firstName, lastName: this.lastName, password: this.password};

          this.$store.dispatch("auth/register", user).then(
              ()=> {
                  this.$router.push("/")
              },
              (error) => {
                  this.message = (error.response &&
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