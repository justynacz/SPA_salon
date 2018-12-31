import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./home/home.component";
import { OffersComponent } from "./offers/offers.component";
import { GlobalTermsComponent } from "./global-terms/global-terms.component";
import { LoginComponent } from "./login/login.component";
import { RolesComponent } from "./roles/roles.component";
import { AuthGuard } from "./guards/auth.guard";

const routes: Routes = [
    { path: '',  component: HomeComponent, pathMatch: 'full' }, 
    { path: 'offers',  component: OffersComponent, pathMatch: 'full' }, 
    { path: 'global-terms',  component: GlobalTermsComponent, pathMatch: 'full', canActivate: [AuthGuard]  }, 
    { path: 'login',  component: LoginComponent, pathMatch: 'full' }, 
    { path: 'roles',  component: RolesComponent, pathMatch: 'full' }, 
    { path: '**', redirectTo: ''}
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
}) 


export class AppRoutingModule { }