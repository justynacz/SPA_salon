import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private toastr: ToastrService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.authenticationService.logout();

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit() {
    this.authenticationService.login(this.loginForm.value.username, this.loginForm.value.password)
    .then(
      () => this.router.navigate([this.returnUrl])
    )
    .catch(
      error => this.toastr.error('Nie udało się zalogować')
    );
  }
}
