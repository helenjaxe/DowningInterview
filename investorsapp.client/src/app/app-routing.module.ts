import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanylistComponent } from './company/company-list/company-list.component';
import { AddCompanyComponent } from './company/add-company/add-company.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'companylist', component: CompanylistComponent },
  { path: 'addcompany', component: AddCompanyComponent },
  { path: '', redirectTo : '/home', pathMatch : 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
