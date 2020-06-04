import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromProject from './project.reducer';

export const selectProjectState = createFeatureSelector<fromProject.State>(fromProject.projectFeatureKey);

export const selectProjects = createSelector(selectProjectState, project => project.projects);

export const selectCurrentProjectId = createSelector(selectProjectState, project => project.currentProjectId);

export const selectCurrentProject = createSelector(selectProjects, selectCurrentProjectId, (projects, id) => projects.find(p => p.id === id));

export const selectIssues = createSelector(selectProjectState, (state: fromProject.State, props) => {
    const issues = [...state.currentProjectIssues.filter(issue => issue.status === props.status)];
    issues.sort((a, b) => a.index - b.index);
    return issues;
});

export const selectIssue = createSelector(selectProjectState, (state, props) => state.currentProjectIssues.find(issue => issue.id === props.issueId));
