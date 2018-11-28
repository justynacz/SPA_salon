/* tslint:disable */
import { Person } from './person';
export interface Login {
  loginId?: number;
  username?: string;
  password?: string;
  active?: boolean;
  person?: Array<Person>;
}
