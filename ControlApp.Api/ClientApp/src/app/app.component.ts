import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit{
  title = 'app';
  public showNav = true;
  public gerente = false;
  public asesor = false;

constructor(private router: Router) {
  
  
}
ngOnInit() {
}
  hideNav(item: any) {
    this.router.navigate(item);
  }
}
