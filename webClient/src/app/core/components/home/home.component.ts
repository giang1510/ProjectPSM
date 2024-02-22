import { Component, OnInit } from '@angular/core';
import { MembersService } from '../../services/members.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{
  users: any;

  constructor(private membersService: MembersService){}
  ngOnInit(): void {
    this.getUsers();
  }

  // TODO this is just a test - Needs to be removed
  getUsers(){
    this.membersService.getUsers().subscribe({
      next: users => {
        this.users = users;
        console.log(users);
      },
      error: error => console.log(error)
    });
  }
}
