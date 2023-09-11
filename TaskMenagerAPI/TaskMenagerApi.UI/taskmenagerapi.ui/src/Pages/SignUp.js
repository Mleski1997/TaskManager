import React, { useState } from 'react'
import './css/SignUp.css'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import { useNavigate } from 'react-router-dom'

import axios from 'axios'

function SignUp() {
	const [username, setUsername] = useState('')
	const [email, setEmail] = useState('')
	const [password, setPassword] = useState('')
	const [checkpassword, checkPassword] = useState('')

	const navigate = useNavigate()

	const handleSignUp = async () => {
		if (password !== checkpassword) {
			console.error('Password and Confrim Password do not match')
			return
		} else {
			try {
				const response = await axios.post('https://localhost:7219/api/Account/register', {
					username,
					email,
					password,
				})

				if (response.status === 200) {
					console.log('Registration successful')
					navigate('/')
				} else {
					console.error('Registration failed')
				}
			} catch (error) {
				console.error('error', error)
			}
		}
	}
	const handleKeyDown = event => {
		if (event.key === 'Enter') {
			event.preventDefault()
			handleSignUp()
		}
	}

	return (
		<>
			<section id='register'>
				<div className='register-container'>
					<Form className='register-form'>
						<Form.Group className='mb-3' controlId='Username'>
							<Form.Label>Username</Form.Label>
							<Form.Control
								className='custom-form-control'
								type='string'
								placeholder='Username'
								value={username}
								onChange={e => setUsername(e.target.value)}></Form.Control>
						</Form.Group>
						<Form.Group className='mb-3' controlId='Email'>
							<Form.Label>Email</Form.Label>
							<Form.Control
								className='custom-form-control'
								type='email'
								placeholder='Email'
								value={email}
								onChange={e => setEmail(e.target.value)}></Form.Control>
						</Form.Group>
						<Form.Group className='mb-3' controlId='password'>
							<Form.Label>Password</Form.Label>
							<Form.Control
								className='custom-form-control'
								type='password'
								placeholder='password'
								value={password}
								onChange={e => setPassword(e.target.value)}></Form.Control>
						</Form.Group>
						<Form.Group className='mb-3' controlId='password'>
							<Form.Label>ConfirmPassword</Form.Label>
							<Form.Control
								className='custom-form-control'
								type='password'
								placeholder='password'
								onKeyDown={handleKeyDown}
								value={checkpassword}
								onChange={e => checkPassword(e.target.value)}></Form.Control>
						</Form.Group>
						<Button className='BtnLogin' variant='outline-light' onClick={handleSignUp}>
							Register
						</Button>{' '}
					</Form>
				</div>
			</section>
		</>
	)
}

export default SignUp
