import React, { useState, useRef, useEffect } from 'react'
import './TaskList.css'
import Card from 'react-bootstrap/Card'
import { useTasks } from '../../hooks/useTasks'
import { deleteTask } from '../../services/deleteTaskService'
import format from 'date-fns/format'
import Row from 'react-bootstrap/Row'
import Button from 'react-bootstrap/Button'
import { Form } from 'react-bootstrap'
import { editSelectedTask } from '../../services/editTaskService'
import { startEditing } from '../.././utils/toDoUtils'
import Dropdown from 'react-bootstrap/Dropdown'
import { sortByDate, sortByStatus, searchTodo } from '../.././utils/toDoUtils'

function TaskList() {
	const { tasks, setTasks } = useTasks()
	const [selectedCardId, setSelectedCardId] = useState(null)
	const [editTaskId, setEditTaskId] = useState(null)
	const [editingTaskId, setEditingTaskId] = useState(null)
	const [searchQuery, setSearchQuery] = useState('')
	const [foundTask, setFoundTask] = useState([])

	const title = useRef(null)
	const description = useRef(null)
	const dueDate = useRef(null)
	const status = useRef(null)
	

	const handleClick = taskid => {
		setSelectedCardId(prevId => (prevId === taskid ? null : taskid))
	}

	const DeleteClick = taskId => {
		deleteTask(taskId, tasks, setTasks)
	}

	const handleEditClick = taskId => {
		setEditingTaskId(taskId)
		valueToEdit(taskId, title, description, dueDate, status)
	}

	const handleCloseEdit = () => {
		setEditingTaskId(null)
	}

	const valueToEdit = (taskId, title, description, dueDate, status) => {
		const taskToEdit = tasks.find(t => t.id === taskId)
		if (taskToEdit) {
			title.current.value = taskToEdit.title
			description.current.value = taskToEdit.description
			dueDate.current.value = format(new Date(taskToEdit.dueDate), 'yyyy-MM-dd')
			status.current.value = taskToEdit.status
		}
	}

	const updatedTaskClick = () => {
		if (editingTaskId && title && description && dueDate && status) {
			console.log('Due Date Before Format:', dueDate.current.value)
			console.log('Due Date Type Before Format:', typeof dueDate.current.value)
			editSelectedTask(editingTaskId, title, description, dueDate, status, tasks, setTasks)
			setEditingTaskId(null)
		}
	}

	const searchTask = () => {
        if (searchQuery.length === 0) {
            setFoundTask(tasks); 
        } else {
            const found = tasks.filter(task => 
                task.title.toLowerCase().includes(searchQuery.toLowerCase()))
            setFoundTask(found); 
        }
    };

	useEffect(() => {
		searchTask();
	}, [searchQuery, tasks])

	return (
		<>
			<div className='tasks'>
				<div className='tasks-container'>
					<h3 className='tasks-title'>Tasks</h3>
					<Dropdown>
						<Dropdown.Toggle variant='secondary' className='BtnSort mb-3'>
							Sort
						</Dropdown.Toggle>

						<Dropdown.Menu>
							<Dropdown.Item href='#/action-1' onClick={() => sortByDate(tasks, setTasks)}>
								Date
							</Dropdown.Item>
							<Dropdown.Item href='#/action-2' onClick={() => sortByStatus(tasks, setTasks)}>
								Status
							</Dropdown.Item>
						</Dropdown.Menu>
					</Dropdown>
					<div className='search-box'>
						<p>Search task by title</p>
						<input type='text' id='searchInput' value={searchQuery} onChange={e => setSearchQuery(e.target.value)} />
					</div>
					
					<div className='tasks-box'>
						<div className={`tasks-edit ${editingTaskId ? 'show' : ''}`}>
							<Form className={`editTask-form`}>
								<h2>Edit Task</h2>
								<div className='close-btn show' onClick={handleCloseEdit}></div>
								<Form.Group className='mb-3 form-group newTask-input' controlId='title'>
									<Form.Label>Title</Form.Label>
									<Form.Control type='text' placeholder='Title' ref={title} />
								</Form.Group>
								<Form.Group className='mb-3 editTask-input' controlId='description'>
									<Form.Label>Task Description</Form.Label>
									<Form.Control as='textarea' rows={16} placeholder='Enter Description' ref={description} />
								</Form.Group>
								<Form.Group controlId='status' className='editTask-input'>
									<Form.Label>Status</Form.Label>
									<Form.Select ref={status}>
										<option value='InProgress'>InProgress</option>
										<option value='Blocked'>Blocked</option>
									</Form.Select>
								</Form.Group>
								<Form.Group className='mb-3 editTask-input' controlId='dueDate'>
									<Form.Label>Due Date</Form.Label>
									<Form.Control type='date' placeholder='Due Date' ref={dueDate} required />
								</Form.Group>
								<button
									className='card-btn'
									onClick={() => updatedTaskClick(editingTaskId, title, description, dueDate, status, tasks, setTasks)}>
									Submit
								</button>
							</Form>
						</div>
						<Row xs={1} md={2} className='g-2'>
						{(foundTask.length === 0 ? tasks : foundTask).map(task => (
								<Card key={task.id} className={selectedCardId === task.id ? 'expended' : ''}>
									<Card.Body>
										<div className='card-top'>
											<div
												className={`close-btn ${selectedCardId === task.id ? 'show' : ''}`}
												onClick={() => handleClick(task.id)}></div>
											<Card.Title>{task.title}</Card.Title>
											<Card.Text>{task.description}</Card.Text>
										</div>

										<div className='card-bottom'>
											<Card.Text>{task.status}</Card.Text>
											<Card.Text className='date'>{format(new Date(task.dueDate), 'yyyy-MM-dd')}</Card.Text>
											<div className='card-bottom_options'>
												<button className='card-btn' onClick={() => handleClick(task.id)}>
													Show More{' '}
												</button>
												<Button className='card-btn' onClick={() => DeleteClick(task.id)}>
													Delete
												</Button>
												<Button className='card-btn' onClick={() => handleEditClick(task.id)}>
													Edit
												</Button>
											</div>
										</div>
									</Card.Body>
								</Card>
							))}
						</Row>
					</div>
				</div>
			</div>
		</>
	)
}

export default TaskList
