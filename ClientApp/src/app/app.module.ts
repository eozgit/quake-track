import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { EffectsModule } from '@ngrx/effects';
import { ProjectsPageComponent } from './projects-page/projects-page.component';
import { ProjectsTableComponent } from './projects-table/projects-table.component';
import { metaReducers, reducerProvider, REDUCERS_TOKEN } from './reducers';
import * as fromProject from './project/project.reducer';
import { ProjectEffects } from './project/project.effects';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DeleteProjectDialogComponent } from './delete-project-dialog/delete-project-dialog.component';
import { EditProjectDialogComponent } from './edit-project-dialog/edit-project-dialog.component';
import { ToastsComponent } from './toasts/toasts.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { BoardPageComponent } from './board-page/board-page.component';
import { BoardComponent } from './board/board.component';
import { CreateIssueDialogComponent } from './create-issue-dialog/create-issue-dialog.component';
import { EditIssueDialogComponent } from './edit-issue-dialog/edit-issue-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProjectsPageComponent,
    ProjectsTableComponent,
    DeleteProjectDialogComponent,
    EditProjectDialogComponent,
    ToastsComponent,
    ContactUsComponent,
    BoardPageComponent,
    BoardComponent,
    CreateIssueDialogComponent,
    EditIssueDialogComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'projects', component: ProjectsPageComponent, canActivate: [AuthorizeGuard] },
      { path: 'contact', component: ContactUsComponent, canActivate: [AuthorizeGuard] },
      { path: 'board', component: BoardPageComponent, canActivate: [AuthorizeGuard] },
    ]),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production }),
    StoreModule.forRoot(REDUCERS_TOKEN, {
      metaReducers,
      runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true,
      }
    }),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
    StoreModule.forFeature(fromProject.projectFeatureKey, fromProject.PROJECT_REDUCER),
    EffectsModule.forRoot([]),
    EffectsModule.forFeature([ProjectEffects]),
    FontAwesomeModule,
    NgbModule,
    DragDropModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    reducerProvider,
    { provide: fromProject.PROJECT_REDUCER, useValue: fromProject.reducer }
  ],
  bootstrap: [AppComponent],
  entryComponents: [DeleteProjectDialogComponent, EditProjectDialogComponent]
})
export class AppModule { }
