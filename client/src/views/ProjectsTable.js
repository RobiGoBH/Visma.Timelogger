import React from "react";
import apiClient from "../api/apiClient"

export const ProjectsTable =  ({ projectsData, propsObj }) => { 

  const handleTasksClick = (event) => {
    const id = event.target.id;
    propsObj.history.push(`tasks?projectId=${id}`);
  }; 

  const handleEditClick = (event) => {
    const id = event.target.id;
    propsObj.history.push(`projects/${id}`);
  };

  const handleAddClick = (event) => {
    propsObj.history.push(`addproject`);
  };

  const handleDeleteClick = (event) => {
    const id = event.target.id;
  };

  return (
    <>
      <div className="flex items-center my-6">
				<div className="w-1/2">
					<button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={handleAddClick}>Add Project</button>
				</div>

				<div className="w-1/2 flex justify-end">
					<form>
						<input className="border rounded-full py-2 px-4" type="search" placeholder="Search" aria-label="Search" />
						<button className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-4 ml-2" type="submit">Search</button>
					</form>
				</div>
			</div>
      <div className="projects-container">
      <table className="table-fixed w-full">
        <thead className="bg-gray-200">
            <tr>
                <th className="border px-4 py-2"></th>
                <th className="border px-4 py-2 w-12">#</th>
                <th className="border px-4 py-2">Name</th>
                <th className="border px-4 py-2">Deadline</th>
                <th className="border px-4 py-2">Status</th>
                <th className="border px-4 py-2">StartDate</th>
                <th className="border px-4 py-2">EndDate</th>
                <th className="border px-1s py-2 w-16"></th>
            </tr>
        </thead>
        <tbody>
            {  projectsData.length === 0?   <tr>
                                                  <td colSpan="8" className="border px-4 py-2 rowAlign">
                                                      No Projects Found
                                                  </td>
                                            </tr>
              :        
                projectsData.map((data) => (
                  <tr key={data.id}>
                    <td className="border px-5 py-2">
                      <button className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-5 ml-1" type="button" id={data.id} onClick={handleEditClick}>Edit</button>
                      <button className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-5 ml-1" type="button" id={data.id} onClick={handleTasksClick}>Tasks</button>
                    </td>
                    <td className="border px-4 py-2 w-12">
                      {data.id}
                    </td>
                    <td className="border px-4 py-2">
                      {data.name}
                    </td>
                    <td className="border px-4 py-2">
                      {data.deadline}
                    </td>
                    <td className="border px-4 py-2">
                      {data.status}
                    </td>
                    <td className="border px-4 py-2">
                      {data.startDate}
                    </td>
                    <td className="border px-4 py-2">
                      {data.endDate}
                    </td>
                    <td className="border px-0 py-2">
                      <button className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-2 ml-0" type="button" id={data.id} onClick={handleDeleteClick}>Delete</button>
                    </td>
                  </tr>)
                )}
        </tbody>
      </table>
      </div>
    </>
  );
};

