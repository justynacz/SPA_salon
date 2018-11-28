/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Worker } from '../models/worker';
import { NewWorkerModel } from '../models/new-worker-model';
@Injectable({
  providedIn: 'root',
})
class WorkersService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of workers
   */
  GetWorkersResponse(): Observable<StrictHttpResponse<Array<Worker>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Workers`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<Worker>>;
      })
    );
  }
  /**
   * @return Returns the list of workers
   */
  GetWorkers(): Observable<Array<Worker>> {
    return this.GetWorkersResponse().pipe(
      __map(_r => _r.body as Array<Worker>)
    );
  }

  /**
   * @param worker New worker model
   */
  CreateWorkerResponse(worker?: NewWorkerModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = worker;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Workers`,
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
   * @param worker New worker model
   */
  CreateWorker(worker?: NewWorkerModel): Observable<null> {
    return this.CreateWorkerResponse(worker).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Worker id
   */
  GetWorkerResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Workers/${id}`,
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
   * @param id Worker id
   */
  GetWorker(id: number): Observable<null> {
    return this.GetWorkerResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `WorkersService.UpdateWorkerParams` containing the following parameters:
   *
   * - `id`: Worker id
   *
   * - `worker`: Worker entity
   */
  UpdateWorkerResponse(params: WorkersService.UpdateWorkerParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.worker;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Workers/${params.id}`,
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
   * @param params The `WorkersService.UpdateWorkerParams` containing the following parameters:
   *
   * - `id`: Worker id
   *
   * - `worker`: Worker entity
   */
  UpdateWorker(params: WorkersService.UpdateWorkerParams): Observable<null> {
    return this.UpdateWorkerResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Worker to delete id
   */
  DeleteWorkerResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Workers/${id}`,
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
   * @param id Worker to delete id
   */
  DeleteWorker(id: number): Observable<null> {
    return this.DeleteWorkerResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module WorkersService {

  /**
   * Parameters for UpdateWorker
   */
  export interface UpdateWorkerParams {

    /**
     * Worker id
     */
    id: number;

    /**
     * Worker entity
     */
    worker?: Worker;
  }
}

export { WorkersService }
