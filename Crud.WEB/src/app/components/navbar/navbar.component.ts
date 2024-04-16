import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'navbar',
  standalone: true,
  imports: [NgIf],
  templateUrl: './navbar.component.html'
})
export class NavbarComponent {
  constructor(private authService: AuthService, private auth: AuthService) { }

  logout(): void {
    this.authService.logout();
  }

  isActive() {
    return this.auth.isLoggedIn();
  }
}
