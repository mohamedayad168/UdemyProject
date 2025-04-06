import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HandsOnTrainingComponent } from './hands-on-training.component';

describe('HandsOnTrainingComponent', () => {
  let component: HandsOnTrainingComponent;
  let fixture: ComponentFixture<HandsOnTrainingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HandsOnTrainingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HandsOnTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
