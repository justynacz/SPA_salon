/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Login } from '../models/login';
import { NewLoginModel } from '../models/new-login-model';
import { ChangePasswordModel } from '../models/change-password-model';
@Injectable({
  providedIn: 'root',
})
class LoginsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of logins
   */
  GetLoginsResponse(): Observable<StrictHttpResponse<Array<Login>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Logins`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<Login>>;
      })
    );
  }
  /**
   * @return Returns the list of logins
   */
  GetLogins(): Observable<Array<Login>> {
    return this.GetLoginsResponse().pipe(
      __map(_r => _r.body as Array<Login>)
    );
  }

  /**
   * @param login New login model
   */
  CreateLoginResponse(login?: NewLoginModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = login;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Logins`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param login New login model
   */
  CreateLogin(login?: NewLoginModel): Observable<null> {
    return this.CreateLoginResponse(login).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Login id
   */
  GetLoginResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Logins/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param id Login id
   */
  GetLogin(id: number): Observable<null> {
    return this.GetLoginResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `LoginsService.ChangePasswordParams` containing the following parameters:
   *
   * - `id`: Client id
   *
   * - `changePasswordModel`: Change password model
   */
  ChangePasswordResponse(params: LoginsService.ChangePasswordParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.changePasswordModel;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Logins/${params.id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param params The `LoginsService.ChangePasswordParams` containing the following parameters:
   *
   * - `id`: Client id
   *
   * - `changePasswordModel`: Change password model
   */
  ChangePassword(params: LoginsService.ChangePasswordParams): Observable<null> {
    return this.ChangePasswordResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Login to delete id
   */
  DeleteLoginResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Logins/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param id Login to delete id
   */
  DeleteLogin(id: number): Observable<null> {
    return this.DeleteLoginResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module LoginsService {

  /**
   * Parameters for ChangePassword
   */
  export interface ChangePasswordParams {

    /**
     * Client id
     */
    id: number;

    /**
     * Change password model
     */
    changePasswordModel?: ChangePasswordModel;
  }
}

export { LoginsService }
