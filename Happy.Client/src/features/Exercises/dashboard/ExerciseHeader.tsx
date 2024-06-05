import { Table } from "semantic-ui-react";

export default function ExerciseTableHeader(){
   return (
    <Table.Header>
    <Table.Row>
      <Table.HeaderCell>Name</Table.HeaderCell>
      <Table.HeaderCell>Description</Table.HeaderCell>
      <Table.HeaderCell>Weight</Table.HeaderCell>
      <Table.HeaderCell>Number of Repetitions</Table.HeaderCell>
      <Table.HeaderCell>Actions</Table.HeaderCell>
    </Table.Row>
  </Table.Header>
   )
}