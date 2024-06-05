import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useStore } from "../../app/stores/store";
import { Table } from "semantic-ui-react";
import ProgressTableHeader from "./ProgressHeader";
import ProgressList from "./ProgressList";

export default observer(function ProgressDashboard() {
   const {progressStore} = useStore();
   const {loadProgresses, progress} = progressStore;

    useEffect(() => {
        if(progress.length === 0) loadProgresses();
    }, [progress.length, loadProgresses])

    return (
        <Table celled>
        <ProgressTableHeader/>
        <ProgressList progress={progress}/>
      </Table>
    )
})