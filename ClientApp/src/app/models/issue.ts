export default interface Issue {
    id: number;
    summary: string;
    description: string;
    issueType: string;
    assigneeId: string;
    storypoints: number;
    status: string;
    priority: string;
    index: number;
}
