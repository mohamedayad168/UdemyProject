import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentAccordionComponent } from './content-accordion.component';

describe('ContentAccordionComponent', () => {
  let component: ContentAccordionComponent;
  let fixture: ComponentFixture<ContentAccordionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContentAccordionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContentAccordionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
