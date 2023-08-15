import axios from "axios";
import { useEffect, useState } from 'react';
import { Table } from 'reactstrap';


function GetAllTodoes() {
	const [todo, setToDo] = useState([])

	useEffect(() => {
		axios.get('https://localhost:7219/api/ToDo').then(response => {
			setToDo(existingData => {
				return response.data
			})
		})
	}, [])

	return (
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
	)
}

export default GetAllTodoes;
