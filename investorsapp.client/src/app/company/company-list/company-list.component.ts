import { Component, OnInit } from '@angular/core';
import { ICompany } from '../company';
import { Router } from '@angular/router';
import { CompanyService } from '../company.service';

@Component({
  selector: 'inv-company-list',
  templateUrl: './company-list.component.html',
  styleUrl: './company-list.component.css',
  host: {
    class: 'content'
  }
})
export class CompanylistComponent implements OnInit {

  public companies: ICompany[] = [];

  constructor(private companySvc: CompanyService, private router: Router) { }

  ngOnInit() {
    this.companySvc.getCompanies().subscribe(companies => { this.companies = companies });
  }

  addCompany() {
    this.router.navigate(['/addcompany']);
  }
}
