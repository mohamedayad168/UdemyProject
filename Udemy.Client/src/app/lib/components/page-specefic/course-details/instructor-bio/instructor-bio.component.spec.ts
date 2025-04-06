import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorBioComponent } from './instructor-bio.component';

describe('InstructorBioComponent', () => {
  let component: InstructorBioComponent;
  let fixture: ComponentFixture<InstructorBioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstructorBioComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstructorBioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
