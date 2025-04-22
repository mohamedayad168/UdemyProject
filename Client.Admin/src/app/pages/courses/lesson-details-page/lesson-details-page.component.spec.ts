import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonDetailsPageComponent } from './lesson-details-page.component';

describe('LessonDetailsPageComponent', () => {
  let component: LessonDetailsPageComponent;
  let fixture: ComponentFixture<LessonDetailsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LessonDetailsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LessonDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
