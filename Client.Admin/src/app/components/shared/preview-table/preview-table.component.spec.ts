import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewTableComponent } from './preview-table.component';

describe('PreviewTableComponent', () => {
  let component: PreviewTableComponent;
  let fixture: ComponentFixture<PreviewTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PreviewTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PreviewTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
