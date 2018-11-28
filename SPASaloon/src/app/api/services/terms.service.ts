/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Term } from '../models/term';
import { NewTermModel } from '../models/new-term-model';
@Injectable({
  providedIn: 'root',
})
class TermsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of terms
   */
  GetTermResponse(): Observable<StrictHttpResponse<Array<Term>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Terms`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<Term>>;
      })
    );
  }
  /**
   * @return Returns the list of terms
   */
  GetTerm(): Observable<Array<Term>> {
    return this.GetTermResponse().pipe(
      __map(_r => _r.body as Array<Term>)
    );
  }

  /**
   * @param term New term model
   */
  CreateTermResponse(term?: NewTermModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = term;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Terms`,
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
   * @param term New term model
   */
  CreateTerm(term?: NewTermModel): Observable<null> {
    return this.CreateTermResponse(term).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Term id
   */
  GetTerm_1Response(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Terms/${id}`,
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
   * @param id Term id
   */
  GetTerm_1(id: number): Observable<null> {
    return this.GetTerm_1Response(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `TermsService.UpdateTermParams` containing the following parameters:
   *
   * - `id`: Term id
   *
   * - `term`: Term entity
   */
  UpdateTermResponse(params: TermsService.UpdateTermParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.term;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Terms/${params.id}`,
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
   * @param params The `TermsService.UpdateTermParams` containing the following parameters:
   *
   * - `id`: Term id
   *
   * - `term`: Term entity
   */
  UpdateTerm(params: TermsService.UpdateTermParams): Observable<null> {
    return this.UpdateTermResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Term to delete id
   */
  DeleteTermResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Terms/${id}`,
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
   * @param id Term to delete id
   */
  DeleteTerm(id: number): Observable<null> {
    return this.DeleteTermResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module TermsService {

  /**
   * Parameters for UpdateTerm
   */
  export interface UpdateTermParams {

    /**
     * Term id
     */
    id: number;

    /**
     * Term entity
     */
    term?: Term;
  }
}

export { TermsService }
