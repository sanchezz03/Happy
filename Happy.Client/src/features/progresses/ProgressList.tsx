import { observer } from "mobx-react-lite";
import { Table } from "semantic-ui-react";
import ProgramListItem from "./ProgressListItem";
import { Progress } from "../../app/models/progress";

interface Props{
    progress: Progress[]
}

export default observer(function ProgressList({progress}: Props){
    return(
        <Table.Body>
            {progress.map((progress) => (
                <ProgramListItem key={progress.id} progress={progress} />
            ))}
        </Table.Body>
    )
})