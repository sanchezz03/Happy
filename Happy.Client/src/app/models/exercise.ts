export interface IExercise {
    id: number;
    name: string;
    description: string;
    weight?: number;
    numberOfRepetitions?: number;
}

export class Exercise implements IExercise {
    id: number;
    name: string;
    description: string;
    weight?: number;
    numberOfRepetitions?: number;

    constructor(init: ExerciseFormValues) {
        this.id = init.id;
        this.name = init.name;
        this.description = init.description;
        this.weight = init.weight;
        this.numberOfRepetitions = init.numberOfRepetitions;
    }
}

export class ExerciseFormValues {
    id: number = 0;
    name: string = '';
    description: string = '';
    weight?: number = undefined;
    numberOfRepetitions?: number = undefined;

    constructor(init?: ExerciseFormValues) {
        if(init){
        this.id = init.id;
        this.name = init.name;
        this.description = init.description;
        this.weight = init.weight;
        this.numberOfRepetitions = init.numberOfRepetitions;
        }
    }
}