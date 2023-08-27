import { useNavigate } from 'react-router-dom'
import React, { useState } from 'react'
import axios from 'axios'
import './css/Login.css'
import { id } from 'date-fns/locale'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/esm/Button'

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
				localStorage.setItem('userId', userId)

				setIsAuthenticated(true)
				navigate('/todolistuser')
			} else {
				console.error('Login failed')
			}
		} catch (error) {
			console.error('Error:', error)
		}
	}

	const handleKeyDown = event => {
		if (event.key === 'Enter') {
			event.preventDefault()
			handleLogin()
		}
	}

	return (
		<section id='login'>
			<div className='login-container'>
				<Form className='login-form'>
					<Form.Group className='mb-3' controlId='Username'>
						<Form.Label>Username</Form.Label>
						<Form.Control
							className='custom-form-control'
							type='string'
							placeholder='Username'
							value={username}
							onChange={e => setUsername(e.target.value)}
						/>
					</Form.Group>
					<Form.Group className='mb-3' controlId='title'>
						<Form.Label>Password</Form.Label>
						<Form.Control
							className='custom-form-control'
							type='password'
							placeholder='Password'
							onKeyDown={handleKeyDown}
							value={password}
							onChange={e => setPassword(e.target.value)}
						/>
						<div className='bot'></div>
					</Form.Group>
					<Button className='BtnLogin' variant='outline-light' onClick={handleLogin}>
						Login
					</Button>{' '}
				</Form>
			</div>
		</section>
	)
}

export default Login
