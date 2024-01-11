import axios from 'axios'
import { getToken, getUser } from './auth'

const token = getToken()
const userId = getUser()

const apiUrl = 'https://localhost:7219/api/ToDo'

export async function deleteTask(taskId, tasks, setTasks) {
	try {
		await axios.delete(`${apiUrl}/${taskId}`)

		const updatedTasks = tasks.filter(task => task.id !== taskId)
		setTasks(updatedTasks)  
	} catch (error) {
		console.error('Error', error)
	}

}

// export async function deleteTodo(taskId, todo, setTodo) {
// 	try {
// 		await axios.delete(`${apiUrl}/${taskId}`)
// 		const updatedTasks = todo.filter(todo => todo.id !== taskId)
// 		setTodo(updatedTasks)
// 	} catch (error) {
// 		console.error('Error deleting task', error)
// 		throw error
// 	}
// }
