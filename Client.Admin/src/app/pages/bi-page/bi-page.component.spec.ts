import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiPageComponent } from './bi-page.component';

describe('BiPageComponent', () => {
  let component: BiPageComponent;
  let fixture: ComponentFixture<BiPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BiPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BiPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
