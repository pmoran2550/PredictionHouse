import { Component, OnInit } from '@angular/core';
import { MyAuthService } from '../services/auth-service.service';

@Component({
  selector: 'app-unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrls: ['./unauthorized.component.css']
})
export class UnauthorizedComponent implements OnInit {

  constructor(private authService: MyAuthService) { }

  ngOnInit(): void {
  }

  logout() {
    this.authService.logout();
  }
}
