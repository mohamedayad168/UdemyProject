import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetstartwvedioComponent } from './getstartwvedio.component';

describe('GetstartwvedioComponent', () => {
  let component: GetstartwvedioComponent;
  let fixture: ComponentFixture<GetstartwvedioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetstartwvedioComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetstartwvedioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
