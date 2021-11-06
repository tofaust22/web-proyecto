import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isMenuExpanded = false;
  @Output() eventoMenu = new EventEmitter<boolean>();

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  eventMenu(){
    this.isMenuExpanded = !this.isMenuExpanded;
    this.eventoMenu.emit(this.isMenuExpanded);
  }

}
