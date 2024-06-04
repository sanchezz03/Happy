import { Table } from "semantic-ui-react";

export default function ProgressTableHeader(){
   return (
     <Table.Header>
        <Table.Row>
            <Table.HeaderCell>Weight</Table.HeaderCell>
            <Table.HeaderCell>Repetitions</Table.HeaderCell>
            <Table.HeaderCell>Date</Table.HeaderCell>
            <Table.HeaderCell>Rate of Perceived Exertion</Table.HeaderCell>
            <Table.HeaderCell>Exercise Name</Table.HeaderCell>
        </Table.Row>
    </Table.Header>
   )
}