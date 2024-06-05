import { createContext, useContext } from "react";
import UserStore from "./userStore";
import CommonStore from "./commonStore";
import ModalStore from "./modalStore";
import ProgressStore from "./progressStore";
import ExerciseStore from "./exerciseStore";
import WeekStore from "./weekStore";

interface Store{
    commonStore: CommonStore;
    weekStore: WeekStore;
    exerciseStore: ExerciseStore;
    progressStore: ProgressStore;
    userStore: UserStore;
    modalStore: ModalStore;
}

export const store: Store = {
    commonStore: new CommonStore(),
    weekStore: new WeekStore(),
    exerciseStore: new ExerciseStore(),
    progressStore: new ProgressStore(),
    userStore: new UserStore(),
    modalStore: new ModalStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}