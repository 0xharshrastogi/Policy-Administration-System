import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerBusinessComponent } from './customer-business.component';

describe('CustomerBusinessComponent', () => {
  let component: CustomerBusinessComponent;
  let fixture: ComponentFixture<CustomerBusinessComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerBusinessComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerBusinessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
