import React, { Fragment, useEffect, useState } from 'react'
import axios from 'axios'
import Table from 'react-bootstrap/Table'
import { format } from 'date-fns'

const TaskList = () => {
	const [todolist, setTodolist] = useState([])
	const UserId = localStorage.getItem('UserId')

	useEffect(() => {
		if (UserId) {
			HandleList()
		}
	}, [UserId])

	const HandleList = async () => {
		try {
			const response = await axios.get(`https://localhost:7219/api/UserToDo/${UserId}`)
			setTodolist(response.data)
			console.log('Received id:', UserId)
		} catch (error) {
			console.error('user list error', error)
		}
	}

	return (
		<Fragment>
			{UserId ? (
				<Table striped bordered hover>
					<thead>
						<tr>
							<th>#</th>
							<th>Id</th>
							<th>Title</th>
							<th>Description</th>
							<th>Status</th>
							<th>DueDate</th>
						</tr>
					</thead>
					<tbody>
						{todolist && todolist.length > 0 ? (
							todolist.map((item, index) => (
								<tr key={index}>
									<td>{index + 1}</td>
									<td>{item.id}</td>
									<td>{item.title}</td>
									<td>{item.description}</td>
									<td>{item.status}</td>
									<td>{format(new Date(item.dueDate), 'yyyy-MM-dd')}</td>
								</tr>
							))
						) : (
							<tr>
								<td colSpan='6'>Loading...</td>
							</tr>
						)}
					</tbody>
				</Table>
			) : null}
		</Fragment>
	)
}

export default TaskList
