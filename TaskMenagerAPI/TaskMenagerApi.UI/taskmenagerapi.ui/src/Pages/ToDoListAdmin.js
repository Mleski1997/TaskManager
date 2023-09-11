import axios from 'axios'
import React, { useState, useEffect, useRef } from 'react'

import format from 'date-fns/format'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'
import Table from 'react-bootstrap/Table'

import Dropdown from 'react-bootstrap/Dropdown'
import Container from 'react-bootstrap/Container'
import './css/ToDoListAdmin.css'

function ToDoListUser() {
	const [todo, setTodo] = useState([])
	const [originalTodo, setOriginalTodo] = useState([])
	const [isEditing, setIsEditing] = useState(false)
	const [editingTask, setEditingTask] = useState(null)
	const [searchResults, setSearchResults] = useState([])
	const [searchTerm, setSearchTerm] = useState('')
	const token = localStorage.getItem('token')
	const userId = localStorage.getItem('userId')
	const [userIdForTask, setUserIdForTask] = useState('')

	const [completed, setCompleted] = useState([])

	const title = useRef('')
	const description = useRef('')
	const dueDate = useRef('')
	const status = useRef('')
	const userName = useRef('')

	const statusEnum = {
		Success: 'Success',
		InProgress: 'InProgress',
		Blocked: 'Blocked',
	}

	useEffect(() => {
		const fetchTasks = async () => {
			try {
				const userId = localStorage.getItem('userId')
				const response = await axios.get(`https://localhost:7219/api/ToDo`, {
					headers: {
						Authorization: `Bearer ${token}`,
					},
				})

				if (response.status === 200) {
					const todoItems = response.data
					setTodo(todoItems)
					setOriginalTodo(todoItems)

					const completedTasks = JSON.parse(localStorage.getItem('completedTasks')) || []
					setCompleted(completedTasks)
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
		if (isEditing) {
			const updatedTask = {
				title: title.current.value,
				description: description.current.value,
				dueDate: dueDate.current.value.split('T')[0],
				status: status.current.value,
				userId: userId,
			}

			axios
				.put(`https://localhost:7219/api/ToDo/${editingTask}`, updatedTask, {
					headers: {
						Authorization: `Bearer ${token}`,
					},
				})
				.then(response => {
					const updatedTodo = [...todo]
					const taskIndex = updatedTodo.findIndex(task => task.id === editingTask)
					if (taskIndex !== -1) {
						updatedTodo[taskIndex] = response.data
						setTodo(updatedTodo)
					}

					setIsEditing(false)
					clearFormFields()
				})
				.catch(error => {
					console.error('Error editing task', error)
					console.error(error.response.data)
				})
		} else {
			var payload = {
				title: title.current.value,
				description: description.current.value,
				dueDate: dueDate.current.value.split('T')[0],
				status: status.current.value,
				userId: userId,
			}

			axios.post(`https://localhost:7219/api/ToDo?userId=${userId}`, payload).then(response => {
				setTodo([...todo, response.data])
			})
		}
	}

	const clearFormFields = () => {
		title.current.value = ''
		description.current.value = ''
		dueDate.current.value = ''
		status.current.value = ''
	}

	const deleteTodo = todoId => {
		axios.delete(`https://localhost:7219/api/ToDo/${todoId}`)
		const updatedTasks = todo.filter(task => task.id !== todoId)
		setTodo(updatedTasks)
	}

	const startEditing = todoId => {
		setIsEditing(true)
		setEditingTask(todoId)

		const taskToEdit = todo.find(task => task.id === todoId)
		if (taskToEdit) {
			title.current.value = taskToEdit.title
			description.current.value = taskToEdit.description
			dueDate.current.value = format(new Date(taskToEdit.dueDate), 'yyyy-MM-dd')
			status.current.value = taskToEdit.status
		}
	}

	const searchTodo = searchTerm => {
		if (typeof searchTerm === 'string') {
			const filteredTasks = originalTodo.filter(task => task.title.toLowerCase().includes(searchTerm.toLowerCase()))
			setSearchResults(filteredTasks)
		}
	}

	const successTodo = todoId => {
		const updatedCompletedTask = [...completed, todoId]
		setCompleted(updatedCompletedTask)

		localStorage.setItem('completedTasks', JSON.stringify(updatedCompletedTask))

		const taskIndex = todo.findIndex(task => task.id === todoId)
		if (taskIndex === -1) {
			return
		}

		const updatedTodo = [...todo]
		updatedTodo[taskIndex].status = statusEnum.Success

		axios
			.put(`https://localhost:7219/api/ToDo/${todoId}`, updatedTodo[taskIndex])
			.then(response => {
				setTodo(updatedTodo)
			})
			.catch(error => {
				console.error('Error updating task:', error)
			})
	}

	const sortByDate = () => {
		const sortedTodoItems = [...todo]
		sortedTodoItems.sort((a, b) => new Date(a.dueDate) - new Date(b.dueDate))

		setTodo(sortedTodoItems)
	}

	const sortByStatus = () => {
		const sortedTodoItems = [...todo]

		sortedTodoItems.sort((a, b) => {
			if (a.status > b.status) return 1
			if (a.status < b.status) return -1
			return 0
		})

		setTodo(sortedTodoItems)
	}

	const sortByUseID = () => {
		const sortedUserIdItems = [...todo]

		sortedUserIdItems.sort((a, b) => {
			if (a.userId > b.userId) return 1
			if (a.userId < b.userId) return -1
			return 0
		})
		setTodo(sortedUserIdItems)
	}

	const handleKeyDown = event => {
		if (event.key === 'Enter') {
			event.preventDefault()
			addTodo()
		}
	}

	const GetUserIdForTask = () => {
		if (editingTask) {
			const task = todo.find(task => task.id === editingTask)
			if (task) {
				return task.userId
			}
			return ''
		}
		return userId
	}

	useEffect(() => {
		setUserIdForTask(GetUserIdForTask())
	}, [editingTask])

	return (
		<>
			<section id='todosectiionAdmin'>
				

				<Form className='form-box--admin'>
					<Form.Group className='mb-3 form-group' controlId='UserId'>
						<Form.Label>UserId</Form.Label>

						<Form.Control type='text' placeholder='userId' value={userIdForTask} readOnly />
					</Form.Group>

					<Form.Group className='mb-3 form-group' controlId='title'>
						<Form.Label>Title</Form.Label>
						<Form.Control type='title' placeholder='title' ref={title} />
					</Form.Group>

					<Form.Group className='mb-3 form-group' controlId='description'>
						<Form.Label>Description</Form.Label>
						<Form.Control as='textarea' rows={3} placeholder='description' ref={description} />
					</Form.Group>
					<Form.Group controlId='status'>
						<Form.Label>Status</Form.Label>
						<Form.Select ref={status}>
							<option value={statusEnum.InProgress}>InProgress</option>
							<option value={statusEnum.Blocked}>Blocked</option>
						</Form.Select>
					</Form.Group>

					<Form.Group className='mb-3 form-group' controlId='duedate'>
						<Form.Label>Date</Form.Label>
						<Form.Control type='date' placeholder='description' ref={dueDate} />
					</Form.Group>

					<Button
						variant='outline-light'
						className='BtnSubmit mb-3 w-100'
						type='submit'
						onClick={addTodo}
						onKeyDown={handleKeyDown}>
						Submit
					</Button>

					<Dropdown>
						<Dropdown.Toggle variant='success' className='BtnSort mb-3'>
							Sort
						</Dropdown.Toggle>

						<Dropdown.Menu>
							<Dropdown.Item href='#/action-1' onClick={sortByDate}>
								Date
							</Dropdown.Item>
							<Dropdown.Item href='#/action-2' onClick={sortByStatus}>
								Status
							</Dropdown.Item>
							<Dropdown.Item href='#/action-3' onClick={sortByUseID}>
								UserID
							</Dropdown.Item>
						</Dropdown.Menu>
					</Dropdown>
					<div className='search-box'>
						<Form.Control
							type='text'
							placeholder='search'
							aria-label='Search'
							value={searchTerm}
							onChange={e => setSearchTerm(e.target.value)}></Form.Control>
						<Button variant='success' className='BtnSearch' onClick={() => searchTodo(searchTerm)}>
							Search
						</Button>
					</div>
				</Form>

				<Container className='todo-box'>
					{todo.length === 0 ? (
						<p>Add new task...</p>
					) : (
						<Table responsive hover borderless className='transparent-table'>
							<thead>
								<tr className='info-box'>
									<th>UserId</th>
									<th>Title</th>
									<th>Description</th>
									<th>Status</th>
									<th>Due Date</th>
									<th>Actions</th>
								</tr>
							</thead>
							<tbody>
								{searchResults.length === 0
									? todo.map((task, index) => (
											<tr key={task.id}>
												<td>{task.userId}</td>
												<td>{completed.includes(task.id) ? <s>{task.title}</s> : task.title}</td>
												<td className='text'>{task.description}</td>
												<td>{task.status}</td>
												<td>{format(new Date(task.dueDate), 'dd/MM/yyyy')}</td>
												<td className='button-box'>
													<Button
														variant='outline-light'
														className='BtnSuccess Btn'
														onClick={() => successTodo(task.id)}>
														Success
													</Button>
													<Button variant='outline-light' className='BtnEdit Btn' onClick={() => startEditing(task.id)}>
														Edit
													</Button>{' '}
													<Button variant='outline-light' className='BtnDelete Btn' onClick={() => deleteTodo(task.id)}>
														Delete
													</Button>
												</td>
											</tr>
									  ))
									: searchResults.map((task, index) => (
											<tr key={task.id}>
												<td>{index + 1}</td>
												<td>{completed.includes(task.id) ? <s>{task.title}</s> : task.title}</td>
												<td className='text'>{task.description}</td>
												<td>{task.status}</td>
												<td>{format(new Date(task.dueDate), 'dd/MM/yyyy')}</td>
												<td className='button-box'>
													<Button
														variant='outline-light'
														className='BtnSuccess Btn'
														onClick={() => successTodo(task.id)}>
														Success
													</Button>
													<Button variant='outline-light' className='BtnEdit Btn' onClick={() => startEditing(task.id)}>
														Edit
													</Button>{' '}
													<Button variant='outline-light' className='BtnDelete Btn' onClick={() => deleteTodo(task.id)}>
														Delete
													</Button>
												</td>
											</tr>
									  ))}
							</tbody>
						</Table>
					)}
				</Container>
			</section>
		</>
	)
}

export default ToDoListUser
