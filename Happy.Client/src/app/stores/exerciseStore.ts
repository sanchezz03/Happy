import { makeAutoObservable, runInAction } from "mobx";
import { Exercise, ExerciseFormValues } from "../models/exercise";
import agent from "../api/agent";

export default class ExerciseStore{
    exercise = new Map<number, Exercise>();
    selectedExercise: Exercise | undefined = undefined;

    constructor() {
        makeAutoObservable(this);
    }

    loadExercises = async () => {
       try{
        const exercises = await agent.Exercises.list();
        runInAction(() => {
                exercises.forEach(exercise => {
                    this.setExercise(exercise);
                })
            })
        }catch(error){
            runInAction(() => {
                console.log(error);
            })
        }

    }

    loadExercise = async (id: string) => {
        let exercise = this.getExercise(id);
        this.selectedExercise = exercise;
        return exercise;
    }

    private getExercise = (id: any) => {
        const numericId = Number(id);
        if (isNaN(numericId)) {
            throw new Error("Invalid ID: not a number");
        }
        return this.exercise.get(numericId);
    }

    createExercise = async (exercise: ExerciseFormValues) => {
        try{
            await agent.Exercises.create(exercise);
            const newExercise = new Exercise(exercise);
            this.setExercise(newExercise);
        }catch(error){
            console.log(error);
        }
    }

    updateExercise = async (exercise: ExerciseFormValues) => {
        try{
            await agent.Exercises.update(exercise.id, exercise);
            runInAction(() => {
                if(exercise.id){
                    const updatedExercise = {...this.getExercise(exercise.id), ...exercise}
                    this.exercise.set(exercise.id, updatedExercise as Exercise);
                    this.selectedExercise = exercise as Exercise;
                }
            })
        } catch(error){
            console.log(error);
        }
    }

    deleteExercise = async(id: number) => {
        try{
            await agent.Exercises.delete(id);
            runInAction(() => {
                this.exercise.delete(id);
                runInAction(() => {
                    this.exercise.delete(id);
                })
            })
        }catch(error){
            console.log(error);
        }
    }

    private setExercise(exercise: Exercise) {
        this.exercise.set(exercise.id, exercise);
    }
}