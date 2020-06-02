import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Project from './models/project';
import Email from './models/email';
import Message from './models/message';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private http: HttpClient) { }

  getProjects() {
    return this.http.get('/api/projects');
  }

  getProject(id: number) {
    return this.http.get('/api/projects/' + id);
  }

  updateProject(project: Project) {
    return this.http.patch('/api/projects/' + project.id, project);
  }

  deleteProject(id: number) {
    return this.http.delete('/api/projects/' + id);
  }

  addUser(id: number, email: Email) {
    return this.http.patch(`/api/projects/${id}/users`, email);
  }

  removeUser(projectId: number, userId: string) {
    return this.http.delete(`/api/projects/${projectId}/users/${userId}`);
  }

  createProject(name: string) {
    return this.http.post('/api/projects', { name });
  }

  sendEmail(email: Message) {
    return this.http.post('/api/email', email);
  }

  loadIssues(projectId: number) {
    return this.http.get(`/api/projects/${projectId}/issues`);
  }
}
