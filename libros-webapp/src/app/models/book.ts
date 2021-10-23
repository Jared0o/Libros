export interface Book {
    id: number,
    name: string,
    age: number,
    pages: number,
    isbn: string,
    author?: any,
    publisher?: any,
    authorId?: number,
    publisherId?: number
}