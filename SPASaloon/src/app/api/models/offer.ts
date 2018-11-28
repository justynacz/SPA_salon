/* tslint:disable */
import { Role } from './role';
import { Term } from './term';
export interface Offer {
  offerId?: number;
  name?: string;
  description?: string;
  roleId?: number;
  role?: Role;
  term?: Array<Term>;
}
