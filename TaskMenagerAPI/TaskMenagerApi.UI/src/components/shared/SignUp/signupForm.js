import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'

export function SignUpForm(props) {
	const {
		registerUser,
		error,
		username,
		setUsername,
		email,
		setEmail,
		password,
		checkPassword,
		setPassword,
		setCheckPassword,
	} = props

	const handleKeyDown = e => {
		if (e.key === 'Enter') {
			registerUser()
		}
	}

	return (
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
					<Form.Group className='mb-3' controlId='confimPassword'>
						<Form.Label>ConfirmPassword</Form.Label>

						<Form.Control
							className='custom-form-control'
							type='password'
							placeholder='password'
							value={checkPassword}
							onKeyDown={handleKeyDown}
							onChange={e => setCheckPassword(e.target.value)}></Form.Control>
					</Form.Group>
					{error && <p className='error'>{error}</p>}
					<Button className='BtnLogin' variant='outline-light' onClick={registerUser}>
						Register
					</Button>{' '}
					<a href='/' className='loginLink'>
						Login
					</a>
				</Form>
			</div>
		</section>
	)
}
