import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'

import axios from 'axios'

function Register() {
	const [user, setUser] = useState({
		username: '',
		email: '',
		password: '',
		
	})

	const handleInputChange = event => {
		const { name, value } = event.target

		setUser(prevUser => ({
			...prevUser,
			[name]: value,
		}))
	}

	const hadnleRegistration = async event => {
		event.preventDefault()

		//if (user.password !== user.confirmPassword) {
		//	console.log('Pssword dont match')
		//	return
		//}

		try {
			const response = await axios.post('https://localhost:7219/api/Account/register', user)
			console.log('Registration successful:', response.data)
		} catch (error) {
			console.error('Error during registration:', error)
		}
	}

	return (
		
		<Form onSubmit={hadnleRegistration} >
			<Form.Group className='mb-3' controlId='username'>
				<Form.Label>username</Form.Label>
				<Form.Control
					type='text'
					name='username'
					value={user.username}
					onChange={handleInputChange}
					placeholder='username'
					required
				/>
			</Form.Group>

			<Form.Group className='mb-3' controlId='email'>
				<Form.Label>email</Form.Label>
				<Form.Control
					type='email'
					name='email'
					value={user.email}
					onChange={handleInputChange}
					placeholder='Enter email'
					required
				/>
			</Form.Group>
            <Form.Group className='mb-3' controlId='password'>
				<Form.Label>password</Form.Label>
				<Form.Control
					type='password'
					name='password'
					value={user.Password}
					onChange={handleInputChange}
					placeholder='confirmPassword'
					required
				/>
			</Form.Group>
			

			<Button variant='primary' type='submit'>
				Submit
			</Button>
		</Form>
		
	)
}

export default Register
