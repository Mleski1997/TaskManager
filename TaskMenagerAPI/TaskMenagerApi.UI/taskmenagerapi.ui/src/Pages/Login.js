import { useNavigate } from 'react-router-dom'
import React, { useState } from 'react'
import axios from 'axios'
import { id } from 'date-fns/locale'

const Login = ({ setIsAuthenticated }) => {
	const [username, setUsername] = useState('')
	const [password, setPassword] = useState('')

	const navigate = useNavigate()

	const handleLogin = async () => {
		try {
			const response = await axios.post('https://localhost:7219/api/Account/login', { userName: username, password })

			if (response.status === 200) {
				const { tokenString, userId } = response.data
				localStorage.setItem('token', tokenString)
				console.log('token', tokenString)
				localStorage.setItem('userId', userId)
				console.log('userId', userId)
				console.log(response.data)

				setIsAuthenticated(true)
				navigate('/dashboard')
			} else {
				console.error('Login failed')
			}
		} catch (error) {
			console.error('Error:', error)
		}
	}

	return (
		<div>
			<h2>Login</h2>
			<input type='text' placeholder='Username' value={username} onChange={e => setUsername(e.target.value)} />
			<input type='password' placeholder='Password' value={password} onChange={e => setPassword(e.target.value)} />
			<button onClick={handleLogin}>Login</button>
		</div>
	)
}

export default Login
