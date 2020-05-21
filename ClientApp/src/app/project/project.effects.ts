import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, concatMap } from 'rxjs/operators';
import { of } from 'rxjs';

import * as ProjectActions from './project.actions';
import { ApiClientService } from '../api-client.service';



@Injectable()
export class ProjectEffects {

  loadProjects$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.loadProjects),
      concatMap(() =>
        this.apiClient.getProjects().pipe(
          map(data => ProjectActions.loadProjectsSuccess({ data })),
          catchError(error => of(ProjectActions.loadProjectsFailure({ error }))))
      )
    );
  });



  constructor(private actions$: Actions, private apiClient: ApiClientService) { }

}
