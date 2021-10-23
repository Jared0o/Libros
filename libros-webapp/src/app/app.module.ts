import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { authInterceptorProviders } from './helpers/auth.interceptor';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { NavigationComponent } from './navigation/navigation.component';
import { BorrowComponent } from './borrow/borrow.component';
import { BorrowListComponent } from './borrow/borrow-list/borrow-list.component';
import { httpErrorInterceptorProviders } from './helpers/http-error.interceptor';
import { BorrowMenuComponent } from './borrow/borrow-menu/borrow-menu.component';
import { BorrowBookComponent } from './borrow/borrow-book/borrow-book.component';
import { BorrowArchiveComponent } from './borrow/borrow-archive/borrow-archive.component';
import { BorrowExpiredComponent } from './borrow/borrow-expired/borrow-expired.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { SearchUserComponent } from './borrow/search-user/search-user.component';
import { ArchiveListComponent } from './borrow/archive-list/archive-list.component';
import { BookComponent } from './book/book.component';
import { BookMenuComponent } from './book/book-menu/book-menu.component';
import { BookAddComponent } from './book/book-add/book-add.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { BookEditComponent } from './book/book-edit/book-edit.component';
import { AddAutorComponent } from './book/add-autor/add-autor.component';
import { AddPublisherComponent } from './book/add-publisher/add-publisher.component';
import { SearchAuthorComponent } from './book/search-author/search-author.component';
import { SearchPublisherComponent } from './book/search-publisher/search-publisher.component';
import { ManagmentComponent } from './managment/managment.component';
import { AddUserComponent } from './managment/add-user/add-user.component';
import { ManagmentNavComponent } from './managment/managment-nav/managment-nav.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    NavigationComponent,
    BorrowComponent,
    BorrowListComponent,
    BorrowMenuComponent,
    BorrowBookComponent,
    BorrowArchiveComponent,
    BorrowExpiredComponent,
    SearchUserComponent,
    ArchiveListComponent,
    BookComponent,
    BookMenuComponent,
    BookAddComponent,
    BookListComponent,
    BookEditComponent,
    AddAutorComponent,
    AddPublisherComponent,
    SearchAuthorComponent,
    SearchPublisherComponent,
    ManagmentComponent,
    AddUserComponent,
    ManagmentNavComponent,
  ],
  entryComponents: [
    SearchUserComponent,
    SearchAuthorComponent,
    SearchPublisherComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,  
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [authInterceptorProviders, httpErrorInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
