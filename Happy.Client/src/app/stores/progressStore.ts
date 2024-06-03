import { makeAutoObservable } from "mobx";
import { Progress } from "../models/progress";
import agent from "../api/agent";

export default class ProgressStore{
    progress: Progress[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    loadProgresses = async () => {
        const progress = await agent.UserProgress.list();
        this.setProgress(progress);
    }

    private setProgress(progress: Progress[]) {
        this.progress = progress;
    }
}