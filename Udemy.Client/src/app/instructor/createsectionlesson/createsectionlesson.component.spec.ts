import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatesectionlessonComponent } from './createsectionlesson.component';

describe('CreatesectionlessonComponent', () => {
  let component: CreatesectionlessonComponent;
  let fixture: ComponentFixture<CreatesectionlessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatesectionlessonComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatesectionlessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
