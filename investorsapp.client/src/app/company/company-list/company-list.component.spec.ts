import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { CompanylistComponent } from './company-list.component';
import { provideHttpClient } from '@angular/common/http';

describe('CompanylistComponent', () => {
  let component: CompanylistComponent;
  let fixture: ComponentFixture<CompanylistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers: [
        provideHttpClient(),
        provideHttpClientTesting(),
      ],
      declarations: [CompanylistComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanylistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
