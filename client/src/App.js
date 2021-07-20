import React, { useEffect, useState } from 'react';
import './App.css';
import {ProjectsTable} from "./views/ProjectsTable";
import withDataLoading from './components/withDataLoading';
import apiClient from "./api/apiClient"
import './tailwind.generated.css';


const App = (props) => {
  const DataLoading = withDataLoading(ProjectsTable);
  const [appState, setAppState] = useState({
    loading: true,
    projects: [],
    props: null
  });
  useEffect(() => {
    setAppState({ loading: true });
    apiClient.getAllProjects().then((projects) => {
      setAppState({ loading: false, projects: projects.data, props: props });
    })
    .catch(error => {
      if (error.response) {
        console.log(error.responderEnd);
      }
    });    
  }, [props]);
  console.log(appState.props);
  return (
      <>
          <header className="bg-gray-900 text-white flex items-center h-12 w-full">
              <div className="container mx-auto">
                  <a className="navbar-brand" href="/">Timelogger</a>
              </div>
          </header>
          
          <main>
              <div className="container mx-auto">                      
              <DataLoading isLoading={appState.loading} projectsData={appState.projects} propsObj = {appState.props}/>
              </div>
          </main>
      </>
  );
}

export default App;
