import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatecoursebageComponent } from './createcoursebage.component';

describe('CreatecoursebageComponent', () => {
  let component: CreatecoursebageComponent;
  let fixture: ComponentFixture<CreatecoursebageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatecoursebageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatecoursebageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
