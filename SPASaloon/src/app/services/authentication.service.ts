import { Injectable } from '@angular/core';
import { LoginsService } from '../api/services';
import { AuthenticateModel } from '../api/models';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(
    private loginService: LoginsService) { }
  login(username: string, password: string) {
    let authenticationParam : AuthenticateModel;
    authenticationParam = { username: username, password: password};
    return this.loginService.Authenticate(authenticationParam).toPromise()
    .then(result => 
      {
        if (result)  
          localStorage.setItem('currentUser', JSON.stringify(result));
         
        return result;
      });
  }

  logout() {
    localStorage.removeItem('currentUser');
  }
}
