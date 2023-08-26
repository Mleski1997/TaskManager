import axios from 'axios'
import { setHours } from 'date-fns'
import React, { useState, useEffect, useRef } from 'react'
import Table from 'react-bootstrap/Table'
function TaskList() {
	const [tasks, setTasks] = useState([])
	const token = localStorage.getItem('token')
	const userId = localStorage.getItem('userId')

	useEffect(() => {
		const fetchTasks = async () => {
			try {
				const response = await axios.get(`https://localhost:7219/api/User/${userId}/Todoes`, {
					headers: {
						Authorization: `Bearer ${token}`,
					},
				})

				if (response.status === 200) {
					setTasks(response.data)
				} else {
					console.error('Failed to fetch tasks')
				}
			} catch (error) {
				console.error('Error:', error)
			}
		}

		fetchTasks()
	}, [token])

	return (
		<div>
			<h2>Task List</h2>
			<ul>
				{tasks.map(task => (
					<li key={task.id}>{task.title}</li>
				))}
			</ul>
		</div>
	)
}

export default TaskList
