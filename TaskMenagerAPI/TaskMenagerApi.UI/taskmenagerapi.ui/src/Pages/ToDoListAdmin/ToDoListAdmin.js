import React, { useState, useEffect, useRef } from 'react'

import { updatedSuccess, deleteTodo, addOrUpdateTodo } from '../../services/todoservices'

import { fetchTasks } from '../../services/todoadminservices'

import {
	sortByDate,
	sortByStatus,
	sortById,
	searchTodo,
	handleKeyDown,
	successTodo,
	statusEnum,
	startEditing,
} from '../../utils/toDoUtils'

import { getToken, getUser } from '../../services/auth'

import format from 'date-fns/format'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'
import Table from 'react-bootstrap/Table'

import Dropdown from 'react-bootstrap/Dropdown'
import Container from 'react-bootstrap/Container'

import './ToDoListAdmin.css'

function ToDoListUser() {
	const [todo, setTodo] = useState([])
	const [originalTodo, setOriginalTodo] = useState([])
	const [isEditing, setIsEditing] = useState(false)
	const [editingTask, setEditingTask] = useState(null)
	const [searchResults, setSearchResults] = useState([])
	const [searchTerm, setSearchTerm] = useState('')
	const [userIdForTask, setUserIdForTask] = useState('')

	const [completed, setCompleted] = useState([])

	const title = useRef('')
	const description = useRef('')
	const dueDate = useRef('')
	const status = useRef('')

	useEffect(() => {
		const fetchData = async () => {
			try {
				await fetchTasks(setTodo, setOriginalTodo, setCompleted)
			} catch (error) {
				console.error('Error fetching data:', error)
			}
		}

		fetchData()
	}, [getToken()])

	const GetUserIdForTask = () => {
		if (editingTask) {
			const task = todo.find(task => task.id === editingTask)
			if (task) {
				return task.userId
			}
			return ''
		}
		return getUser()
	}

	useEffect(() => {
		setUserIdForTask(GetUserIdForTask())
	}, [editingTask])

	return (
		<>
			<section id='todosectionadmin'>
				<Form className='form-box--admin'>
					<Form.Group className='mb-3 form-group' controlId='UserId'>
						<Form.Label>UserId</Form.Label>

						<Form.Control type='text' placeholder='userId' value={userIdForTask} readOnly />
					</Form.Group>
					<div className='form-box--text'>
						<Form.Group className='mb-3 form-group' controlId='title'>
							<Form.Label>Title</Form.Label>
							<Form.Control type='title' placeholder='title' ref={title} />
						</Form.Group>

						<Form.Group className='mb-3 form-group' controlId='description'>
							<Form.Label>Description</Form.Label>
							<Form.Control as='textarea' rows={1} placeholder='description' ref={description} />
						</Form.Group>
					</div>
					<div className='form-bottom'>
						<Form.Group controlId='status' className='status'>
							<Form.Label>Status</Form.Label>
							<Form.Select ref={status}>
								<option value={statusEnum.InProgress}>InProgress</option>
								<option value={statusEnum.Blocked}>Blocked</option>
							</Form.Select>
						</Form.Group>

						<Form.Group className='date mb-3 form-group' controlId='duedate'>
							<Form.Label>Date</Form.Label>
							<Form.Control type='date' placeholder='description' ref={dueDate} />
						</Form.Group>
					</div>

					<Button
						variant='outline-light'
						className='BtnSubmit mb-3 w-100'
						type='submit'
						onClick={() =>
							addOrUpdateTodo(title, description, dueDate, isEditing, editingTask, todo, setTodo, setIsEditing, status)
						}
						onKeyDown={handleKeyDown}>
						Submit
					</Button>
					<div className='form-button--admin'>
						<Dropdown>
							<Dropdown.Toggle variant='success' className='BtnSort mb-3'>
								Sort
							</Dropdown.Toggle>

							<Dropdown.Menu>
								<Dropdown.Item href='#/action-1' onClick={() => sortByDate(todo, setTodo)}>
									Date
								</Dropdown.Item>
								<Dropdown.Item href='#/action-2' onClick={() => sortByStatus(todo, setTodo)}>
									Status
								</Dropdown.Item>
								<Dropdown.Item href='#/action-3' onClick={() => sortById(todo, setTodo)}>
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
							<Button
								variant='success'
								className='BtnSearch'
								onClick={() => searchTodo(searchTerm, originalTodo, setSearchResults)}>
								Search
							</Button>
						</div>
					</div>
				</Form>

				<Container className='todo-box--admin'>
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
														onClick={() =>
															successTodo(task.id, todo, setTodo, updatedSuccess, completed, setCompleted, statusEnum)
														}>
														Success
													</Button>
													<Button
														variant='outline-light'
														className='BtnEdit Btn'
														onClick={() =>
															startEditing(
																task.id,
																todo,
																setIsEditing,
																setEditingTask,
																title,
																description,
																dueDate,
																format,
																status
															)
														}>
														Edit
													</Button>{' '}
													<Button
														variant='outline-light'
														className='BtnDelete Btn'
														onClick={() => deleteTodo(task.id, todo, setTodo)}>
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
													<Button
														variant='outline-light'
														className='BtnDelete Btn'
														onClick={() => deleteTodo(task.id, todo, setTodo)}>
														Delete Delete
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
