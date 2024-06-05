import { Button, Table } from "semantic-ui-react"
import { Exercise } from "../../../app/models/exercise"
import { Link } from "react-router-dom"
import { useStore } from "../../../app/stores/store";

interface Props{
    exercise: Exercise
}

export default function ExerciseListItem({exercise}: Props) {
    const {exerciseStore: {deleteExercise}} = useStore();
    
    return (
        <Table.Row key={exercise.id}>
        <Table.Cell>{exercise.name}</Table.Cell>
        <Table.Cell>{exercise.description}</Table.Cell>
        <Table.Cell>{exercise.weight ?? 'N/A'}</Table.Cell>
        <Table.Cell>{exercise.numberOfRepetitions}</Table.Cell>
        <Table.Cell textAlign="center">
        <div style={{ display: 'flex', justifyContent: 'center' }}>
                    <Button as={Link} to={`/exercises/manage/${exercise.id}`} color="blue" style={{ marginRight: '0.5em' }}>Edit</Button>
                    <Button onClick={() => deleteExercise(exercise.id)} color="red">Remove</Button>
                </div>
        </Table.Cell> 
      </Table.Row>
    )
}