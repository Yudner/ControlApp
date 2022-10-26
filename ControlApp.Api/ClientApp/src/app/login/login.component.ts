import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
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
  ) { }

  ngOnInit() {
    
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
  console.log(response);
  if (response !== null && response.id !== 0){
    this.showSuccess();
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
