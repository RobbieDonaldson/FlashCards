import { Component, OnInit } from '@angular/core';
import { LoginRequest } from '../../../models/login-request.model';
import { AuthService } from '../../../services/authentication.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  private credentials: LoginRequest | undefined;
  loginForm: FormGroup;

  constructor(
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) {
      this.loginForm = this.fb.group({
        username: ['', [Validators.required]],
        password: ['', Validators.required]
      });
  }
  
  ngOnInit(): void {}

  onSubmit() {
    if (this.loginForm.valid) {
      
      this.credentials = this.buildParams(); 
      this.authService.login(this.credentials).subscribe(res => {
        this.authService.saveToken(res.toString());
        this.router.navigate(['/webadmin']);
      },
      err => {
       
      })
    }
   }

  buildParams(){
    return {
      'userName': this.loginForm.value.username,
      'password': this.loginForm.value.password
    }
  }
}