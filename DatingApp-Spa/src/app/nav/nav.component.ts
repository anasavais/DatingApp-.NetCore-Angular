import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/Auth.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(private Auth: AuthService) { }

  ngOnInit() {
  }
  login() {
    this.Auth.login(this.model)
      .subscribe(next => {console.log('OK'); }, error => {console.log(error); } );
  }
  loggedin() {
    const token = localStorage.getItem('token');
    return !!token;
  }
  logout() {
    localStorage.removeItem('token');
    console.log('Logged Out');
  }

}
