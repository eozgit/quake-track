import { Action, createReducer, on } from '@ngrx/store';
import * as ProjectActions from './project.actions';

export const projectFeatureKey = 'project';

export interface State {

}

export const initialState: State = {

};


export const reducer = createReducer(
  initialState,

  on(ProjectActions.loadProjects, state => state),
  on(ProjectActions.loadProjectsSuccess, (state, action) => state),
  on(ProjectActions.loadProjectsFailure, (state, action) => state),

);

