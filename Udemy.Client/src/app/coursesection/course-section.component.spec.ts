import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CourseSectionComponent } from './course-section.component';



describe('CourseviewComponent', () => {
  let component: CourseSectionComponent;
  let fixture: ComponentFixture<CourseSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseSectionComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CourseSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
