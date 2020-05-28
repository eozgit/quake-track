import { createAction, props } from '@ngrx/store';
import Project from '../models/project';
import User from '../models/user';

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
