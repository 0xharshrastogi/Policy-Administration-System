import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyInputComponent } from './property-input.component';

describe('PropertyInputComponent', () => {
  let component: PropertyInputComponent;
  let fixture: ComponentFixture<PropertyInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PropertyInputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
