import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyLearningPageComponent } from './my-learning-page.component';

describe('MyLearningPageComponent', () => {
  let component: MyLearningPageComponent;
  let fixture: ComponentFixture<MyLearningPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyLearningPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyLearningPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
