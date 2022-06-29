import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicyDisplayComponent } from './policy-display.component';

describe('PolicyDisplayComponent', () => {
  let component: PolicyDisplayComponent;
  let fixture: ComponentFixture<PolicyDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PolicyDisplayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolicyDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
