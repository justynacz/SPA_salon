/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Client } from '../models/client';
import { NewClientModel } from '../models/new-client-model';
@Injectable({
  providedIn: 'root',
})
class ClientsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of clients
   */
  GetClientResponse(): Observable<StrictHttpResponse<Array<Client>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Clients`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<Client>>;
      })
    );
  }
  /**
   * @return Returns the list of clients
   */
  GetClient(): Observable<Array<Client>> {
    return this.GetClientResponse().pipe(
      __map(_r => _r.body as Array<Client>)
    );
  }

  /**
   * @param client New client model
   */
  CreateClientResponse(client?: NewClientModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = client;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Clients`,
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
   * @param client New client model
   */
  CreateClient(client?: NewClientModel): Observable<null> {
    return this.CreateClientResponse(client).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Client id
   */
  GetClient_1Response(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Clients/${id}`,
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
   * @param id Client id
   */
  GetClient_1(id: number): Observable<null> {
    return this.GetClient_1Response(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `ClientsService.UpdateClientParams` containing the following parameters:
   *
   * - `id`: Client id
   *
   * - `client`: Client entity
   */
  UpdateClientResponse(params: ClientsService.UpdateClientParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.client;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Clients/${params.id}`,
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
   * @param params The `ClientsService.UpdateClientParams` containing the following parameters:
   *
   * - `id`: Client id
   *
   * - `client`: Client entity
   */
  UpdateClient(params: ClientsService.UpdateClientParams): Observable<null> {
    return this.UpdateClientResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Client to delete id
   */
  DeleteClientResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Clients/${id}`,
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
   * @param id Client to delete id
   */
  DeleteClient(id: number): Observable<null> {
    return this.DeleteClientResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module ClientsService {

  /**
   * Parameters for UpdateClient
   */
  export interface UpdateClientParams {

    /**
     * Client id
     */
    id: number;

    /**
     * Client entity
     */
    client?: Client;
  }
}

export { ClientsService }
