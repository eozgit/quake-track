import User from "./user";
import Issue from "./issue";

export default class Project {
    id: number;
    name: string;
    description: string;
    users: User[];
    issues: Issue[];
}
