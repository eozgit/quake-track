import { createAction, props } from '@ngrx/store';
import { Project, Issue, User } from '../models';

export const loadProjects = createAction(
  '[Project] Load Projects'
);

export const loadProjectsSuccess = createAction(
  '[Project] Load Projects Success',
  props<{ data: any }>()
);

export const loadProjectsFailure = createAction(
  '[Project] Load Projects Failure',
  props<{ error: any }>()
);


export const deleteProject = createAction(
  '[Delete Project Dialog] Delete Project',
  props<{ projectId: number }>()
);

export const deleteProjectSuccess = createAction(
  '[API Delete Project] Success',
  props<{ data: any }>()
);

export const deleteProjectFailure = createAction(
  '[API Delete Project] Failure',
  props<{ error: any }>()
);


export const getProject = createAction(
  '[Edit Project Dialog] Get Project',
  props<{ projectId: number }>()
);

export const getProjectSuccess = createAction(
  '[API Get Project] Success',
  props<{ data: any }>()
);

export const getProjectFailure = createAction(
  '[API Get Project] Failure',
  props<{ error: any }>()
);


export const editProject = createAction(
  '[Project Table] Edit Project',
  props<{ projectId: number }>()
);

export const updateProject = createAction(
  '[Edit Project Dialog] Update Project',
  props<{ project: Project }>()
);

export const updateProjectSuccess = createAction(
  '[API Update Project] Success',
  props<{ data: any }>()
);

export const updateProjectFailure = createAction(
  '[API Update Project] Failure',
  props<{ error: any }>()
);


export const addUser = createAction(
  '[Edit Project Dialog] Add User',
  props<{ projectId: number, email: string }>()
);

export const addUserSuccess = createAction(
  '[API Add User] Success',
  props<{ data: User }>()
);

export const addUserFailure = createAction(
  '[API Add User] Failure',
  props<{ error: any }>()
);


export const removeUser = createAction(
  '[Edit Project Dialog] Remove User',
  props<{ projectId: number, userId: string }>()
);

export const removeUserSuccess = createAction(
  '[API Remove User] Success',
  props<{ data: User }>()
);

export const removeUserFailure = createAction(
  '[API Remove User] Failure',
  props<{ error: any }>()
);


export const createProject = createAction(
  '[Projects Page] Create Project',
  props<{ name: string }>()
);

export const createProjectSuccess = createAction(
  '[API Create Project] Success',
  props<{ data: any }>()
);

export const createProjectFailure = createAction(
  '[API Create Project] Failure',
  props<{ error: any }>()
);


export const loadIssues = createAction(
  '[Projects Table] Load Issues',
  props<{ projectId: number }>()
);

export const loadIssuesSuccess = createAction(
  '[API Load Issues] Success',
  props<{ data: any }>()
);

export const loadIssuesFailure = createAction(
  '[API Load Issues] Failure',
  props<{ error: any }>()
);


export const dragIssue = createAction(
  '[Project Board] Drag and Drop Issue',
  props<{ projectId: number, issue: Issue }>()
);

export const dragIssueSuccess = createAction(
  '[API Update Issue] Success',
  props<{ data: any, projectId: number }>()
);

export const dragIssueFailure = createAction(
  '[API Update Issue] Failure',
  props<{ error: any, projectId: number }>()
);


export const createIssue = createAction(
  '[Create Issue Dialog] Create Issue',
  props<{ projectId: number, issue: Issue }>()
);

export const createIssueSuccess = createAction(
  '[API Create Issue] Success',
  props<{ projectId: number, data: any }>()
);

export const createIssueFailure = createAction(
  '[API Create Issue] Failure',
  props<{ error: any }>()
);


export const updateIssue = createAction(
  '[Edit Issue Dialog] Update Issue',
  props<{ projectId: number, issue: Issue }>()
);

export const updateIssueSuccess = createAction(
  '[API Update Issue] Success',
  props<{ projectId: number, data: any }>()
);

export const updateIssueFailure = createAction(
  '[API Update Issue] Failure',
  props<{ error: any }>()
);


export const deleteIssue = createAction(
  '[Edit Issue Dialog] Delete Issue',
  props<{ projectId: number, issueId: number }>()
);

export const deleteIssueSuccess = createAction(
  '[API Delete Issue] Success',
  props<{ projectId: number, data: any }>()
);

export const deleteIssueFailure = createAction(
  '[API Delete Issue] Failure',
  props<{ error: any }>()
);
