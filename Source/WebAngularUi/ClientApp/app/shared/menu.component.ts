import { Component } from '@angular/core';
import { LoginService } from '../login/login.service';
import { Router } from '@angular/router';

@Component({
    selector: 'menu',
    templateUrl: 'menu.component.html'
})

export class MenuComponent {
    constructor(private service: LoginService, private router: Router) { }
    logout() {
        this.service.logout();

        this.router.navigate(["/login"]);
    }
}