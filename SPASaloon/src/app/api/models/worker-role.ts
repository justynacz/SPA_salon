/* tslint:disable */
import { Role } from './role';
import { Worker } from './worker';
export interface WorkerRole {
  workerRoleId?: number;
  workerId?: number;
  roleId?: number;
  role?: Role;
  worker?: Worker;
}
