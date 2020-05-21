import * as fromProject from './project.actions';

describe('loadProjects', () => {
  it('should return an action', () => {
    expect(fromProject.loadProjects().type).toBe('[Project] Load Projects');
  });
});
