import { Component } from '@angular/core';
import { LoginService } from './login/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'drm-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private service: LoginService, private router: Router) {
        if (service.loginRequired) {
            router.navigate(["/login"]);
        }
    }
}
