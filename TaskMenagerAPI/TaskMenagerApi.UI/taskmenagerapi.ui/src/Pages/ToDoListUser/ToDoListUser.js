import React, { useState, useEffect, useRef } from 'react'
import { getToken, getUser } from '../../services/auth'

import todoUser from '../../components/shared/todoUserList'
import todoPanel from '../../components/shared/todoPanel'

import { updatedSuccess, deleteTodo, addOrUpdateTodo } from '../../services/todoservices'
import { fetchTasksUser } from '../../services/todouserservices'

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

import format from 'date-fns/format'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'
import Table from 'react-bootstrap/Table'

import Dropdown from 'react-bootstrap/Dropdown'

import './ToDoListUser.css'

function ToDoListUser() {
	const [todo, setTodo] = useState([])
	const [originalTodo, setOriginalTodo] = useState([])
	const [isEditing, setIsEditing] = useState(false)
	const [editingTask, setEditingTask] = useState(null)
	const [searchResults, setSearchResults] = useState([])
	const [searchTerm, setSearchTerm] = useState('')

	const [completed, setCompleted] = useState([])
	const title = useRef('')
	const description = useRef('')
	const dueDate = useRef('')
	const status = useRef('')

	useEffect(() => {
		const fetchData = async () => {
			try {
				await fetchTasksUser(setTodo, setOriginalTodo, setCompleted)
			} catch (error) {
				console.error('Error fetching data:', error)
			}
		}

		fetchData()
	}, [getToken()])

	return (
		<>
			<section id='todosection'>
				<div className='todo-img'>
					<div className='todo-img--shadow'></div>
				</div>

				<Form className='form-box'>
					<Form.Group className='mb-3 form-group' controlId='title'>
						<Form.Label>Title</Form.Label>
						<Form.Control type='title' placeholder='title' ref={title} />
					</Form.Group>

					<Form.Group className='mb-3 form-group' controlId='description'>
						<Form.Label>Description</Form.Label>
						<Form.Control as='textarea' rows={3} placeholder='description' ref={description} />
					</Form.Group>
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

				<div className='todo-box'>
					{todo.length === 0 ? (
						<p>Add new task...</p>
					) : (
						<Table responsive hover borderless className='transparent-table'>
							<thead>
								<tr className='info-box'>
									<th>Id</th>
									<th>Title</th>
									<th>Description</th>
									<th>Status</th>
									<th>Due Date</th>
									<th>Actions</th>
								</tr>
							</thead>
							<tbody>
								{searchResults.length === 0
									? todo.map((task, index) =>
											todoUser(
												task,
												index,
												completed,
												format,
												Button,
												successTodo,
												todo,
												setTodo,
												updatedSuccess,
												setCompleted,
												statusEnum,
												startEditing,
												setIsEditing,
												setEditingTask,
												title,
												description,
												dueDate,
												status,
												deleteTodo
											)
									  )
									: searchResults.map((task, index) =>
											todoUser(
												task,
												index,
												completed,
												format,
												Button,
												successTodo,
												todo,
												setTodo,
												updatedSuccess,
												setCompleted,
												statusEnum,
												startEditing,
												setIsEditing,
												setEditingTask,
												title,
												description,
												dueDate,
												status,
												deleteTodo
											)
									  )}
							</tbody>
						</Table>
					)}
				</div>
			</section>
		</>
	)
}

export default ToDoListUser
