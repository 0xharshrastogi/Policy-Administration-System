import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerBusinessPropertyComponent } from './consumer-business-property.component';

describe('ConsumerBusinessPropertyComponent', () => {
  let component: ConsumerBusinessPropertyComponent;
  let fixture: ComponentFixture<ConsumerBusinessPropertyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsumerBusinessPropertyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerBusinessPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
