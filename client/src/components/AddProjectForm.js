import React, { useState } from "react"
import apiClient from "../api/apiClient"

function AF() {
  const defaultObj = {
    name: '',
    deadline: null,
    status: 0,
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
    const project = {
      id: 0,
      name: state.name,
      deadline: state.deadline,
      status: parseInt(!state.status? 0 : state.status),
      startDate: state.startdate,
      endDate: state.enddate
    }
    apiClient.addProject(project)
      .then(()=>{
        window.location = "/" 
      })
  }

  return (
      <div className="my-6">
          <h1>Add New Project</h1><br />
          <form onSubmit = { handleSubmit }>
            <input className="border rounded-full py-2 px-4 my-2"  type="text" placeholder="Name" aria-label="Name" name="name" onChange={handleChange} onBlur={handleChange}/><br />
            <input className="border rounded-full py-2 px-4 my-2"  type="text" placeholder="Deadline" aria-label="Deadline"  name="deadline" onChange={handleChange} onBlur={handleChange} /><br />
            <select className="border rounded-full py-2 px-4 my-2" name="status" onChange={handleChange} onClick={handleChange} onBlur={handleChange} >
              <option value="0" defaultValue>Open</option>
              <option value="1">Closed</option>
            </select><br />
            <input className="border rounded-full py-2 px-4 my-2"  type="text" placeholder="Start Date" aria-label="Start Date"  name="startdate" onChange={handleChange} onBlur={handleChange} /><br />
            <input className="border rounded-full py-2 px-4 my-2"  type="text" placeholder="End Date" aria-label="End Date"  name="enddate" onChange={handleChange} onBlur={handleChange} /><br />
            <button className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-4 ml-2" type="submit">Submit</button>
          </form>
      </div>
    );
}

export default AF;