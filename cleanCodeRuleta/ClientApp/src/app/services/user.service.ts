import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  urlBase: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;
  }
  public saveData(UserClass){
    return this.http.post(this.urlBase + 'usuario/save-data', UserClass);
  }
}
