import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatecoursedetailsComponent } from './updatecoursedetails.component';

describe('UpdatecoursedetailsComponent', () => {
  let component: UpdatecoursedetailsComponent;
  let fixture: ComponentFixture<UpdatecoursedetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdatecoursedetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdatecoursedetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
