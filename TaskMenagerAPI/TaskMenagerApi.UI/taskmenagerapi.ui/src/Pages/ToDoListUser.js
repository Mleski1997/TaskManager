import axios from 'axios'
import { setHours } from 'date-fns'
import React, { useState, useEffect, useRef } from 'react'
import Table from 'react-bootstrap/Table'
import format from 'date-fns/format'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'
import { json } from 'react-router-dom'

function TaskList() {
	const [todo, setTodo] = useState([])
	const token = localStorage.getItem('token')
	const userId = localStorage.getItem('userId')

	const [completed, setCompleted] = useState([])

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
					setTodo(response.data)

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
		var payload = {
			title: title.current.value,
			description: description.current.value,
			dueDate: dueDate.current.value,
			status: status.current.value,
			userId: userId,
			//dueDate: format(new Date(dueDate.current.value), 'yyyy-MM-dd'),
		}

		axios.post(`https://localhost:7219/api/ToDo?userId=${userId}`, payload).then(response => {
			setTodo([...todo, response.data])
		})
	}

	const deleteTodo = todoId => {
		axios.delete(`https://localhost:7219/api/ToDo/${todoId}`)
		const updatedTasks = todo.filter(todo => todo.id !== todoId)
		setTodo(updatedTasks)
	}

	const successTodo = todoId => {
		const updatedCompletedTask = [...completed, todoId]
		setCompleted(updatedCompletedTask)

		localStorage.setItem('completedTasks', JSON.stringify(updatedCompletedTask))

        const taskIndex = todo.findIndex(task => task.id === todoId);
    if (taskIndex === -1) {
        return; // T
    }

        const updatedTodo = [...todo];
        updatedTodo[taskIndex].status = statusEnum.Success;
    

        axios.put(`https://localhost:7219/api/ToDo/${todoId}`, updatedTodo[taskIndex])
        .then(response => {
            setTodo(updatedTodo);
        })
        .catch(error => {
            console.error('Error updating task:', error);
        });
	}

    const handleKeyDown = event => {
		if (event.key === 'Enter') {
			event.preventDefault()
			addTodo()
		}
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
						<option value={statusEnum.InProgress}>InProgress</option>
						<option value={statusEnum.Blocked}>Blocked</option>
					</Form.Select>
				</Form.Group>

				<Form.Group className='mb-3' controlId='duedate'>
					<Form.Label>Date</Form.Label>
					<Form.Control type='date' placeholder='description' ref={dueDate} />
				</Form.Group>

				<Button variant='primary' type='submit' onClick={addTodo} onKeyDown={handleKeyDown}>
					Submit
				</Button>
			</Form>

			<h2>Task List</h2>

            {todo.length === 0 ? (
                <p>Add new task...</p>
            ) : (
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
					{todo.map((todo, index) => (
						<tr key={todo.id}>
							<td>{index + 1}</td>
							<td>{completed.includes(todo.id) ? <s>{todo.title}</s> : todo.title}</td>
							<td>{completed.includes(todo.id) ? <s>{todo.description}</s> : todo.description}</td>
							<td>{todo.status}</td>
							<td>{format(new Date(todo.dueDate), 'dd/MM/yyyy')}</td>
							<td>
								<Button variant='success' onClick={() => successTodo(todo.id)}>
									Success
								</Button>
								<Button variant='warning'>Edit</Button>{' '}
								<Button variant='danger' onClick={() => deleteTodo(todo.id)}>
									Delete
								</Button>
							</td>
						</tr>
					))}
				</tbody>
            
			</Table>
            )}
		</>
	)
}

export default TaskList
