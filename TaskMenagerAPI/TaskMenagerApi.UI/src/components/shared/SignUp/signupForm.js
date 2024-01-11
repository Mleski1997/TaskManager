import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import '../../../styles/buttons.css'

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
		setError,
	} = props

	const handleKeyDown = e => {
		if (e.key === 'Enter') {
			registerUser()
		}
	}

	return (
		<section id='register'>
			<div className='register-img'>
				<div className="r-img"></div>
			</div>
			<div className='register-container'>
				<h2 className='register-title'>Sign Up</h2>
				<p className='register-text'>Start using TaskManager to control your progress</p>
				<Form className='register-form'>
					<Form.Group className='mb-3 register-input' controlId='Username'>
						<Form.Label>Username</Form.Label>
						<Form.Control
							className='custom-form-control'
							type='string'
							placeholder='Username'
							value={username}
							onChange={e => setUsername(e.target.value)}></Form.Control>
					</Form.Group>
					<Form.Group className='mb-3 register-input ' controlId='Email'>
						<Form.Label>Email</Form.Label>
						<Form.Control
							className='custom-form-control'
							type='email'
							placeholder='Email'
							value={email}
							onChange={e => setEmail(e.target.value)}></Form.Control>
					</Form.Group>
					<Form.Group className='mb-3 register-input ' controlId='password'>
						<Form.Label>Password</Form.Label>
						<Form.Control
							className='custom-form-control'
							type='password'
							placeholder='password'
							value={password}
							onChange={e => setPassword(e.target.value)}></Form.Control>
					</Form.Group>
					<Form.Group className='mb-3 register-input ' controlId='confimPassword'>
						<Form.Label>Confirm Password</Form.Label>

						<Form.Control
							className='custom-form-control'
							type='password'
							placeholder='password'
							value={checkPassword}
							onKeyDown={handleKeyDown}
							onChange={e => setCheckPassword(e.target.value)}></Form.Control>
					</Form.Group>
					{error && <p className='error-message'>{error}</p>}
					<a className='custom-button'  onClick={registerUser}>
						Register
					</a>{' '}
					<a href='/TaskMenager' className='loginLink'>
						Login
					</a>
				</Form>
			</div>
		</section>
	)
}
