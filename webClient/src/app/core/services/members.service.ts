import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  // TODO this method should return a defined data type instead of any
  getMembers(){
    return this.http.get<any>(this.baseUrl + 'users');
  }
}
