import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AppComponent } from 'src/app/app.component';
import { PeriodService } from 'src/app/services/period.service';
import { ProductService } from 'src/app/services/product.service';
import { SaleService } from 'src/app/services/sale.service';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.css']
})
export class SaleComponent implements OnInit {
  saleList: any;
  productList: any;
  periodList: any;
  saleModel: any;
  productTemp: any;
  userName: any;
  constructor(
    public appComponent: AppComponent,
    private saleService: SaleService,
    private productService: ProductService,
    private periodService: PeriodService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.appComponent.showNav = true;
    this.InitializeLisSale();
    this.InitializeLisProduct();
    this.InitializeModels();
    this.InitializeListPeriod();
    this.userName = localStorage.getItem('name')
  }
  InitializeModels() {
    this.saleModel = {
      Id: 0,
      Points: 0,
      Amount: 0,
      UserId: localStorage.getItem('idUser'),
      DocumentType: "",
      DocumentNumber: "",
      LastName: "",
      FirstName: "",
      PhoneNumber: "",
      ProductId: 0,
      PeriodId: 0
    };
    this.productTemp = {
      Id: 0,
      ProductName: "",
      Points: 0,
      Percentage: 0
    };
  }
  InitializeListPeriod() {
    this.periodService.getAll().subscribe((result) => {
      this.periodList = result;
    });    
  }
  InitializeLisSale() {
    const userId = localStorage.getItem('idUser');
    this.saleService.getByUserId(userId).subscribe((result) => {
      this.saleList = result;
    });
  }
  InitializeLisProduct() {
    this.productService.getAll().subscribe((result) => {
      this.productList = result;
    });
  }
  loadDocumentType() {
    const documentTypeValue = (document.getElementById('documentType') as HTMLSelectElement).value;
    if(documentTypeValue !== "0")
      this.saleModel.DocumentType = documentTypeValue;

  }
  loadProduct(ctrl: any) {
    if (ctrl.selectedIndex > 0) {
      this.saleModel.ProductId = this.productList[ctrl.selectedIndex - 1].id;
      const points = this.productList[ctrl.selectedIndex - 1].points;
      (document.getElementById('points') as HTMLSelectElement).value = points;

      this.productTemp.Id = this.productList[ctrl.selectedIndex - 1].id;
      this.productTemp.ProductName = this.productList[ctrl.selectedIndex - 1].productName;
      this.productTemp.Points = this.productList[ctrl.selectedIndex - 1].points;
      this.productTemp.Percentage = this.productList[ctrl.selectedIndex - 1].percentage;
      this.UpdatePoints();

      }
  }
  loadPeriod(ctrl: any) {
    if (ctrl.selectedIndex > 0) {
      this.saleModel.PeriodId = this.periodList[ctrl.selectedIndex - 1].id;
      }
  }
  Clear() {
    this.InitializeModels();
  
    (document.getElementById('documentType') as HTMLSelectElement).value = '0';
    (document.getElementById('documentNumber') as HTMLSelectElement).value = "";
    (document.getElementById('firstName') as HTMLSelectElement).value = "";
    (document.getElementById('lastName') as HTMLSelectElement).value = "";
    (document.getElementById('phoneNumber') as HTMLSelectElement).value = "";
    (document.getElementById('amount') as HTMLSelectElement).value = "";
    (document.getElementById('points') as HTMLSelectElement).value = "";
    (document.getElementById('idPeriod') as HTMLSelectElement).selectedIndex = 0;
    (document.getElementById('idProduct') as HTMLSelectElement).selectedIndex = 0;
    
  }

  SaveSale() {
    this.saleModel.DocumentType = (document.getElementById('documentType') as HTMLSelectElement).value;
    this.saleModel.DocumentNumber = (document.getElementById('documentNumber') as HTMLSelectElement).value;
    this.saleModel.FirstName = (document.getElementById('firstName') as HTMLSelectElement).value;
    this.saleModel.LastName = (document.getElementById('lastName') as HTMLSelectElement).value;
    this.saleModel.PhoneNumber = (document.getElementById('phoneNumber') as HTMLSelectElement).value;
    this.saleModel.Amount = (document.getElementById('amount') as HTMLSelectElement).value;
    this.saleModel.Points = (document.getElementById('points') as HTMLSelectElement).value;    
    
    if(this.ValidateData(this.saleModel)){
      this.saleService.create(this.saleModel).subscribe(result => {
        if(result === 200){
          this.InitializeLisSale();
          this.Clear();
          this.showSuccess();
        }else{
          this.showErrorInternal();
        }
        
      });
    }else{
      this.showErrorField();
    }  
  }
  UpdatePoints() {
    if(this.productTemp.Percentage > 0)
    {
      const amount = (document.getElementById('amount') as HTMLSelectElement).value;
      const valuePoints = Number(amount)  * this.productTemp.Percentage;
      (document.getElementById('points') as HTMLSelectElement).value = "" + valuePoints;
    }
  }
  ValidateData(model: any){
    console.log(model);
    if (model.UserId === 0 || model.PeriodId === 0 || model.ProductId === 0 
      || model.Points === '' || model.DocumentType === '' || model.DocumentNumber === '' 
      || model.FirstName === '' || model.LastName === '' || model.PhoneNumber === ''
      || model.Amount === '' || model.Points === '') {
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
