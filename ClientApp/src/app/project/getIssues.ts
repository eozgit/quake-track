import { TitleCasePipe } from '@angular/common';
import Issue from '../models/issue';

export default (previousIssues: Issue[], model: Issue) => {

    const previous = previousIssues.find(issue => issue.id === model.id);
    const statusChanged = previous.status !== model.status;
    let issues = [];

    if (statusChanged) {
        let previousColumnIssues = previousIssues
            .filter(issue => issue.status === previous.status && issue.id !== previous.id);

        previousColumnIssues.sort((a, b) => a.index - b.index);

        previousColumnIssues = previousColumnIssues
            .map((issue, index) => ({ ...issue, index }));

        issues = [
            ...previousColumnIssues,
            ...previousIssues.filter(issue => issue.status !== previous.status && issue.status !== model.status)
        ];
    } else {
        issues = [...previousIssues.filter(issue => issue.status !== previous.status)];
    }

    let currentColumnIssues = previousIssues
        .filter(issue => issue.status === model.status && issue.id !== model.id);

    currentColumnIssues.sort((a, b) => a.index - b.index);

    currentColumnIssues = currentColumnIssues
        .map((issue, index) => ({ ...issue, index: index >= model.index ? index + 1 : index }));

    issues = [...issues, ...currentColumnIssues, { ...previous, status: new TitleCasePipe().transform(model.status), index: model.index }];

    issues.sort((a, b) => a.id - b.id);

    return issues;
};
