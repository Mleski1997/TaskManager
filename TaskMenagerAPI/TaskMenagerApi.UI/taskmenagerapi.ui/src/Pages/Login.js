import { useNavigate } from 'react-router-dom'
import React, { useState } from 'react'
import axios from 'axios'

const Login = ({ setIsAuthenticated }) => {
	const [username, setUsername] = useState('')
	const [password, setPassword] = useState('')

    const navigate = useNavigate();

	const handleLogin = async () => {
		try {
			const response = await axios.post('https://localhost:7219/api/Account/login', { username, password })

			if (response.status === 200) {
				console.log('Login successful')
                localStorage.setItem('token', response.data.token)
				setIsAuthenticated(true)
                navigate("/dashboard")
                
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
