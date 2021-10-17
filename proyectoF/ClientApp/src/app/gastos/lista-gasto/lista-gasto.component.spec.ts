import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaGastoComponent } from './lista-gasto.component';

describe('ListaGastoComponent', () => {
  let component: ListaGastoComponent;
  let fixture: ComponentFixture<ListaGastoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaGastoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaGastoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
