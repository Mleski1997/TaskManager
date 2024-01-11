import { useState } from 'react'
import axios from 'axios'

export const useLogin = () => {
	const [error, setError] = useState('')

	const handleLogin = async (username, password) => {
		try {
			const response = await axios.post('https://localhost:7219/api/Account/login', { userName: username, password })

			if (response.status === 200) {
				const { tokenString, userId, roles, userIsActive } = response.data
				localStorage.setItem('token', tokenString)
				localStorage.setItem('userId', userId)
				localStorage.setItem('username', username)
				localStorage.setItem('roles', roles)

				return true
			} else {
				setError('Failed login')
				return false
			}
		} catch (error) {
			if (error.response && error.response.status === 400) {
				setError('Invalid username or password')
			} else if (error.response && error.response.status === 403) {
				setError('Account is banned')
			} else {
				setError('Error: ' + error.message)
			}
		}
	}

	return {
		error,
		handleLogin,
	}
}
