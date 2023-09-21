import axios from 'axios'
import { getToken, getUser } from './auth'

const token = getToken()
const userId = getUser()

export async function fetchUser(setUsers) {
	const response = await axios.get(`https://localhost:7219/api/User`, {
		headers: {
			Authorization: `Bearer ${token}`,
		},
	})
	if (response.status === 200) {
		const filteredUsers = response.data.filter(user => user.userName !== 'admin')
		setUsers(filteredUsers)
	} else {
		console.error('Failed to fetch tasks')
	}
}

export async function deleteUser(userId, users, setUsers, token) {
	try {
		await axios.delete(`https://localhost:7219/api/User/${userId}`, {
			headers: {
				Authorization: `Bearer ${token}`,
			},
		})

		const updatedUsers = users.filter(user => user.id !== userId)
		setUsers(updatedUsers)
	} catch (error) {
		console.error('Error:', error)
	}
}

export async function toggleUserActiveStatus(userId, isActive, users, response, setUsers) {
	try {
		const response = await axios.put(
			`https://localhost:7219/api/User/${userId}/Active`,
			{ isActive },
			{
				headers: {
					Authorization: `Bearer ${token}`,
				},
			}
		)

		if (response.status === 200) {
			const updatedUsers = users.map(user => (user.id === userId ? { ...user, isActive } : user))
			setUsers(updatedUsers)
		} else {
			console.error('Failed to update user status')
		}
	} catch (error) {
		console.error('Error:', error)
	}

	if (response.status === 200) {
		const updatedUsers = users.map(user => (user.id === userId ? { ...user, isActive } : user))
		setUsers(updatedUsers)
	} else {
		console.error('Failed to update user status')
	}
}
