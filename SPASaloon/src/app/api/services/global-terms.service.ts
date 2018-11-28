/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GlobalTerm } from '../models/global-term';
import { NewGlobalTermModel } from '../models/new-global-term-model';
@Injectable({
  providedIn: 'root',
})
class GlobalTermsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of global terms
   */
  GetGlobalTermsResponse(): Observable<StrictHttpResponse<Array<GlobalTerm>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/GlobalTerms`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<GlobalTerm>>;
      })
    );
  }
  /**
   * @return Returns the list of global terms
   */
  GetGlobalTerms(): Observable<Array<GlobalTerm>> {
    return this.GetGlobalTermsResponse().pipe(
      __map(_r => _r.body as Array<GlobalTerm>)
    );
  }

  /**
   * @param globalTerm New global term model
   */
  CreateGlobalTermResponse(globalTerm?: NewGlobalTermModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = globalTerm;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/GlobalTerms`,
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
   * @param globalTerm New global term model
   */
  CreateGlobalTerm(globalTerm?: NewGlobalTermModel): Observable<null> {
    return this.CreateGlobalTermResponse(globalTerm).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Global term id
   */
  GetGlobalTermResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/GlobalTerms/${id}`,
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
   * @param id Global term id
   */
  GetGlobalTerm(id: number): Observable<null> {
    return this.GetGlobalTermResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `GlobalTermsService.UpdateGlobalTermParams` containing the following parameters:
   *
   * - `id`: Global term id
   *
   * - `globalTerm`: Global term entity
   */
  UpdateGlobalTermResponse(params: GlobalTermsService.UpdateGlobalTermParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.globalTerm;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/GlobalTerms/${params.id}`,
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
   * @param params The `GlobalTermsService.UpdateGlobalTermParams` containing the following parameters:
   *
   * - `id`: Global term id
   *
   * - `globalTerm`: Global term entity
   */
  UpdateGlobalTerm(params: GlobalTermsService.UpdateGlobalTermParams): Observable<null> {
    return this.UpdateGlobalTermResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Global term to delete id
   */
  DeleteGlobalTermResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/GlobalTerms/${id}`,
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
   * @param id Global term to delete id
   */
  DeleteGlobalTerm(id: number): Observable<null> {
    return this.DeleteGlobalTermResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module GlobalTermsService {

  /**
   * Parameters for UpdateGlobalTerm
   */
  export interface UpdateGlobalTermParams {

    /**
     * Global term id
     */
    id: number;

    /**
     * Global term entity
     */
    globalTerm?: GlobalTerm;
  }
}

export { GlobalTermsService }
