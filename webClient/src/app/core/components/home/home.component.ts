import { Component, OnInit } from '@angular/core';
import { MembersService } from '../../services/members.service';
import { Member } from 'src/app/model/member';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{
  members: Member[] | undefined;

  constructor(private membersService: MembersService){}
  ngOnInit(): void {
    this.getMembers();
  }

  // TODO this is just a test - Needs to be removed
  getMembers(){
    this.membersService.getMembers().subscribe({
      next: members => {
        this.members = members;
        console.log(members);
      },
      error: error => console.log(error)
    });
  }
}
