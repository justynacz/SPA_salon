/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Person } from '../models/person';
import { NewPersonModel } from '../models/new-person-model';
@Injectable({
  providedIn: 'root',
})
class PeopleService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of people
   */
  GetPeopleResponse(): Observable<StrictHttpResponse<Array<Person>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/People`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<Person>>;
      })
    );
  }
  /**
   * @return Returns the list of people
   */
  GetPeople(): Observable<Array<Person>> {
    return this.GetPeopleResponse().pipe(
      __map(_r => _r.body as Array<Person>)
    );
  }

  /**
   * @param person New person model
   */
  CreatePersonResponse(person?: NewPersonModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = person;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/People`,
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
   * @param person New person model
   */
  CreatePerson(person?: NewPersonModel): Observable<null> {
    return this.CreatePersonResponse(person).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Person id
   */
  GetPersonResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/People/${id}`,
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
   * @param id Person id
   */
  GetPerson(id: number): Observable<null> {
    return this.GetPersonResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `PeopleService.UpdatePersonParams` containing the following parameters:
   *
   * - `id`: Offer id
   *
   * - `person`: Person entity
   */
  UpdatePersonResponse(params: PeopleService.UpdatePersonParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.person;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/People/${params.id}`,
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
   * @param params The `PeopleService.UpdatePersonParams` containing the following parameters:
   *
   * - `id`: Offer id
   *
   * - `person`: Person entity
   */
  UpdatePerson(params: PeopleService.UpdatePersonParams): Observable<null> {
    return this.UpdatePersonResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Person to delete id
   */
  DeletePersonResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/People/${id}`,
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
   * @param id Person to delete id
   */
  DeletePerson(id: number): Observable<null> {
    return this.DeletePersonResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module PeopleService {

  /**
   * Parameters for UpdatePerson
   */
  export interface UpdatePersonParams {

    /**
     * Offer id
     */
    id: number;

    /**
     * Person entity
     */
    person?: Person;
  }
}

export { PeopleService }
