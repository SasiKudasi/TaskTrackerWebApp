import './App.css';  
import CreateTasksForm from './components/CreateTasksForm';
import TasksLists from './components/Tasks';
import SelectFilters from './components/Filters';
import { useEffect, useState } from 'react';
import { createTask, task } from './services/task';

function App() {
  const [tasks, setTasks] = useState([]);
  const [filters, setFilters] = useState({ 
    sortItem: 'date',
    sortOrder: 'desc'
  });

  useEffect(() => {
    const fetchData = async () => {
      try {
        let fetchedTasks = await task(filters);
        setTasks(fetchedTasks);
      } catch (error) {
        console.error("Error fetching tasks:", error);
      }
    };

    fetchData();
  }, [filters]);

  const onCreate = async (newTask) => {
    await createTask(newTask)
    let fetchedTasks = await task(filters);
    setTasks(fetchedTasks);

  }

  return (
    
    
    <section className='p-8 flex flex-row justify-start items-start gap-12'>
      <div className='flex flex-col w-1/3 gap-10'>
        <CreateTasksForm onCreate = {onCreate}/>
        <SelectFilters filters={filters} setFilters={setFilters}/>
      </div>

      <ul className='flex flex-col gap-5 flex-1'>
        {tasks.map((n) => (
          <li key={n.id}>
            <TasksLists title={n.title} description={n.description} date={n.date}/>
            </li>
        ))}
      </ul>
    </section>
  );
}

export default App;
