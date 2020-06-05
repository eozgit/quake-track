import User from './user';
import Issue from './issue';

export default interface Project {
    id: number;
    name: string;
    description: string;
    users: User[];
    issues: Issue[];
}
