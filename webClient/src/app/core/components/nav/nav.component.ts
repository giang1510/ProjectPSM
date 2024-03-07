import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountService } from '../../services/account.service';
import { FormsModule } from '@angular/forms';
import { LoginUser } from '../../models/loginUser';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    AppRoutingModule,
    BsDropdownModule
  ],
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent {
  loginUser: LoginUser = {
    username: '',
    password: ''
  };

  constructor(public accountService: AccountService){}

  // TODO implement this, redirect to last page
  login(): void{
    this.accountService.login(this.loginUser).subscribe({
      next: _ => {
        console.log('Login finished');
      },
      error: error => console.log(error)
    })
  }

  /**
   * Execute logout via service
   */
  // TODO redirect to home page
  logout(){
    this.accountService.logout();
  }
}
