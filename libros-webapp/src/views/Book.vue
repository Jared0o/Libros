<template>
<div>{{book.name}}</div>
<div>{{book.isbn}}</div>
<div>{{book.pages}}</div>
<div>{{book.author.id}}</div>


  
</template>

<script>
import BookService from '@/services/book.service';
export default {
data() {
    return {
        book: null
    }
},
mounted() {
    const id = this.$route.params.id;
    BookService.getBook(id).then(res=> this.book = res);
    console.log(this.book);
}
}
</script>

<style>

</style>