import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { of, interval } from 'rxjs';
import { catchError, map, concatMap, tap, throttle } from 'rxjs/operators';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { User } from '../models';
import * as ProjectActions from './project.actions';
import { ApiClientService } from '../api-client.service';
import { ToastService } from '../toast.service';



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
      map(action =>
        ProjectActions.loadProjects()
      ),
    );
  });


  removeUser$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.removeUser),
      concatMap(action =>
        this.apiClient.removeUser(action.projectId, action.userId).pipe(
          map((data: User) => ProjectActions.removeUserSuccess({ data })),
          catchError(error => of(ProjectActions.removeUserFailure({ error }))))
      )
    );
  });

  removeUserSuccess$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.removeUserSuccess),
      map(action =>
        ProjectActions.loadProjects()
      ),
    );
  });


  createProject$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.createProject),
      concatMap(action =>
        this.apiClient.createProject(action.name).pipe(
          map((data) => ProjectActions.createProjectSuccess({ data })),
          catchError(error => of(ProjectActions.createProjectFailure({ error }))))
      )
    );
  });

  createProjectSuccess$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.createProjectSuccess),
      map(action =>
        ProjectActions.loadProjects()
      ),
    );
  });


  loadIssues$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.loadIssues),
      concatMap(action =>
        this.apiClient.loadIssues(action.projectId).pipe(
          map(data => ProjectActions.loadIssuesSuccess({ data })),
          catchError(error => of(ProjectActions.loadIssuesFailure({ error }))))
      )
    );
  });

  loadIssuesSuccess$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.loadIssuesSuccess),
      throttle(() => interval(0)),
      tap(() => this.router.navigate(['/board']))
    );
  });


  dragIssue$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.dragIssue),
      concatMap(action => this.apiClient.updateIssue(action.projectId, action.issue).pipe(
        map(data => ProjectActions.dragIssueSuccess({ data, projectId: action.projectId })),
        catchError(error => of(ProjectActions.dragIssueFailure({ error, projectId: action.projectId }))))
      )
    );
  });


  dragIssueComplete$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.dragIssueSuccess, ProjectActions.dragIssueFailure),
      concatMap(action =>
        this.apiClient.loadIssues(action.projectId).pipe(
          map(data => ProjectActions.loadIssuesSuccess({ data })),
          catchError(error => of(ProjectActions.loadIssuesFailure({ error }))))
      )
    );
  });


  createIssue$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.createIssue),
      concatMap(action =>
        this.apiClient.createIssue(action.projectId, action.issue).pipe(
          map((data) => ProjectActions.createIssueSuccess({ projectId: action.projectId, data })),
          catchError(error => of(ProjectActions.createIssueFailure({ error }))))
      )
    );
  });

  createIssueSuccess$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(ProjectActions.createIssueSuccess),
      map(action =>
        ProjectActions.loadIssues({ projectId: action.projectId })
      ),
      tap(() => this.modalService.dismissAll())
    );
  });


  apiResponseFailure$ = createEffect(() => {
    return this.actions$.pipe(

      ofType(
        ProjectActions.loadProjectsFailure,
        ProjectActions.createProjectFailure,
        ProjectActions.deleteProjectFailure,
        ProjectActions.getProjectFailure,
        ProjectActions.updateProjectFailure,
        ProjectActions.deleteProjectFailure,
        ProjectActions.addUserFailure,
        ProjectActions.removeUserFailure,
        ProjectActions.loadIssuesFailure,
        ProjectActions.dragIssueFailure,
        ProjectActions.createIssueFailure
      ),
      throttle(() => interval(0)),
      tap(({ error }) => {
        let message = 'Request failed.';
        let classname = 'bg-warning';
        if (error.status === 403) {
          message += ' Please check your grants.';
        } else {
          classname = 'bg-danger text-white';
        }
        this.toastService.show(message, { classname });
      })
    );
  });



  constructor(
    private actions$: Actions,
    private apiClient: ApiClientService,
    private modalService: NgbModal,
    private toastService: ToastService,
    private router: Router) { }

}
