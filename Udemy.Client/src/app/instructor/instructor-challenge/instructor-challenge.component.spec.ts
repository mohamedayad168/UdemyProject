import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorChallengeComponent } from './instructor-challenge.component';

describe('InstructorChallengeComponent', () => {
  let component: InstructorChallengeComponent;
  let fixture: ComponentFixture<InstructorChallengeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstructorChallengeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstructorChallengeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
