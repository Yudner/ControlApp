import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppComponent } from '../app.component';
import { UserService } from '../services/user.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userResponse: any;
  constructor(
    private toastr: ToastrService,
    public userService: UserService,
    private router: Router,
    private appComponent: AppComponent
  ) {
    this.appComponent.showNav = false;
   }

  ngOnInit() {
    this.appComponent.showNav = false;
  }

  onSubmit() {
    const code = (document.getElementById('code') as HTMLInputElement).value;
    if (code !== '') {
        this.userService.getByCode(code).subscribe(result => {
        this.userResponse = result;
        this.validateResponseAutentication(this.userResponse);
      }
      );
    } else {
      this.showErrorCode();
    }
}
validateResponseAutentication(response: any){
  if (response !== null && response.id !== 0){
    this.showSuccess();

    if(response.role === "Gerente de Agencia")
    {
      this.appComponent.gerente = true;
      this.appComponent.asesor = false;
      this.router.navigate(['/goald']);
    }
    else
    {
      this.appComponent.gerente = false;
      this.appComponent.asesor = true;
      this.router.navigate(['/sale']);
    }
    // console.log(response);
    localStorage.setItem('idUser', response.id);
    localStorage.setItem('code', response.code);
    localStorage.setItem('role', response.role);
    localStorage.setItem('name', response.name);
  }
  else {
    this.showError();
  }
}
showSuccess() {
  this.toastr.success('Autenticación correcta', '');
}
shoWarning() {
  this.toastr.warning('Usuario temporalmente suspendido', '');
}
showError() {
  this.toastr.error('Código incorrecto', '');
}
showErrorCode() {
  this.toastr.warning('Ingrese el código', '');
}
showErrorInternal() {
  this.toastr.info('Algo salió mal', 'Inténtalo en un momento');
}
}
