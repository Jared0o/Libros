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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,  
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [authInterceptorProviders, httpErrorInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
