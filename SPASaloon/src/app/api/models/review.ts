/* tslint:disable */
import { Term } from './term';
export interface Review {
  reviewId?: number;
  termId?: number;
  grade?: number;
  description?: string;
  term?: Term;
}
