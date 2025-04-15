import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditinstructorPageComponent } from './editinstructor-page.component';

describe('EditinstructorPageComponent', () => {
  let component: EditinstructorPageComponent;
  let fixture: ComponentFixture<EditinstructorPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditinstructorPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditinstructorPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
