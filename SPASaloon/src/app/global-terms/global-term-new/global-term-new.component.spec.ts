import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GlobalTermNewComponent } from './global-term-new.component';

describe('GlobalTermNewComponent', () => {
  let component: GlobalTermNewComponent;
  let fixture: ComponentFixture<GlobalTermNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GlobalTermNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GlobalTermNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
