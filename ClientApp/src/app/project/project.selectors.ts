import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromProject from './project.reducer';

export const selectProjectState = createFeatureSelector<fromProject.State>(
  fromProject.projectFeatureKey
);

export const selectProjects = createSelector(selectProjectState, project => project.projects);

export const selectCurrentProjectId = createSelector(selectProjectState, project => project.currentProjectId);

export const selectCurrentProject = createSelector(selectProjects, selectCurrentProjectId, (projects, id) => projects.find(p => p.id === id));
