import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginUser } from 'src/app/core/models/loginUser';
import { AccountService } from 'src/app/core/services/account.service';
import { Router } from '@angular/router';
import { APP_ROUTES } from 'src/app/app-routing.module';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { TextInputComponent } from '../../forms/text-input/text-input.component';

/**
 * Login page
 */
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, TextInputComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  loginUser: LoginUser | undefined;
  loginForm: FormGroup = new FormGroup({});
  
  constructor(private accountService: AccountService, private router: Router,
    private formBuilder: FormBuilder){}

  ngOnInit(): void {
    this.initializeForm();
  }

  login(): void{
    this.loginUser = this.loginForm.value;
    if(!this.loginUser) return;
    this.accountService.login(this.loginUser).subscribe({
      next: _ => {
        this.router.navigateByUrl('/');
      },
      error: error => console.log(error)
    })
  }

  initializeForm(){
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
}
