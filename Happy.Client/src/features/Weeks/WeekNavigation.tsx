import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";
import { Button, Container, Grid, Header, Segment } from "semantic-ui-react";

export default observer(function WeekNavigation(){
    const {weekStore} = useStore();
    const {getWeek, week} = weekStore;
    const [currentWeek, setCurrentWeek] = useState(1);

    useEffect(() => {
        getWeek(currentWeek);
    },[currentWeek, getWeek])

    const handleNextWeek = () => {
        setCurrentWeek(prevWeek => prevWeek + 1);
      };
    
      const handlePreviousWeek = () => {
        setCurrentWeek(prevWeek => prevWeek - 1);
      };

    return(
        <Container text>
        <Header as="h1" textAlign="center">Week</Header>
        {week && (
            <Segment>
          <Grid columns={3} divided textAlign="center">
            <Grid.Row>
              <Grid.Column>
                <p><strong>Start Date</strong></p>
                <p>{new Date(week.startDate).toLocaleDateString()}</p>
              </Grid.Column>
              <Grid.Column>
                <p><strong>Week Number</strong></p>
                <p>{week.weekNumber}</p>
              </Grid.Column>
              <Grid.Column>
                <p><strong>End Date</strong></p>
                <p>{new Date(week.endDate).toLocaleDateString()}</p>
              </Grid.Column>
            </Grid.Row>
          </Grid>
        </Segment>
        )}
       <Grid columns={2} divided>
        <Grid.Row>
          <Grid.Column textAlign="center">
            <Button color="blue" onClick={handlePreviousWeek} disabled={currentWeek <= 1}>
              &lt; Previous Week
            </Button>
          </Grid.Column>
          <Grid.Column textAlign="center">
            <Button color="blue" onClick={handleNextWeek}>
              Next Week &gt;
            </Button>
          </Grid.Column>
        </Grid.Row>
      </Grid>
      </Container>
    )
})