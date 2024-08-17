import { Component } from '@angular/core';
import { CompanyService } from '../company.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsernameValidator } from '../validators/username-validator';

@Component({
  selector: 'inv-add-company',
  templateUrl: './add-company.component.html',
  styleUrl: './add-company.component.css',
  host: {
    class: 'content'
  }
})
export class AddCompanyComponent {
  companyForm!: FormGroup;
  error: string = '';

  constructor(private formBuilder: FormBuilder, private companySvc: CompanyService, private router: Router, private usernameValidator: UsernameValidator) {
    this.companyForm = this.formBuilder.group({
      companyName: ['', [Validators.required, Validators.maxLength(100)]],
      code: ['', {
        validators: [Validators.required, Validators.maxLength(10), Validators.pattern('^[A-Z1-9]*$')],
        asyncValidators: this.usernameValidator.validate.bind(this.usernameValidator),
        updateOn: 'blur'
      }],
      sharePrice: [<number | null>null, Validators.pattern('^[0-9]+(.[0-9]{0,5})?$')]
    });
  }

  get companyName() {
    return this.companyForm.controls['companyName'];
  }

  get code() {
    return this.companyForm.controls['code'];
  }

  get sharePrice() {
    return this.companyForm.controls['sharePrice'];
  }

  convertCodeToUppercase() {
    let converted = this.code.value.toUpperCase();
    this.companyForm.patchValue({ code: converted });
  }

  addCompany() {
    if (!this.companyForm.valid) {
      this.companyForm.markAllAsTouched();
      return;
    }

    this.companySvc.addCompany(this.companyForm.getRawValue()).subscribe({
      next: () => this.router.navigate(['/companylist']),
      error: e => this.error = 'An error occurred creating the company.',
    })
  }

  cancel() {
    this.router.navigate(['/companylist']);
  }

}
