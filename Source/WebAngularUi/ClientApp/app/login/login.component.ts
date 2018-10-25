import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { Router } from '@angular/router';

@Component({
    selector: "login",
    templateUrl: "login.component.html"
})

export class LoginComponent {

    constructor(private service: LoginService, private router: Router) { }

    errorMessage: string = "";
    public creds = {
        username: "",
        password: ""
    };

    onLogin() {
        this.service.login(this.creds)
            .subscribe(success => {
                if (success) {
                    this.router.navigate(["/"]);
                }
            }, err => this.errorMessage = "Failed to login")
    }
}