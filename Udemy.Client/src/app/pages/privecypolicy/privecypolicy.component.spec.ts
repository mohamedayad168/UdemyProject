import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivecypolicyComponent } from './privecypolicy.component';

describe('PrivecypolicyComponent', () => {
  let component: PrivecypolicyComponent;
  let fixture: ComponentFixture<PrivecypolicyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrivecypolicyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrivecypolicyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
