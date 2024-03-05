import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { LoginUser } from '../models/loginUser';

/** 
 * Provide login/out and register features 
 * */
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  public static readonly USER_LOCAL_STORAGE_KEY = 'user';
  private readonly baseUrl = environment.apiUrl + 'account/';
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  /**
   * Make a http post request with login data
   */
  login(loginUser: LoginUser){
    console.log(this.baseUrl);
    return this.http.post<User>(this.baseUrl + 'login', loginUser).pipe(
      map((user: User) => {
        if(user){
          this.setCurrentUser(user);
        }
      })
    );
  }

  setCurrentUser(user: User){
    localStorage.setItem(AccountService.USER_LOCAL_STORAGE_KEY, JSON.stringify(user));
    this.currentUserSource.next(user);
  }
}
