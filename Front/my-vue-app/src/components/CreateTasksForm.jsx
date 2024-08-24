import { Input, Textarea, Button } from "@chakra-ui/react";
import { useState } from 'react';

export default function CreateTasksForm({ onCreate }) {
  const currentDate = new Date().toISOString(); 
  const [task, setTasks] = useState({ title: '', description: '', date: currentDate });

  const onSubmit = (e) => {
    e.preventDefault();
    onCreate(task);
    setTasks({ title: '', description: '',date: currentDate}); // Сбрасываем поля после создания задачи
  };

  return (
    <form onSubmit={onSubmit} className='w-full flex flex-col gap-3'> 
      <h3>Create Notes</h3>
      <Input
        placeholder="Title"
        value={task.title}
        onChange={(e) => setTasks({ ...task, title: e.target.value })}
      />
      <Textarea
        placeholder="Description"
        value={task.description}
        onChange={(e) => setTasks({ ...task, description: e.target.value })}
      />
      <Button colorScheme='teal' type="submit">Add Note</Button>
    </form>
  );
}
