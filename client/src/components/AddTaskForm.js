import React, { useState } from "react"
import apiClient from "../api/apiClient"

function AddTaskForm(projectId) {
  const defaultObj = {
    name: '',
    type: '',
    projectId: 0,
    startdate: null,
    enddate: null
  }

  const [state, setState] = useState(defaultObj)

  const handleChange = event => {
    const value = event.target.value;
    setState({
       ...state, [event.target.name]: value
     });
  }

  const handleSubmit = event => {
    event.preventDefault();
    const task = {
      id: 0,
      name: state.name,
      type: state.type,
      projectId: projectId,
      startDate: state.startdate,
      endDate: state.enddate
    }
    apiClient.addTask(task)
      .then(()=>{
        window.location = "/" 
      })
  }

  return (
      <div className="my-6">
          <h1>Add New Task</h1><br />
          <form onSubmit = { handleSubmit }>
            <input className="border rounded-full py-2 px-4 my-2"  type="text" placeholder="Name" aria-label="Name" name="name" onChange={handleChange} onBlur={handleChange}/><br />
            <input className="border rounded-full py-2 px-4 my-2"  type="text" placeholder="Type" aria-label="Type"  name="type" onChange={handleChange} onBlur={handleChange} /><br />
            <input className="border rounded-full py-2 px-4 my-2"  type="text" placeholder="Start Date" aria-label="Start Date"  name="startdate" onChange={handleChange} onBlur={handleChange} /><br />
            <input className="border rounded-full py-2 px-4 my-2"  type="text" placeholder="End Date" aria-label="End Date"  name="enddate" onChange={handleChange} onBlur={handleChange} /><br />
            <button className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-4 ml-2" type="submit">Submit</button>
          </form>
      </div>
    );
}

export default AddTaskForm;