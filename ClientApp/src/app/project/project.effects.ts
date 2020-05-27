import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, concatMap, tap, throttle } from 'rxjs/operators';
import { of, interval } from 'rxjs';

import * as ProjectActions from './project.actions';
import { ApiClientService } from '../api-client.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EditProjectDialogComponent } from '../edit-project-dialog/edit-project-dialog.component';
import User from '../models/user';



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

  getProject$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.getProject),
      concatMap(action =>
        this.apiClient.getProject(action.projectId).pipe(
          map(data => ProjectActions.getProjectSuccess({ data })),
          catchError(error => of(ProjectActions.getProjectFailure({ error }))))
      )
    );
  });

  updateProject$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.updateProject),
      concatMap(action =>
        this.apiClient.updateProject(action.project).pipe(
          map(data => ProjectActions.updateProjectSuccess({ data })),
          catchError(error => of(ProjectActions.updateProjectFailure({ error }))))
      )
    );
  });

  updateProjectSuccess$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.updateProjectSuccess),
      map(action =>
        ProjectActions.loadProjects()
      ),
      tap(() => this.modalService.dismissAll())
    );
  });

  addUser$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.addUser),
      concatMap(action =>
        this.apiClient.addUser(action.projectId, { email: action.email }).pipe(
          map((data: User) => ProjectActions.addUserSuccess({ data })),
          catchError(error => of(ProjectActions.addUserFailure({ error }))))
      )
    );
  });

  addUserSuccess$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.addUserSuccess),
      tap(action => action.data.email && alert(`${action.data.email}\nis added to the project\nas a contributor.`)),
      map(action =>
        ProjectActions.loadProjects()
      ),
    );
  });



  constructor(private actions$: Actions, private apiClient: ApiClientService, private modalService: NgbModal) { }

}
