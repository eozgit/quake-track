import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectsRowComponent } from './projects-row.component';

describe('ProjectsRowComponent', () => {
  let component: ProjectsRowComponent;
  let fixture: ComponentFixture<ProjectsRowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectsRowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectsRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
