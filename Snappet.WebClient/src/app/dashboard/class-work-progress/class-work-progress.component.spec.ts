import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassWorkProgressComponent } from './class-work-progress.component';

describe('ClassWorkProgressComponent', () => {
  let component: ClassWorkProgressComponent;
  let fixture: ComponentFixture<ClassWorkProgressComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClassWorkProgressComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassWorkProgressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
