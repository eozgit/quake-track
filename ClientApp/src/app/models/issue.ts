import User from "./user";

export default interface Issue {
    id: number;
    summary: string;
    description: string;
    issueType: string;
    assignee: User;
    storypoints: number;
    statue: string;
    priority: string;
    users: User[];
    issues: Issue[];
}
