import axios from 'axios'
import React, { useState, useEffect, useRef } from 'react'
import Table from 'react-bootstrap/esm/Table'
import Button from 'react-bootstrap/Button'
import Container from 'react-bootstrap/Container'
import { getToken, getUser } from '../../services/auth'
import { fetchUser, deleteUser, toggleUserActiveStatus } from '../../services/userlistservices'

import './UsersListAdmin.css'

function UsersListAdmin() {
	const [users, setUsers] = useState([])

	const token = getToken()
	const userName = useRef('')
	const email = useRef('')

	useEffect(() => {
		const fetchUserData = async () => {
			try {
				await fetchUser(setUsers)
			} catch (error) {
				console.error('Error:', error)
			}
		}
		fetchUserData()
	}, [token])

	return (
		<>
			<section id='usersadmin'>
				<Container>
					<Table striped bordered hover className='transparent-table'>
						<thead>
							<tr>
								<th>#</th>
								<th>Username</th>
								<th>Email</th>
								<th>Actions</th>
							</tr>
						</thead>
						<tbody>
							{users.map((user, index) => (
								<tr key={user.id}>
									<td>{index + 1}</td>
									<td>{user.userName}</td>
									<td>{user.email}</td>
									<td>
										<Button variant='danger' onClick={() => deleteUser(user.id, users, setUsers)}>
											Delete
										</Button>{' '}
										<Button
											variant={user.isActive ? 'danger' : 'success'}
											onClick={() => toggleUserActiveStatus(user.id, !user.isActive)}>
											{user.isActive ? 'Ban' : 'Unban'}
										</Button>
									</td>
								</tr>
							))}
						</tbody>
					</Table>
				</Container>
			</section>
		</>
	)
}

export default UsersListAdmin
