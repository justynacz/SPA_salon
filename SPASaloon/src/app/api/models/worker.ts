/* tslint:disable */
import { Person } from './person';
import { Term } from './term';
import { WorkerRole } from './worker-role';
export interface Worker {
  workerId?: number;
  personId?: number;
  dateFrom?: string;
  dateTo?: string;
  person?: Person;
  term?: Array<Term>;
  workerRole?: Array<WorkerRole>;
}
