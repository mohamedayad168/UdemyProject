import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirstpageaftercreateComponent } from './firstpageaftercreate.component';

describe('FirstpageaftercreateComponent', () => {
  let component: FirstpageaftercreateComponent;
  let fixture: ComponentFixture<FirstpageaftercreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FirstpageaftercreateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FirstpageaftercreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
