import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/components/home/home.component';
import { LoginComponent } from './core/components/account/login/login.component';

// Path constants
export const APP_ROUTES = {
  LOGIN: 'login'
};

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: APP_ROUTES.LOGIN, component: LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
