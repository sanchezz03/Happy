export interface Progress {
    id: number;
    weight?: number;
    numberOfRepetitions: number;
    date: Date;
    rateOfPerceivedExertion?: string;
    exerciseName: string;
}
