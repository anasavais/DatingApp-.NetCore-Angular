import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/Auth.service';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any;
  @Output() CancelRegister = new EventEmitter();
model: any = {};
  constructor(private auth: AuthService) { }

  ngOnInit() {
  }

  Register() {
    this.auth.register(this.model).subscribe(() => {
      console.log('Successful Registration');
    },
     Error => {
       console.log(error);
      }
      );
    console.log(this.model);
    
  }

  Cancel() {
   this.CancelRegister.emit(false);
    console.log(this.model);
  }



}
