import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateLessonSectionComponent } from './update-lesson-section.component';

describe('UpdateLessonSectionComponent', () => {
  let component: UpdateLessonSectionComponent;
  let fixture: ComponentFixture<UpdateLessonSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateLessonSectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateLessonSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
