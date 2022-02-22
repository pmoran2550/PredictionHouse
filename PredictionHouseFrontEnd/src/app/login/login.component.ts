import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MyAuthService } from '../services/auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  public loginInValid!: boolean;
  private formSubmitAttempt!: boolean;
  private returnUrl!: string;

  constructor(private fb: FormBuilder, 
    private route: ActivatedRoute, 
    private router: Router, 
    private auth: MyAuthService
    ) { }

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/game';
    this.form = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });

  }

  async onSubmit() {
    this.loginInValid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const email = this.form.get('email')!.value;
        const password = this.form.get('password')!.value;
        // this.auth.login(email, password)
        //   .subscribe(() => {
        //     console.log("user has logged in");
        //     this.router.navigateByUrl('/');
        //   });

      } catch (err) {
        this.loginInValid = true;
      }
    } else {
      this.formSubmitAttempt = true;
    }
  }
}
