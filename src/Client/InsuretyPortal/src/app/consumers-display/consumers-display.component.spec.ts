import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumersDisplayComponent } from './consumers-display.component';

describe('ConsumersDisplayComponent', () => {
  let component: ConsumersDisplayComponent;
  let fixture: ComponentFixture<ConsumersDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsumersDisplayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumersDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
