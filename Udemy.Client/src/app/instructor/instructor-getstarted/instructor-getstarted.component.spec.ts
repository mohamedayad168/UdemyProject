import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorGetstartedComponent } from './instructor-getstarted.component';

describe('InstructorGetstartedComponent', () => {
  let component: InstructorGetstartedComponent;
  let fixture: ComponentFixture<InstructorGetstartedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstructorGetstartedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstructorGetstartedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
