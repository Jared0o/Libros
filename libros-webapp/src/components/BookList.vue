<template>
<h1>Książki</h1>
<ul>
    <div v-for="book in books" :key="book.id">
        <router-link :to="{path: '/book/'+ book.id} ">{{book.name}}</router-link>
    </div>
</ul>
</template>

<script>
import BookService from '@/services/book.service';

export default {
    data() {
        return {
            books: []
        }
    },

    methods: {
        getBooks() {
            BookService.getBooks.then(res => {
                books = res.data;
            })
        }
    },

    mounted() {
        BookService.getBooks().then(res => {
            this.books = res;
        })        
    }
}


</script>

<style>

</style>