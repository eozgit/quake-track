import { InjectionToken } from '@angular/core';
import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';
import * as fromProject from '../project/project.reducer';


export interface State {

  [fromProject.projectFeatureKey]: fromProject.State;
}

export const reducers: ActionReducerMap<State> = {

  [fromProject.projectFeatureKey]: fromProject.reducer,
};

export const REDUCERS_TOKEN = new InjectionToken<ActionReducerMap<State>>('App Reducers');
export const reducerProvider = { provide: REDUCERS_TOKEN, useValue: reducers };


export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
