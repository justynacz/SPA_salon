/* tslint:disable */
import { Person } from './person';
import { Term } from './term';
export interface Client {
  clientId?: number;
  personId?: number;
  person?: Person;
  term?: Array<Term>;
}
