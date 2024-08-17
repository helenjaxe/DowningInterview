import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompanylistComponent } from './company/company-list/company-list.component';
import { HeaderComponent } from './header/header.component';
import { provideHttpClient } from '@angular/common/http';
import { AddCompanyComponent } from './company/add-company/add-company.component';
import { HomeComponent } from './home/home.component';

@NgModule({ 
  declarations: [
    AppComponent,
    CompanylistComponent,
    HeaderComponent,
    AddCompanyComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
