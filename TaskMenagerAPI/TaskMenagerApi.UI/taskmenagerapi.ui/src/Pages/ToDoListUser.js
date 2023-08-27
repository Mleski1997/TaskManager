import axios from 'axios'
import { setHours } from 'date-fns'
import React, { useState, useEffect, useRef } from 'react'
import Table from 'react-bootstrap/Table'
import format from 'date-fns/format'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'

function TaskList() {
	const [tasks, setTasks] = useState([])
	const token = localStorage.getItem('token')
	const userId = localStorage.getItem('userId')

	const [taskCount, setTaskCount] = useState(0)

	const title = useRef('')
	const description = useRef('')
	const dueDate = useRef('')
	const status = useRef('')

	const statusEnum = {
		Success: 'Success',
		InProgress: 'InProgress',
		Blocked: 'Blocked',
	}

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

	const addTodo = () => {
		var payload = {
			title: title.current.value,
			description: description.current.value,
			dueDate: dueDate.current.value,
			status: status.current.value,
			userId: userId,
			//dueDate: format(new Date(dueDate.current.value), 'yyyy-MM-dd'),
		}

		axios.post(`https://localhost:7219/api/ToDo?userId=${userId}`, payload).then(response => {
			setTaskCount(taskCount + 1)
			setTasks([...tasks, response.data])
		})
	}

	return (
		<>
			<Form>
				<Form.Group className='mb-3' controlId='title'>
					<Form.Label>Title</Form.Label>
					<Form.Control type='title' placeholder='title' ref={title} />
				</Form.Group>

				<Form.Group className='mb-3' controlId='description'>
					<Form.Label>Description</Form.Label>
					<Form.Control type='description' placeholder='description' ref={description} />
				</Form.Group>
				<Form.Group controlId='status'>
					<Form.Label>Status</Form.Label>
					<Form.Select ref={status}>
						<option value={statusEnum.Success}>Success</option>
						<option value={statusEnum.InProgress}>InProgress</option>
						<option value={statusEnum.Blocked}>Blocked</option>
					</Form.Select>
				</Form.Group>

				<Form.Group className='mb-3' controlId='duedate'>
					<Form.Label>Date</Form.Label>
					<Form.Control type='date' placeholder='description' ref={dueDate} />
				</Form.Group>

				<Button variant='primary' type='submit' onClick={addTodo}>
					Submit
				</Button>
			</Form>

			<h2>Task List</h2>
			<Table responsive>
				<thead>
					<tr>
						<th>Id</th>
						<th>Title</th>
						<th>Description</th>
						<th>Status</th>
						<th>Due Date</th>
					</tr>
				</thead>
				<tbody>
					{tasks.map(tasks => (
						<tr key={tasks.id}>
							<td>{taskCount}</td>
							<td>{tasks.title}</td>
							<td>{tasks.description}</td>
							<td>{tasks.status}</td>
							<td>{format(new Date(tasks.dueDate), 'dd/MM/yyyy')}</td>
							<td>
								<Button variant='success'>Success</Button> <Button variant='warning'>Edit</Button>{' '}
								<Button variant='danger'>Delete</Button>
							</td>
						</tr>
					))}
				</tbody>
			</Table>
		</>
	)
}

export default TaskList
