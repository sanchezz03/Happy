import { Exercise } from "./exercise";
import { User } from "./user";

export interface Progress {
    id: number;
    weight?: number;
    numberOfRepetitions: number;
    date: Date;
    rateOfPerceivedExertion?: string;
    user: User;
    exercise: Exercise;
}
