import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

@Injectable({
  providedIn: 'root'
})
export class SaleService {

  constructor(private http: HttpClient) { }
  create(model: any): Observable<any> {
    return this.http.post(environment.apiURL + '/api/v1/sale/create', model);
  }
  getByUserId(userId: any){
    return this.http.get(environment.apiURL + '/api/v1/sale/getByUserId/' + userId);
  }
  getTracing(userId: any, periodId: any){
    return this.http.get(environment.apiURL + '/api/v1/sale/getTracing/' + userId + "/" + periodId);
  }
}
