import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { PeriodService } from 'src/app/services/period.service';
import { SaleService } from 'src/app/services/sale.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-tracing',
  templateUrl: './tracing.component.html',
  styleUrls: ['./tracing.component.css']
})
export class TracingComponent implements OnInit {
  tracingdModel: any;
  tracingdData: any;
  userList: any;
  periodList: any;
  constructor(
    public appComponent: AppComponent,
    private userService: UserService,
    private periodService: PeriodService,
    private saleService: SaleService
  ) { }

  ngOnInit() {
    this.appComponent.showNav = true;
    this.InitializeModels();
    this.InitializeUser();
    this.InitializePeriod();
  }
  InitializeModels() {
    this.tracingdModel = {
      Id: 0,
      UserId: 0,
      PeriodId: 0
    };

    this.tracingdData = {
      Goald: 0,
      Point: 0,
      Sales: [] 
    }
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

  GetData() {
    if(this.tracingdModel.UserId !== 0 && this.tracingdModel.PeriodId !== 0){
      
      this.saleService.getTracing(this.tracingdModel.UserId, this.tracingdModel.PeriodId).subscribe((result) => {
        this.tracingdData = result;
        console.log(this.tracingdData);
      });
    }
     
  }

  loadUser(ctrl: any) {
    if (ctrl.selectedIndex > 0) {
      this.tracingdModel.UserId = this.userList[ctrl.selectedIndex - 1].id;
      }
  }
  loadPeriod(ctrl: any) {
    if (ctrl.selectedIndex > 0) {
      this.tracingdModel.PeriodId = this.periodList[ctrl.selectedIndex - 1].id;
      }
  }

}
