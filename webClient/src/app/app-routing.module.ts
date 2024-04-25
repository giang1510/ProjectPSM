import { NgModule } from '@angular/core';
import { RouterModule, Routes, provideRouter, withComponentInputBinding } from '@angular/router';
import { HomeComponent } from './core/components/home/home.component';
import { LoginComponent } from './core/components/account/login/login.component';
import { RegisterComponent } from './core/components/account/register/register.component';
import { ProductDetailComponent } from './core/components/products/product-detail/product-detail.component';

// Path constants
export const APP_ROUTES = {
  LOGIN: 'login',
  REGISTER: 'register',
  PRODUCT_DETAIL: 'products/'
};

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: APP_ROUTES.LOGIN, component: LoginComponent},
  {path: APP_ROUTES.REGISTER, component: RegisterComponent},
  {path: APP_ROUTES.PRODUCT_DETAIL + ':productId', component: ProductDetailComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [provideRouter(routes, withComponentInputBinding())]
})
export class AppRoutingModule { }
