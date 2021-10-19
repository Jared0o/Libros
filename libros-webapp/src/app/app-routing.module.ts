import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BorrowComponent } from './borrow/borrow.component';
import { AuthGuard } from './helpers/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'logowanie', component: LoginComponent},
  {path: 'wypozyczenia', component: BorrowComponent, canActivate: [AuthGuard]},
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
