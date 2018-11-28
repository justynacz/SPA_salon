/* tslint:disable */
import { Offer } from './offer';
import { WorkerRole } from './worker-role';
export interface Role {
  roleId?: number;
  name?: string;
  description?: string;
  offer?: Array<Offer>;
  workerRole?: Array<WorkerRole>;
}
