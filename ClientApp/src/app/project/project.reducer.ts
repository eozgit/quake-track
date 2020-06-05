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
    const currentProjectIssues = getIssues(state.currentProjectIssues, action.issue);
    return ({ ...state, currentProjectIssues });
  }),

);

const getIssues = (previousIssues: Issue[], model: Issue) => {

  const previous = previousIssues.find(issue => issue.id === model.id);
  const statusChanged = previous.status !== model.status;
  let issues = [];

  if (statusChanged) {
    let previousColumnIssues = previousIssues
      .filter(issue => issue.status === previous.status && issue.id !== previous.id);

    previousColumnIssues.sort((a, b) => a.index - b.index);

    previousColumnIssues = previousColumnIssues
      .map((issue, index) => ({ ...issue, index }));

    issues = [...previousColumnIssues, ...previousIssues.filter(issue => issue.status !== previous.status && issue.status !== model.status)];
  } else {
    issues = [...previousIssues.filter(issue => issue.status !== previous.status)];
  }

  let currentColumnIssues = previousIssues
    .filter(issue => issue.status === model.status && issue.id !== model.id);

  currentColumnIssues.sort((a, b) => a.index - b.index);

  currentColumnIssues = currentColumnIssues
    .map((issue, index) => ({ ...issue, index: index >= model.index ? index + 1 : index }));

  issues = [...issues, ...currentColumnIssues, { ...previous, status: new TitleCasePipe().transform(model.status), index: model.index }];

  issues.sort((a, b) => a.id - b.id);

  return issues;
}

export const PROJECT_REDUCER = new InjectionToken<any>('Project Reducer');
