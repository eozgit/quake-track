import { TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { Observable } from 'rxjs';

import { ProjectEffects } from './project.effects';

describe('ProjectEffects', () => {
  let actions$: Observable<any>;
  let effects: ProjectEffects;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        ProjectEffects,
        provideMockActions(() => actions$)
      ]
    });

    effects = TestBed.inject(ProjectEffects);
  });

  it('should be created', () => {
    expect(effects).toBeTruthy();
  });
});
