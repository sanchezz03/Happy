import { makeAutoObservable, runInAction } from "mobx";
import { Week } from "../models/week";
import agent from "../api/agent";

export default class WeekStore{
    week: Week | null = null;

    constructor() {
        makeAutoObservable(this);
    }

    getWeek = async (weekNumber: number) => {
        var week = await agent.Weeks.get(weekNumber);
        runInAction(() => this.week = week);
    }
}