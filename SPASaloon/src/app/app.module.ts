import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {TranslateModule, TranslateLoader} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
 
import { ToastrModule } from 'ngx-toastr';

import { AppBootstrapModule } from './app-bootstrap/app-bootstrap.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './main-layout/navbar/navbar.component';
import { FooterComponent } from './main-layout/footer/footer.component';
import { ContentComponent } from './main-layout/content/content.component';
import { AppRoutingModule } from './app-routing.module';
import { OffersComponent } from './offers/offers.component';
import { OfferNewComponent } from './offers/offer-new/offer-new.component';
import { OfferClientViewComponent } from './offers/offer-client-view/offer-client-view.component';
import { GlobalTermsComponent } from './global-terms/global-terms.component';
import { GlobalTermNewComponent } from './global-terms/global-term-new/global-term-new.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RolesComponent } from './roles/roles.component';
import { RoleNewComponent } from './roles/role-new/role-new.component';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { HttpErrorInterceptor } from './helpers/http-error.interceptor';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    ContentComponent,
    OffersComponent,
    OfferNewComponent,
    OfferClientViewComponent,
    GlobalTermsComponent,
    GlobalTermNewComponent,
    HomeComponent,
    LoginComponent,
    RolesComponent,
    RoleNewComponent
  ],
  imports: [
    BrowserModule,
    AppBootstrapModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot() ,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
    }),
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },],
  bootstrap: [AppComponent],
  entryComponents: [
    OfferNewComponent,
    RoleNewComponent]
})
export class AppModule { }
