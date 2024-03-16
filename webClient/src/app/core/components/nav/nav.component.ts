import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountService } from '../../services/account.service';
import { FormsModule } from '@angular/forms';
import { LoginUser } from '../../models/loginUser';
import { APP_ROUTES, AppRoutingModule } from 'src/app/app-routing.module';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router } from '@angular/router';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

/**
 * Navigation bar (always present)
 */
@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    AppRoutingModule,
    BsDropdownModule,
    FontAwesomeModule
  ],
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent {
  faUser = faUser;

  constructor(public accountService: AccountService, private router: Router){}

  // TODO implement this, redirect to last page
  login(): void{
    this.router.navigateByUrl(APP_ROUTES.LOGIN);
  }

  /**
   * Execute logout via service
   */
  // TODO redirect to home page
  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  reloadPage(){
    window.location.reload();
  }
}
