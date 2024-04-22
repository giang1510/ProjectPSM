import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { LoginUser } from '../models/loginUser';
import { RegisterUser } from '../models/registerUser';
import { APP_ROUTES } from 'src/app/app-routing.module';

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
    return this.http.post<User>(this.baseUrl + 'login', loginUser).pipe(
      map((user: User) => {
        if(user){
          this.setCurrentUser(user);
        }
      })
    );
  }

  /**
   * Remove user data from storage
   */
  logout(){
    localStorage.removeItem(AccountService.USER_LOCAL_STORAGE_KEY);
    this.currentUserSource.next(null);
  }

  setCurrentUser(user: User){
    localStorage.setItem(AccountService.USER_LOCAL_STORAGE_KEY, JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  register(registerUser: RegisterUser){
    console.log(registerUser);
    return this.http.post<User>(this.baseUrl + APP_ROUTES.REGISTER, registerUser).pipe(
      map(user => {
        if(user){
          this.setCurrentUser(user);
        }
      })
    );
  }
}
