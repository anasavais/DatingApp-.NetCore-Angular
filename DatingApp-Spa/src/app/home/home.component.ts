import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  values: any;
  RegisterMode = false;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.GetValues();
  }
RegisterToggle() {
this.RegisterMode = true;
// this.RegisterMode = !this.RegisterMode;
}

GetValues() {
  this.http.get('http://localhost:5000/api/values').subscribe( response => { this.values = response; }, error => { console.log(error); });
}

CancelRegisterMode(RegisterMode: boolean) {
this.RegisterMode = RegisterMode;
}
}
