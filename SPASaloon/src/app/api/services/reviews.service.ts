/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { Review } from '../models/review';
import { NewReviewModel } from '../models/new-review-model';
@Injectable({
  providedIn: 'root',
})
class ReviewsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Returns the list of reviews
   */
  GetReviewsResponse(): Observable<StrictHttpResponse<Array<Review>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Reviews`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<Review>>;
      })
    );
  }
  /**
   * @return Returns the list of reviews
   */
  GetReviews(): Observable<Array<Review>> {
    return this.GetReviewsResponse().pipe(
      __map(_r => _r.body as Array<Review>)
    );
  }

  /**
   * @param review New review model
   */
  CreateReviewResponse(review?: NewReviewModel): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = review;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Reviews`,
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
   * @param review New review model
   */
  CreateReview(review?: NewReviewModel): Observable<null> {
    return this.CreateReviewResponse(review).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Review id
   */
  GetReviewResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Reviews/${id}`,
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
   * @param id Review id
   */
  GetReview(id: number): Observable<null> {
    return this.GetReviewResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param params The `ReviewsService.UpdateReviewParams` containing the following parameters:
   *
   * - `id`: Review id
   *
   * - `review`: Review entity
   */
  UpdateReviewResponse(params: ReviewsService.UpdateReviewParams): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.review;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Reviews/${params.id}`,
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
   * @param params The `ReviewsService.UpdateReviewParams` containing the following parameters:
   *
   * - `id`: Review id
   *
   * - `review`: Review entity
   */
  UpdateReview(params: ReviewsService.UpdateReviewParams): Observable<null> {
    return this.UpdateReviewResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id Review id
   */
  DeleteReviewResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Reviews/${id}`,
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
   * @param id Review id
   */
  DeleteReview(id: number): Observable<null> {
    return this.DeleteReviewResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module ReviewsService {

  /**
   * Parameters for UpdateReview
   */
  export interface UpdateReviewParams {

    /**
     * Review id
     */
    id: number;

    /**
     * Review entity
     */
    review?: Review;
  }
}

export { ReviewsService }
