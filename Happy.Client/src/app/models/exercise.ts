import { Progress } from "./progress";

export interface Exercise {
    id: number;
    name: string;
    description: string;
    weight?: number;
    numberOfRepetitions: number;
    progresses: Progress[];
}