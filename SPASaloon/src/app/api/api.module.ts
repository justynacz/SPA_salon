/* tslint:disable */
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ApiConfiguration } from './api-configuration';

import { ClientsService } from './services/clients.service';
import { GlobalTermsService } from './services/global-terms.service';
import { LoginsService } from './services/logins.service';
import { OffersService } from './services/offers.service';
import { PeopleService } from './services/people.service';
import { ReviewsService } from './services/reviews.service';
import { RolesService } from './services/roles.service';
import { TermsService } from './services/terms.service';
import { WorkersService } from './services/workers.service';

/**
 * Provider for all Api services, plus ApiConfiguration
 */
@NgModule({
  imports: [
    HttpClientModule
  ],
  exports: [
    HttpClientModule
  ],
  declarations: [],
  providers: [
    ApiConfiguration,
    ClientsService,
    GlobalTermsService,
    LoginsService,
    OffersService,
    PeopleService,
    ReviewsService,
    RolesService,
    TermsService,
    WorkersService
  ],
})
export class ApiModule { }
