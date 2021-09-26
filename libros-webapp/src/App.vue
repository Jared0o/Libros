<template>
  <div id="nav">
    <router-link to="/">Home</router-link> || 
    <router-link v-if="!loggedIn" to="/login">Login</router-link>
    <router-link @click="handlerLogout" v-if="loggedIn" to="/">Logout</router-link>
  </div>
  <router-view/>
</template>

<script>

export default {
  computed: {
    loggedIn() {
      return this.$store.state.auth.status.loggedIn;
    },
    getUser() {
      return this.$store.state.auth.user;
    }
  },

  created() {
    const token = localStorage.getItem('token');
    if(token){
      this.$store.commit("auth/checkLogin", token);
    }else{
      this.$store.commit('auth/loginFailure');
    }
  },

  methods: {
    handlerLogout(){
      this.$store.dispatch("auth/logout").then(
        () => {this.$router.push('/login');}
      );
    },
  }
}

</script>


<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

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
