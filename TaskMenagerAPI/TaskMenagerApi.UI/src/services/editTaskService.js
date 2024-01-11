import axios from 'axios'
import { getToken, getUser } from './auth'
import format from 'date-fns/format'
import { Col } from 'react-bootstrap'

const token = getToken()
const userId = getUser()

const apiUrl = 'https://localhost:7219/api/ToDo'

export async function editSelectedTask(
	taskId,
	title,
	description,
	dueDate,
	status,
	tasks,
	setTasks,
	userIds,
	editingTaskId,
	setEditTaskId
) {
	try {
		const updatedTask = {
			title: title.current.value,
			description: description.current.value,
			dueDate: dueDate.current.value,
			status: status.current.value,
		}

		console.log(updatedTask)

		const response = await axios.put(`https://localhost:7219/api/ToDo/${taskId}`, updatedTask, {
			headers: {
				Authorization: `Bearer ${token}`,
			},
		})

		if (response.status === 200) {
			console.log('ok')
			const updatedTask = [...tasks]
			const taskIndex = updatedTask.findIndex(task => task.id === editingTaskId)
			if (taskIndex !== -1) {
				updatedTask[taskIndex] = response.data
				setTasks(updatedTask)
				setEditTaskId(false)
			}
		} else {
			console.log(response)
		}
	} catch (error) {
		console.error('Error adding task', error)
	}
}
