import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginasinstractorComponent } from './loginasinstractor.component';

describe('LoginasinstractorComponent', () => {
  let component: LoginasinstractorComponent;
  let fixture: ComponentFixture<LoginasinstractorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginasinstractorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginasinstractorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
