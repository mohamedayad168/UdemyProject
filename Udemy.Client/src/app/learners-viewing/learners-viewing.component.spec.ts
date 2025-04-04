import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearnersViewingComponent } from './learners-viewing.component';

describe('LearnersViewingComponent', () => {
  let component: LearnersViewingComponent;
  let fixture: ComponentFixture<LearnersViewingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LearnersViewingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LearnersViewingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
