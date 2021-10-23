import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAutorComponent } from './book/add-autor/add-autor.component';
import { AddPublisherComponent } from './book/add-publisher/add-publisher.component';
import { BookAddComponent } from './book/book-add/book-add.component';
import { BookEditComponent } from './book/book-edit/book-edit.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { BookComponent } from './book/book.component';
import { ArchiveListComponent } from './borrow/archive-list/archive-list.component';
import { BorrowBookComponent } from './borrow/borrow-book/borrow-book.component';
import { BorrowExpiredComponent } from './borrow/borrow-expired/borrow-expired.component';
import { BorrowListComponent } from './borrow/borrow-list/borrow-list.component';
import { BorrowComponent } from './borrow/borrow.component';
import { AuthGuard } from './helpers/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AddUserComponent } from './managment/add-user/add-user.component';
import { ManagmentComponent } from './managment/managment.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'logowanie', component: LoginComponent},
  {path: 'wypozyczenia', component: BorrowComponent, canActivate: [AuthGuard], children: [
    {path: 'lista', component: BorrowListComponent},
    {path: 'wypozycz', component: BorrowBookComponent},
    {path: 'archiwum', component: ArchiveListComponent},
    {path: 'przeterminowane', component:BorrowExpiredComponent}
  ]},
  {path: 'ksiazki', component: BookComponent, canActivate: [AuthGuard], children: [
    {path: 'dodaj', component: BookAddComponent},
    {path: 'lista', component: BookListComponent},
    {path: 'autor', component: AddAutorComponent},
    {path: 'lista/:id', component: BookEditComponent},
    {path: 'wydawnictwo', component: AddPublisherComponent}
  ]},
  {path: 'zarzadzanie', component: ManagmentComponent, canActivate: [AuthGuard], children: [
    {path: 'dodaj-uzytkownika', component: AddUserComponent}
  ]},
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
