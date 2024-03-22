import { Component, OnInit } from '@angular/core';
import { MembersService } from '../../services/members.service';
import { Member } from 'src/app/core/models/member';
import { NgFor } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';
import { ProductListComponent } from '../products/product-list/product-list.component';


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
    standalone: true,
    imports: [NgFor, FontAwesomeModule, ProductListComponent]
})
export class HomeComponent implements OnInit{
  members: Member[] | undefined;
  // TODO remove test icon
  faCoffee = faCoffee;

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
