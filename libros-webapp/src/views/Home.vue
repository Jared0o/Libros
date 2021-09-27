<template>
<section>
  <BookList v-if="loggedIn"/>
</section>
</template>

<script>
// @ is an alias to /src
import BookList from  '@/components/BookList.vue';

export default {
  name: 'Home',
  components: {
    BookList,
  },

  computed: {
    loggedIn() {
      return this.$store.state.auth.status.loggedIn;
    },
}
}
</script>
