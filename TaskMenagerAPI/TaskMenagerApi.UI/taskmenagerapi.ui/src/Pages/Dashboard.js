import { useNavigate } from 'react-router-dom'
import React, { useState } from 'react'
import axios from 'axios'
import { id } from 'date-fns/locale'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faUser } from '@fortawesome/free-solid-svg-icons'
import './css/Dashboard.css'

import { Link } from 'react-router-dom'

const Dashboard = ({ setIsAuthenticated }) => {
	const [username, setUsername] = useState('')
	const [password, setPassword] = useState('')

	const navigate = useNavigate()

	const handleLogin = async () => {
		try {
			const response = await axios.post('https://localhost:7219/api/Account/login', { userName: username, password })

			if (response.status === 200) {
				const { tokenString, userId, roles } = response.data
				localStorage.setItem('token', tokenString)
				localStorage.setItem('userId', userId)
				localStorage.setItem('username', username)
				localStorage.setItem('roles', roles)
				console.log('roles', roles)

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
		<>
			<section id='main'>
				<div className='hero hero-img'>
					<div className='hero-shadow'></div>
					<div className='box-text'>
						<h1 className='hero-title'>TaskManager</h1>
						<p className='hero-text'>Jakis opis aplikacji</p>
						<Button as={Link} to='/SignUp' variant='outline-light ' className='BtnLogin'>
							Sign In
						</Button>{' '}
					</div>
				</div>
				<div className='login'>
					<Form className='login-form'>
						<FontAwesomeIcon icon={faUser} className='login-icon'></FontAwesomeIcon>
						<p className='login-text'>Have an account?</p>
						<Form.Group className='mb-3' controlId='Username'>
							<Form.Control
								className='custom-form-control'
								type='string'
								placeholder='Username'
								value={username}
								onChange={e => setUsername(e.target.value)}
							/>
						</Form.Group>
						<Form.Group className='mb-3' controlId='title'>
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
						<Button className='BtnLogin' onClick={handleLogin}>
							Login
						</Button>{' '}
					</Form>
				</div>
			</section>
		</>
	)
}

export default Dashboard
