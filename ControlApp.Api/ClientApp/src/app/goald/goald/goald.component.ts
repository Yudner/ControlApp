import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AppComponent } from 'src/app/app.component';
import { GoaldService } from 'src/app/services/goald.service';
import { PeriodService } from 'src/app/services/period.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-goald',
  templateUrl: './goald.component.html',
  styleUrls: ['./goald.component.css']
})
export class GoaldComponent implements OnInit {
  goaldList: any;
  userList: any;
  periodList: any;
  goaldModel: any;
  constructor(
    public appComponent: AppComponent,
    private goaldService: GoaldService,
    private userService: UserService,
    private periodService: PeriodService,
    private toastr: ToastrService,

    ) { }

  ngOnInit() {
    this.appComponent.showNav = true;
    this.InitializeModels();
    this.InitializeLisGoald();
    this.InitializeUser();
    this.InitializePeriod();
    
    // console.log(localStorage.getItem('idUser'));
    // console.log(localStorage.getItem('code'));
    // console.log(localStorage.getItem('role'));
    // console.log(localStorage.getItem('name'));
  }
  InitializeModels() {
    this.goaldModel = {
      Id: 0,
      UserId: 0,
      PeriodId: 0,
      Points: 0,
    };
  }
  InitializeUser() {
    this.userService.getByRole("Asesor Comercial").subscribe((result) => {
      this.userList = result;
    });    
  }
  InitializePeriod() {
    this.periodService.getAll().subscribe((result) => {
      this.periodList = result;
    });    
  }
  InitializeLisGoald() {
    this.goaldService.getAll().subscribe((result) => {
      this.goaldList = result;
    });
  }
  loadUser(ctrl: any) {
    if (ctrl.selectedIndex > 0) {
      this.goaldModel.UserId = this.userList[ctrl.selectedIndex - 1].id;
      }
  }
  loadPeriod(ctrl: any) {
    if (ctrl.selectedIndex > 0) {
      this.goaldModel.PeriodId = this.periodList[ctrl.selectedIndex - 1].id;
      }
  }
  onSubmit(formValue: any) {

    
}
Clear() {
  this.InitializeModels();

  (document.getElementById('point') as HTMLSelectElement).value = '';
  (document.getElementById('idUser') as HTMLSelectElement).selectedIndex = 0;
  (document.getElementById('idPeriod') as HTMLSelectElement).selectedIndex = 0;
  this.goaldModel.UserId = 0;
  this.goaldModel.PeriodId = 0;
}
SaveGoald() {
  this.goaldModel.Points = (document.getElementById('point') as HTMLSelectElement).value;
  if(this.ValidateData(this.goaldModel)){
    this.goaldService.create(this.goaldModel).subscribe(result => {
      if(result === 200){
        this.Clear();
        this.showSuccess();
        this.InitializeLisGoald();
      }else{
        this.showErrorInternal();
      }
      
    });
  }else{
    this.showErrorField();
  }  
}
ValidateData(model: any){
  if (model.UserId === 0 || model.PeriodId === 0 || model.Points === '' ) {
  return false;
} else {
return true;
}
}
showSuccess() {
  this.toastr.success('Se guardó correctamente', '');
}

showErrorInternal() {
  this.toastr.info('Algo salió mal', 'Inténtalo en un momento');
}

showErrorField() {
  this.toastr.info('Ingrese todos los campos', '');
}
}
