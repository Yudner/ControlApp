import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService{
  constructor(private http: HttpClient) { }
  getByCode(code: string){
    return this.http.get(environment.apiURL + '/api/v1/user/getByCode/' + code);
  }

  getAll(){
    return this.http.get(environment.apiURL + '/api/v1/user/getAll/');
  }
  getByRole(role: string){
    return this.http.get(environment.apiURL + '/api/v1/user/getByRole/' + role);
  }
}
