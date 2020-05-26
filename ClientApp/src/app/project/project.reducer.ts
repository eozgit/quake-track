import { Action, createReducer, on } from '@ngrx/store';
import * as ProjectActions from './project.actions';
import Project from '../models/project';
import { InjectionToken } from '@angular/core';

export const projectFeatureKey = 'project';

export interface State {
  projects: Project[];
  currentProject: Project;
}

export const initialState: State = {
  projects: [],
  currentProject: {
    id: null,
    name: null,
    description: null,
    issues: null,
    users: null
  }
};


export const reducer = createReducer(
  initialState,

  on(ProjectActions.loadProjects, state => state),
  on(ProjectActions.loadProjectsSuccess, (state, action) => {
    return { ...state, projects: action.data };
  }),
  on(ProjectActions.loadProjectsFailure, (state, action) => state),
  on(ProjectActions.getProjectSuccess, (state, action) => ({ ...state, currentProject: action.data })),

);

export const PROJECT_REDUCER = new InjectionToken<any>('Project Reducer');
