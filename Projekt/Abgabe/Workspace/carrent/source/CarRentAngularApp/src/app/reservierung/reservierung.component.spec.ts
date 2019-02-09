import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservierungComponent } from './reservierung.component';

describe('ReservierungComponent', () => {
  let component: ReservierungComponent;
  let fixture: ComponentFixture<ReservierungComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReservierungComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservierungComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
