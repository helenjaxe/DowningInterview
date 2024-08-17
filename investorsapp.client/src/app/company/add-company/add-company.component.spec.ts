import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCompanyComponent } from './add-company.component';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { FormGroup, FormsModule, ReactiveFormsModule, FormControl, FormBuilder } from '@angular/forms';


describe('AddCompanyComponent', () => {
  let component: AddCompanyComponent;
  let fixture: ComponentFixture<AddCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers: [
        provideHttpClient(),
        provideHttpClientTesting(),
      ],
      declarations: [AddCompanyComponent],
      imports: [ReactiveFormsModule, FormsModule]
    })
    .compileComponents();
        fixture = TestBed.createComponent(AddCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
