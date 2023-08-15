import axios from 'axios'
import { useEffect, useRef, useState } from 'react'
import { Table } from 'reactstrap'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import { func } from 'prop-types'
import { Link} from 'react-router-dom';

function GetAllTodoes() {
	const [todo, setToDo] = useState([])

	//const title = useRef('')
	//const description = useRef('')
	//const dueDate = useRef('')

	useEffect(() => {
		axios.get('https://localhost:7219/api/ToDo').then(response => {
			setToDo(existingData => {
				return response.data
			})
		})
	}, [])

	/*const addTodo = () => {
		var payload = {
			title: title.current.value,
			description: description.current.value,
			dueDate: dueDate.current.value,
		}
		axios.post('https://localhost:7219/api/ToDo', payload).then(respone => {
			return respone.data
		}) */  

		return (
			<>
	

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
 //}
export default GetAllTodoes
