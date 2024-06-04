import { useEffect } from "react";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Table } from "semantic-ui-react";
import ProgramListItem from "./ProgressListItem";

export default observer(function ProgressList(){
    const {progressStore} = useStore();
    const {loadProgresses, progress} = progressStore;
 
     useEffect(() => {
         if(progress.length === 0) loadProgresses();
     }, [progress.length, loadProgresses])
    
    return(
        <Table.Body>
            {progress.map((progress) => (
                <ProgramListItem key={progress.id} progress={progress} />
            ))}
        </Table.Body>
    )
})