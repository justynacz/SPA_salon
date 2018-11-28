/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Role } from '../models/role';
import { NewRoleModel } from '../models/new-role-model';
@Injectable({
  providedIn: 'root',
})
class RolesService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of roles
   */
  GetRolesResponse(): Observable<StrictHttpResponse<Array<Role>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Roles`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<Role>>;
      })
    );
  }
  /**
   * @return Returns the list of roles
   */
  GetRoles(): Observable<Array<Role>> {
    return this.GetRolesResponse().pipe(
      __map(_r => _r.body as Array<Role>)
    );
  }

  /**
   * @param role New role model
   */
  CreateRoleResponse(role?: NewRoleModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = role;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Roles`,
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
   * @param role New role model
   */
  CreateRole(role?: NewRoleModel): Observable<null> {
    return this.CreateRoleResponse(role).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Role id
   */
  GetRoleResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Roles/${id}`,
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
   * @param id Role id
   */
  GetRole(id: number): Observable<null> {
    return this.GetRoleResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `RolesService.UpdateRoleParams` containing the following parameters:
   *
   * - `id`: Role id
   *
   * - `role`: Role entity
   */
  UpdateRoleResponse(params: RolesService.UpdateRoleParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.role;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Roles/${params.id}`,
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
   * @param params The `RolesService.UpdateRoleParams` containing the following parameters:
   *
   * - `id`: Role id
   *
   * - `role`: Role entity
   */
  UpdateRole(params: RolesService.UpdateRoleParams): Observable<null> {
    return this.UpdateRoleResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Role to delete id
   */
  DeleteRoleResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Roles/${id}`,
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
   * @param id Role to delete id
   */
  DeleteRole(id: number): Observable<null> {
    return this.DeleteRoleResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module RolesService {

  /**
   * Parameters for UpdateRole
   */
  export interface UpdateRoleParams {

    /**
     * Role id
     */
    id: number;

    /**
     * Role entity
     */
    role?: Role;
  }
}

export { RolesService }
