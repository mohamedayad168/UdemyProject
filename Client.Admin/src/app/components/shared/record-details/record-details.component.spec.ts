import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecordDetailsComponent } from './record-details.component';

describe('RecordDetailsComponent', () => {
  let component: RecordDetailsComponent;
  let fixture: ComponentFixture<RecordDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecordDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecordDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
