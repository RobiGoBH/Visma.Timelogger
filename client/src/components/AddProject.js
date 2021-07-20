import React from 'react';
import '../App.css';
import '../tailwind.generated.css';
import AddProjectForm from './AddProjectForm';

function AddProject() {  
  return (
      <>
          <header className="bg-gray-900 text-white flex items-center h-12 w-full">
              <div className="container mx-auto">
                  <a className="navbar-brand" href="/">Timelogger</a>
              </div>
          </header>
          
          <main>
              <div className="container mx-auto">                      
              <AddProjectForm/>
              </div>
          </main>
      </>
  );
}

export default AddProject;
