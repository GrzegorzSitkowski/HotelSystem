import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreReservationComponent } from './pre-reservation.component';

describe('PreReservationComponent', () => {
  let component: PreReservationComponent;
  let fixture: ComponentFixture<PreReservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PreReservationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PreReservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
