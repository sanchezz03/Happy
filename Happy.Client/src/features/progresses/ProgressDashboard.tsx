import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useStore } from "../../app/stores/store";
import { Table } from "semantic-ui-react";
import { format } from "date-fns";
import ProgressTableHeader from "./ProgressHeader";

export default observer(function ProgressDashboard() {
   const {progressStore} = useStore();
   const {loadProgresses, progress} = progressStore;

    useEffect(() => {
        if(progress.length === 0) loadProgresses();
    }, [progress.length, loadProgresses])

    return (
        <Table celled>
        <ProgressTableHeader/>
        <Table.Body>
          {progress.map((progress) => (
            <Table.Row key={progress.id}>
              <Table.Cell>{progress.weight}</Table.Cell>
              <Table.Cell>{progress.numberOfRepetitions}</Table.Cell>
              <Table.Cell>{format (progress.date!, 'dd MMM yyyy h:mm aa')}</Table.Cell>
              <Table.Cell>{progress.rateOfPerceivedExertion!}</Table.Cell>
              <Table.Cell>{progress.exerciseName}</Table.Cell>
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    )
})