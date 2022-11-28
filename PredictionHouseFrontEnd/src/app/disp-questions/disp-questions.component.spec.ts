import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DispQuestionsComponent } from './disp-questions.component';

describe('DispQuestionsComponent', () => {
  let component: DispQuestionsComponent;
  let fixture: ComponentFixture<DispQuestionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DispQuestionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DispQuestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
