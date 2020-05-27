import { createReducer, on } from '@ngrx/store';
import * as ProjectActions from './project.actions';
import Project from '../models/project';
import { InjectionToken } from '@angular/core';

export const projectFeatureKey = 'project';

export interface State {
  projects: Project[];
  currentProjectId: number;
}

export const initialState: State = {
  projects: [],
  currentProjectId: -1
};


export const reducer = createReducer(
  initialState,

  on(ProjectActions.loadProjectsSuccess, (state, action) => ({ ...state, projects: action.data })),
  on(ProjectActions.editProject, (state, action) => ({ ...state, currentProjectId: action.projectId })),

);

export const PROJECT_REDUCER = new InjectionToken<any>('Project Reducer');
