import { Component, OnInit } from '@angular/core';
import { AccountService } from './core/services/account.service';
import { User } from './core/models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit{
  title = 'Welcome to PSM';

  constructor(private accountService: AccountService){}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const userString = localStorage.getItem(AccountService.USER_LOCAL_STORAGE_KEY);
    if(!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
