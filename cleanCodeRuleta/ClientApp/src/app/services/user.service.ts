import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  public userRegisterEmail(UserClass) {
    return this.http.post(this.urlBase + 'user/register-email', UserClass);
  }
}
