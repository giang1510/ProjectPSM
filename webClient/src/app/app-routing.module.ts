import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/components/home/home.component';
import { LoginComponent } from './core/components/account/login/login.component';
import { RegisterComponent } from './core/components/account/register/register.component';

// Path constants
export const APP_ROUTES = {
  LOGIN: 'login',
  REGISTER: 'register'
};

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: APP_ROUTES.LOGIN, component: LoginComponent},
  {path: APP_ROUTES.REGISTER, component: RegisterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
