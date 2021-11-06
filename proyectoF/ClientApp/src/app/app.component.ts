import { Component, ViewChild } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { Usuario } from './models/usuario';
import { LoginService } from './services/login.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
    title = 'app';
    @ViewChild('drawer', { static: true }) public drawer!: MatDrawer;
    login: boolean = false;
    usuario: Usuario;
    constructor(private authenticationService: LoginService){
      this.usuario = new Usuario();
      let currentUser = this.authenticationService.currentUserValue;
      if(currentUser){
        this.login = true;
        this.usuario = currentUser;
      }
    }
    
    
}
