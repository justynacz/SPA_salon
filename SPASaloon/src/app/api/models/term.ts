/* tslint:disable */
import { Client } from './client';
import { Offer } from './offer';
import { Worker } from './worker';
import { Review } from './review';
export interface Term {
  done?: boolean;
  termId?: number;
  hour?: string;
  offerId?: number;
  workerId?: number;
  clientId?: number;
  date?: string;
  price?: number;
  client?: Client;
  offer?: Offer;
  worker?: Worker;
  review?: Array<Review>;
}
