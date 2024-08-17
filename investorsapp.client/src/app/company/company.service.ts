import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICompany, ICompanyAdd } from './company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) { }

  getCompanies(): Observable<ICompany[]>  {
    return this.http.get<ICompany[]>('/api/company/');
  }

  getCompany(code: string): Observable<ICompany> {
    return this.http.get<ICompany>('/api/company/' + code);
  }

  addCompany(company: ICompanyAdd): Observable<ICompany> {
    const headers = { headers: { 'Content-Type': 'application/json' } };
    return this.http.post<ICompany>('/api/company/', company, headers);
  }
}
