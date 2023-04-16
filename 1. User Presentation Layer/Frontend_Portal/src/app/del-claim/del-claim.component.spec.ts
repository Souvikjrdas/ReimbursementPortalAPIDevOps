import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DelClaimComponent } from './del-claim.component';

describe('DelClaimComponent', () => {
  let component: DelClaimComponent;
  let fixture: ComponentFixture<DelClaimComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DelClaimComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DelClaimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
