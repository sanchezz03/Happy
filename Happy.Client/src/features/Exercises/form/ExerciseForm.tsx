import { observer } from "mobx-react-lite";
import { useStore } from "../../../app/stores/store";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { ExerciseFormValues } from "../../../app/models/exercise";
import { Button, Header, Segment } from "semantic-ui-react";
import { Form, Formik } from "formik";
import MyTextInput from "../../../app/common/form/MyTextInput";
import MyTextArea from "../../../app/common/form/MyTextArea";


export default observer(function ExerciseForm(){
    const {exerciseStore} = useStore();
    const {createExercise, updateExercise, loadExercise} = exerciseStore;
    const {id} = useParams();
    const navigate = useNavigate();

    const [exercise, setExercise] = useState<ExerciseFormValues>(new ExerciseFormValues());

    useEffect(() => {
        if(id) loadExercise(id).then(exercise => setExercise(new ExerciseFormValues(exercise)))
    }, [id, loadExercise])

    function handleFormSubmit(exercise: ExerciseFormValues){
        console.log(exercise.id);
        if(!exercise.id){
            createExercise(exercise).then(() => navigate(`/exercises`))
        }else{
            updateExercise(exercise).then(() => navigate(`/exercises`))
        }
    }

    return(
        <Segment clearing>
        <Header content='Exercise Details' sub color='teal' />
        <Formik
            enableReinitialize
            initialValues={exercise}
            onSubmit={values => handleFormSubmit(values)}
        >
            {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                <Form className="ui form" onSubmit={handleSubmit} autoComplete='off'>
                    <MyTextInput name='name' placeholder='Name' />
                    <MyTextArea placeholder='Description' name='description' rows={3} />
                    <Header content='Exercise Metrics' sub color='teal' />
                    <MyTextInput name='weight' placeholder='Weight' type='number' />
                    <MyTextInput name='numberOfRepetitions' placeholder='Number of Repetitions' type='number' />
                    <Button
                        disabled={isSubmitting || !dirty || !isValid}
                        loading={isSubmitting}
                        floated="right"
                        positive
                        type='submit'
                        content='Submit'
                    />
                    <Button as={Link} to='/exercises' floated="right" type='button' content='Cancel' />
                </Form>
            )}
        </Formik>
    </Segment>
    )
})