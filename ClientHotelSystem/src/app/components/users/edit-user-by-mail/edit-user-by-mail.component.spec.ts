import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditUserByMailComponent } from './edit-user-by-mail.component';

describe('EditUserByMailComponent', () => {
  let component: EditUserByMailComponent;
  let fixture: ComponentFixture<EditUserByMailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditUserByMailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditUserByMailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
