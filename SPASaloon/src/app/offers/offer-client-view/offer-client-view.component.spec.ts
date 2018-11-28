import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfferClientViewComponent } from './offer-client-view.component';

describe('OfferClientViewComponent', () => {
  let component: OfferClientViewComponent;
  let fixture: ComponentFixture<OfferClientViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfferClientViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfferClientViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
