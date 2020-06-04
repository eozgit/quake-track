import { InjectionToken } from '@angular/core';
import { TitleCasePipe } from '@angular/common';
import { createReducer, on } from '@ngrx/store';
import Project from '../models/project';
import Issue from '../models/issue';
import * as ProjectActions from './project.actions';

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

    const issue = state.currentProjectIssues.find(issue => issue.id === action.issue.id);
    const statusChanged = issue.status !== action.issue.status;
    let next = [];

    if (statusChanged) {
      let previousColumnIssues = state.currentProjectIssues
        .filter(_issue => _issue.status === issue.status && _issue.id !== issue.id);

      previousColumnIssues.sort((a, b) => a.index - b.index);

      previousColumnIssues = previousColumnIssues
        .map((_issue, index) => ({ ..._issue, index }));

      next = [...previousColumnIssues, ...state.currentProjectIssues.filter(_issue => _issue.status !== issue.status && _issue.status !== action.issue.status)];
    } else {
      next = [...state.currentProjectIssues.filter(_issue => _issue.status !== issue.status)];
    }

    let currentColumnIssues = state.currentProjectIssues
      .filter(_issue => _issue.status === action.issue.status && _issue.id !== action.issue.id);

    currentColumnIssues.sort((a, b) => a.index - b.index);

    currentColumnIssues = currentColumnIssues
      .map((_issue, index) => ({ ..._issue, index: index >= action.issue.index ? index + 1 : index }));

    next = [...next, ...currentColumnIssues, { ...issue, status: new TitleCasePipe().transform(action.issue.status), index: action.issue.index }];

    next.sort((a, b) => a.id - b.id);

    return ({ ...state, currentProjectIssues: next });
  }),

);

export const PROJECT_REDUCER = new InjectionToken<any>('Project Reducer');
