import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GlobalTermsComponent } from './global-terms.component';

describe('GlobalTermsComponent', () => {
  let component: GlobalTermsComponent;
  let fixture: ComponentFixture<GlobalTermsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GlobalTermsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GlobalTermsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
