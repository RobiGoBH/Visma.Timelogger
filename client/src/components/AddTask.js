import React from 'react';
import '../App.css';
import '../tailwind.generated.css';
import AddTaskForm from './AddTaskForm';

function AddTask(projectId) {  
  return (
      <>
          <header className="bg-gray-900 text-white flex items-center h-12 w-full">
              <div className="container mx-auto">
                  <a className="navbar-brand" href="/">Timelogger</a>
              </div>
          </header>
          
          <main>
              <div className="container mx-auto">                      
              <AddTaskForm projectId={projectId}/>
              </div>
          </main>
      </>
  );
}

export default AddTask;