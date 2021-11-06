import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Usuario } from '../models/usuario';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: Usuario;
  constructor(private serviceLogin: LoginService) { }

  ngOnInit(): void {
    this.user = new Usuario();
  }

  login(){
    this.serviceLogin.login(this.user.password, this.user.usuario)
      .pipe(first())
      .subscribe(
        data => {
          window.location.reload();
        },
        error => {
          console.log(error.error);
        }
      )
  }

}
