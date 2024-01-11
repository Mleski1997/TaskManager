import React, { useState, useRef } from 'react'
import { Form, Button } from 'react-bootstrap'
import { statusEnum } from '../../utils/toDoUtils'
import { addTask } from '../../services/newtaskservices'
import './NewTask.css'
import { de } from 'date-fns/locale'
import { useUsers } from '../../hooks/useUsers'

function ToDoListUser() {
	const { users } = useUsers()
	const title = useRef(null)
	const description = useRef(null)
	const dueDate = useRef(null)
	const status = useRef(null)
	const user = useRef([])
	const [tasks, setTasks] = useState([])
	const [selectedUsers, setSelectedUsers] = useState()

	const [isSuccessful, setIsSuccessful] = useState(false)

	const showSuccess = () => {
		setIsSuccessful(true)

		// Po 3 sekundach usuń klasę successful-animate
		setTimeout(() => {
			setIsSuccessful(false)
		}, 3000)
	}

	const handleAddTodoClick = async () => {
		const selectedOptions = user.current ? [...user.current.options] : []
		const selectedUsers = selectedOptions.filter(option => option.selected).map(option => option.value)

		try {
			addTask(title, description, dueDate, status, selectedUsers, tasks, setTasks, showSuccess)
			
		} catch {
			console.log('something went wrong')
		}
	}

	return (
		<>
			<div className='newTask'>
				<div className='newTask-container'>
					<div className='newTask-top'>
						<h3 className='newTask-title'>New Task</h3>
					</div>
					<div className='newTask-box'>
						<Form className='newTask-form'>
							<Form.Group className='mb-3 form-group newTask-input' controlId='title'>
								<Form.Label>Title</Form.Label>
								<Form.Control type='text' placeholder='Title' ref={title} />
							</Form.Group>
							<Form.Group className='mb-3 newTask-input' controlId='description'>
								<Form.Label>Task Description</Form.Label>
								<Form.Control as='textarea' rows={5} placeholder='Enter Description' ref={description} />
							</Form.Group>
							<Form.Group controlId='status' className='newTask-input'>
								<Form.Label>Status</Form.Label>
								<Form.Select ref={status}>
									<option value='InProgress'>InProgress</option>
									<option value='Blocked'>Blocked</option>
								</Form.Select>
							</Form.Group>
							<Form.Group className='mb-3 newTask-input' controlId='dueDate'>
								<Form.Label>Due Date</Form.Label>
								<Form.Control type='date' placeholder='Due Date' ref={dueDate} />
							</Form.Group>
							<Form.Group className='mb-3 newTask-input' controlId='users'>
								<Form.Label>Users</Form.Label>
								<Form.Control as='select' multiple ref={user}>
									{users.map(user => (
										<option key={user.id} value={user.id}>
											{user.userName}
										</option>
									))}
								</Form.Control>
							</Form.Group>

							<a className='custom-button' type='button' onClick={handleAddTodoClick}>
								Submit
							</a>
						</Form>
					</div>
					<div className={`Successful-box ${isSuccessful ? 'successful-animate' : ''}`}>
						<p className='Successful-text'>Successful</p>
					</div>
				</div>
			</div>
		</>
	)
}

export default ToDoListUser
