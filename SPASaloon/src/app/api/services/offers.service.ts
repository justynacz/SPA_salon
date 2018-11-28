/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Offer } from '../models/offer';
import { NewOfferModel } from '../models/new-offer-model';
@Injectable({
  providedIn: 'root',
})
class OffersService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of offers
   */
  GetOffersResponse(): Observable<StrictHttpResponse<Array<Offer>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Offers`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<Offer>>;
      })
    );
  }
  /**
   * @return Returns the list of offers
   */
  GetOffers(): Observable<Array<Offer>> {
    return this.GetOffersResponse().pipe(
      __map(_r => _r.body as Array<Offer>)
    );
  }

  /**
   * @param offer New offer model
   */
  CreateOfferResponse(offer?: NewOfferModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = offer;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Offers`,
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
   * @param offer New offer model
   */
  CreateOffer(offer?: NewOfferModel): Observable<null> {
    return this.CreateOfferResponse(offer).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Offer id
   */
  GetOfferResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Offers/${id}`,
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
   * @param id Offer id
   */
  GetOffer(id: number): Observable<null> {
    return this.GetOfferResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `OffersService.UpdateOfferParams` containing the following parameters:
   *
   * - `id`: Offer id
   *
   * - `offer`: Offer entity
   */
  UpdateOfferResponse(params: OffersService.UpdateOfferParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.offer;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Offers/${params.id}`,
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
   * @param params The `OffersService.UpdateOfferParams` containing the following parameters:
   *
   * - `id`: Offer id
   *
   * - `offer`: Offer entity
   */
  UpdateOffer(params: OffersService.UpdateOfferParams): Observable<null> {
    return this.UpdateOfferResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Offer to delete id
   */
  DeleteOfferResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Offers/${id}`,
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
   * @param id Offer to delete id
   */
  DeleteOffer(id: number): Observable<null> {
    return this.DeleteOfferResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module OffersService {

  /**
   * Parameters for UpdateOffer
   */
  export interface UpdateOfferParams {

    /**
     * Offer id
     */
    id: number;

    /**
     * Offer entity
     */
    offer?: Offer;
  }
}

export { OffersService }
