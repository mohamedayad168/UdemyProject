import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstructorsPageComponent } from './instructors-page.component';

describe('InstructorsPageComponent', () => {
  let component: InstructorsPageComponent;
  let fixture: ComponentFixture<InstructorsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstructorsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstructorsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
