import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QNAComponent } from './qna.component';

describe('QNAComponent', () => {
  let component: QNAComponent;
  let fixture: ComponentFixture<QNAComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QNAComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QNAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
