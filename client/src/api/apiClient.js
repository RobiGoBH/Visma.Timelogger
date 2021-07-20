import axios from 'axios'

const baseUrl = 'http://localhost:3001/api';
const projectsUrl = `${baseUrl}/projects`;
const tasksUrl = `${baseUrl}/tasks`;
const axiosConfig = {
    headers: {
        'content-type': 'application/json'
    }
  };
const getAllProjects = () => {
    return axios.get(projectsUrl);
}

const getProjectById = (id) => {
    return axios.get(projectsUrl, id);
}

const addProject = (project) => {   
    return axios.post(projectsUrl, JSON.stringify(project), axiosConfig);
}

const updateProject = (project) => {
    return axios.put(projectsUrl, JSON.stringify(project), axiosConfig);
}

const deleteProjectById = (id) => {
    return axios.delete(projectsUrl, id);
}

const getAllTasksByProjectId = (id) => {
    return axios.get(projectsUrl, id);
}

const getTaskById = (id) => {
    return axios.get(projectsUrl, id);
}

const addTask = (task) => {
    return axios.post(tasksUrl, JSON.stringify(task), axiosConfig);
}

const updateTask = (task) => {
    return axios.put(tasksUrl, JSON.stringify(task), axiosConfig);
}

const deleteTask = (id) => {
    return axios.delete(tasksUrl, id);
}

const apiClient = {
    getAllProjects,
    getProjectById,
    addProject,
    updateProject,
    deleteProjectById,
    getAllTasksByProjectId,
    getTaskById,
    addTask,
    updateTask,
    deleteTask
};

export default apiClient;
