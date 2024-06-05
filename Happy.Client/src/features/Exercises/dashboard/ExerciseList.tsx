import { observer } from "mobx-react-lite";
import { Table } from "semantic-ui-react";
import ExerciseListItem from "./ExerciseListItem";
import { Exercise } from "../../../app/models/exercise";

interface Props{
    exercise: Map<number, Exercise>
}

export default observer(function ProgressList({exercise}: Props){
    return(
        <Table.Body>
            {Array.from(exercise.values()).map((exercise) => (
                <ExerciseListItem key={exercise.id} exercise={exercise} />
            ))}
        </Table.Body>
    )
})