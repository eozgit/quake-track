import { createAction, props } from '@ngrx/store';
import Project from '../models/project';

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