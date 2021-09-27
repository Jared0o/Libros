<template>
<h1>Książki</h1>
<ul>
    <li v-for="book in books" :key="book.id">
        <p>Id: {{book.id}}</p>
        <p>Tytuł książki: {{book.author.firstName + " " +book.author.lastName}}</p>
        <p>Autor: {{book.author.name}}</p>
        <p>Isbn: {{book.isbn}}</p>
        <p>Wydawnictwo: {{book.publisher.name}}</p>
    </li>
</ul>
</template>

<script>
import axios from 'axios';
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