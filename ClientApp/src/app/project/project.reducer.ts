import { InjectionToken } from '@angular/core';
import { createReducer, on } from '@ngrx/store';
import { Project, Issue } from '../models';
import * as ProjectActions from './project.actions';
import getIssues from './getIssues';

export const projectFeatureKey = 'project';

export interface State {
  projects: Project[];
  currentProjectId: number;
  currentProjectIssues: Issue[];
}

export const initialState: State = {
  projects: [],
  currentProjectId: -1,
  currentProjectIssues: []
};


export const reducer = createReducer(
  initialState,

  on(ProjectActions.loadProjectsSuccess, (state, action) => ({ ...state, projects: action.data })),
  on(ProjectActions.editProject, (state, action) => ({ ...state, currentProjectId: action.projectId })),
  on(ProjectActions.loadIssues, (state, action) => ({ ...state, currentProjectId: action.projectId })),
  on(ProjectActions.loadIssuesSuccess, (state, action) => ({ ...state, currentProjectIssues: action.data })),
  on(ProjectActions.dragIssue, (state: State, action) => {
    const currentProjectIssues = getIssues(state.currentProjectIssues, action.issue);
    return ({ ...state, currentProjectIssues });
  }),

);

export const PROJECT_REDUCER = new InjectionToken<any>('Project Reducer');
