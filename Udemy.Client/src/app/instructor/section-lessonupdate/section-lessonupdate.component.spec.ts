import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionLessonupdateComponent } from './section-lessonupdate.component';

describe('SectionLessonupdateComponent', () => {
  let component: SectionLessonupdateComponent;
  let fixture: ComponentFixture<SectionLessonupdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SectionLessonupdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SectionLessonupdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
