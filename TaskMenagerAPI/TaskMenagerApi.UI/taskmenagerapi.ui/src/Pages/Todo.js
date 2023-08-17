import axios from 'axios'
import { useEffect, useRef, useState } from 'react'
import { Table } from 'reactstrap'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'

import { func } from 'prop-types'
import { Link } from 'react-router-dom'

function GetAllTodoes() {
	const [todo, setToDo] = useState([])

	const title = useRef('')
	const description = useRef('')
	const dueDate = useRef('')
	const userId = useRef('')

	const fetchTodos = () => {
		axios.get('https://localhost:7219/api/ToDo').then(response => {
			setToDo(response.data)
		})
	}

	useEffect(() => {
		fetchTodos()
	}, [])

	/*useEffect(() => {
		axios.get('https://localhost:7219/api/ToDo').then(response => {
			setToDo(existingData => {
				return response.data
			})
		}
        
        )

	}, []);  */
	const addTodo = () => {
		var payload = {
			userid: userId.current.value,
			title: title.current.value,
			description: description.current.value,
			dueDate: dueDate.current.value,
		}
		axios.post('https://localhost:7219/api/ToDo', payload).then(response => {
			fetchTodos()
		})
	}

	return (
		<>
			<Form>
				<Form.Group className='mb-3' controlId='formTile'>
					<Form.Label>Title</Form.Label>
					<Form.Control type='title' placeholder='Title' ref={title} />
				</Form.Group>
				<Form.Group className='mb-3' controlId='formTile'>
					<Form.Label>user id</Form.Label>
					<Form.Control type='title' placeholder='Title' ref={userId} />
				</Form.Group>

				<Form.Group className='mb-3' controlId='formBasicDescription'>
					<Form.Label>Password</Form.Label>
					<Form.Control type='description' placeholder='description' ref={description} />
				</Form.Group>
				<Form.Group className='mb-3' controlId='formBasicDescription'>
					<Form.Label>DueDate</Form.Label>
					<Form.Control type='Date' placeholder='DueDate' ref={dueDate} />
				</Form.Group>
				<Button variant='primary' type='submit' onClick={addTodo}>
					Submit
				</Button>
			</Form>

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
					{todo.map((item, index) => (
						<tr key={item.id}>
							<td>{item.id}</td>
							<td>{item.title}</td>
							<td>{item.description}</td>
							<td>{item.status}</td>
							<td>{item.dueDate}</td>
						</tr>
					))}
				</tbody>
			</Table>
		</>
	)
}

export default GetAllTodoes
