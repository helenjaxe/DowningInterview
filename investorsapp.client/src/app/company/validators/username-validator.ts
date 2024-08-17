import { AbstractControl, AsyncValidator, ValidationErrors } from "@angular/forms";
import { CompanyService } from "../company.service";
import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";

@Injectable({ providedIn: 'root' })
export class UsernameValidator implements AsyncValidator {
  constructor(private companySvc: CompanyService) { }

  validate(control: AbstractControl): Observable<ValidationErrors | null> {

    return this.companySvc.getCompany(control.value).pipe(
      map((result) =>
        result ? { 'codeexists' : true } : null
      )
    );
  }
}
