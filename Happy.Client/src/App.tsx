import { useEffect, useState } from 'react';
import './App.css'
import axios from 'axios';
import {Header} from 'semantic-ui-react';

function App() {
  const [weeks, setWeeks] = useState([]);
  
  useEffect(() => {
    axios.get('http://localhost:8000/api/Weeks')
      .then(response => {
        setWeeks(response.data)
      })
  }, [])

  return (
    <>
      <div>
        <Header as='h2' icon='users' content='Happy'/>
        <h1>Happy</h1>
        <ul>
          {weeks.map((week:any) => (
            <li key={week.id}>
              {week.title}
            </li>
          ))}
        </ul>
      </div>
    </>
  )
}

export default App
