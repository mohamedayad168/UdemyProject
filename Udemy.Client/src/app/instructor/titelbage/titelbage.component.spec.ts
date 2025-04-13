import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TitelbageComponent } from './titelbage.component';

describe('TitelbageComponent', () => {
  let component: TitelbageComponent;
  let fixture: ComponentFixture<TitelbageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TitelbageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TitelbageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
