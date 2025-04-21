import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorDetailsPageComponent } from './instructor-details-page.component';

describe('InstructorDetailsPageComponent', () => {
  let component: InstructorDetailsPageComponent;
  let fixture: ComponentFixture<InstructorDetailsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstructorDetailsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstructorDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
