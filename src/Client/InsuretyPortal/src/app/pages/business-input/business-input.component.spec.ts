import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessInputComponent } from './business-input.component';

describe('BusinessInputComponent', () => {
  let component: BusinessInputComponent;
  let fixture: ComponentFixture<BusinessInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusinessInputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
