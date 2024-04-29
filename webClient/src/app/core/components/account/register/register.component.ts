import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from 'src/app/core/services/account.service';
import { Router } from '@angular/router';
import { TextInputComponent } from '../../forms/text-input/text-input.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { DatePickerComponent } from '../../forms/date-picker/date-picker.component';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, TextInputComponent, BsDatepickerModule, DatePickerComponent],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit{
  private readonly PASSWORD_MINLENGTH = 8;
  private readonly PASSWORD_MAXLENGTH = 128;
  private readonly USERNAME_MINLENGTH = 4;
  private readonly USERNAME_MAXLENGTH = 128;

  registerForm: FormGroup = new FormGroup({});
  maxDateOfBirth: Date = new Date();
  validationErrors: string[] | undefined;

  constructor(private accountService: AccountService, private formBuilder: FormBuilder,
    private router: Router){}

  ngOnInit(): void {
    this.initializeForm();
    this.maxDateOfBirth.setFullYear(this.maxDateOfBirth.getFullYear() - 18);
  }

  initializeForm(){
    this.registerForm = this.formBuilder.group({
      username: [
        '',
        [
          Validators.required, Validators.minLength(this.USERNAME_MINLENGTH),
          Validators.maxLength(this.USERNAME_MAXLENGTH)
        ]
      ],
      dateOfBirth: ['', Validators.required],
      password: [
        '',
        [
          Validators.required, Validators.minLength(this.PASSWORD_MINLENGTH),
          Validators.maxLength(this.PASSWORD_MAXLENGTH)
        ]
      ],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]],
      emailAddress: ['', [Validators.required, Validators.email]],
      confirmEmailAddress: ['', [Validators.required, this.matchValues('emailAddress')]],
    });
    this.subscribeToControlValueChanges('password', 'confirmPassword');
    this.subscribeToControlValueChanges('emailAddress', 'confirmEmailAddress');
  }

  matchValues(matchTo: string): ValidatorFn{
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {noMatching: true};
    };
  }

  subscribeToControlValueChanges(publisherControl: string, subscriberControl: string): void{
    if(!publisherControl || !subscriberControl
      || publisherControl.length < 1 || subscriberControl.length < 1) return;
    this.registerForm.controls[publisherControl].valueChanges.subscribe({
      next: () => this.registerForm.controls[subscriberControl].updateValueAndValidity()
    });
  }

  register(): void{
    const dob = this.getDateOnly(this.registerForm.controls['dateOfBirth'].value);
    const values = {...this.registerForm.value, dateOfBirth: dob};
    this.accountService.register(values).subscribe({
      next: () => {
        this.router.navigateByUrl('/');
      },
      error: error => {
        this.validationErrors = error;
      }
    });
  }

  private getDateOnly(dob: string | undefined){
    if(!dob) return;
    let theDob = new Date(dob);
    return new Date(theDob.setMinutes(theDob.getMinutes() - theDob.getTimezoneOffset()))
      .toISOString().slice(0, 10);
  }
}
