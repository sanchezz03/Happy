import { observer } from "mobx-react-lite"
import { useStore } from "../../../app/stores/store";
import { useEffect } from "react";
import { Button, Table } from "semantic-ui-react";
import ExerciseTableHeader from "./ExerciseHeader";
import ExerciseList from "./ExerciseList";
import { NavLink } from "react-router-dom";

export default observer (function ExerciseDashboard() {
    const {exerciseStore} = useStore();
    const {loadExercises, exercise} = exerciseStore;
 
     useEffect(() => {
         if(exercise.size === 0) loadExercises();
     }, [exercise.size, loadExercises])

     return (
      <>
      <Button as={NavLink} to='createExercise' positive content='Create Exercise'/>
         <Table celled>
         <ExerciseTableHeader/>
         <ExerciseList exercise={exercise}/>
       </Table>
       </>
     )
})