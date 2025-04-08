import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CometeachwithusComponent } from './cometeachwithus.component';

describe('CometeachwithusComponent', () => {
  let component: CometeachwithusComponent;
  let fixture: ComponentFixture<CometeachwithusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CometeachwithusComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CometeachwithusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
