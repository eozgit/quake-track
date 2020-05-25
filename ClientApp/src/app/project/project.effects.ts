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

  deleteProject$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.deleteProject),
      concatMap(action =>
        this.apiClient.deleteProject(action.projectId).pipe(
          map(data => ProjectActions.deleteProjectSuccess({ data })),
          catchError(error => of(ProjectActions.deleteProjectFailure({ error }))))
      )
    );
  });

  deleteProjectSuccess$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.deleteProjectSuccess),
      map(action =>
        ProjectActions.loadProjects()
      )
    );
  });



  constructor(private actions$: Actions, private apiClient: ApiClientService) { }

}
