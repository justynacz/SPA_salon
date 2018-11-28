/* tslint:disable */
import { Login } from './login';
import { Client } from './client';
import { Worker } from './worker';
export interface Person {
  personId?: number;
  name?: string;
  surname?: string;
  email?: string;
  loginId?: number;
  login?: Login;
  client?: Array<Client>;
  worker?: Array<Worker>;
}
