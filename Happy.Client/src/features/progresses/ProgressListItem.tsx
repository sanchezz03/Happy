import { Table } from "semantic-ui-react";
import { Progress } from "../../app/models/progress";
import { format } from "date-fns";

interface Props{
    progress: Progress
}

export default function ProgramListItem({progress}: Props) {
    return (
        <Table.Row key={progress.id}>
            <Table.Cell>{progress.weight}</Table.Cell>
            <Table.Cell>{progress.numberOfRepetitions}</Table.Cell>
            <Table.Cell>{format (progress.date!, 'dd MMM yyyy h:mm aa')}</Table.Cell>
            <Table.Cell>{progress.rateOfPerceivedExertion!}</Table.Cell>
            <Table.Cell>{progress.exerciseName}</Table.Cell>
        </Table.Row>
    )
}