import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudTableComponent } from './crud-table.component';

describe('CrudTableComponent', () => {
  let component: CrudTableComponent<any>;
  let fixture: ComponentFixture<CrudTableComponent<any>>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CrudTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CrudTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
