import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClearnerTestimonialsComponent } from './clearner-testimonials.component';

describe('ClearnerTestimonialsComponent', () => {
  let component: ClearnerTestimonialsComponent;
  let fixture: ComponentFixture<ClearnerTestimonialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClearnerTestimonialsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClearnerTestimonialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
