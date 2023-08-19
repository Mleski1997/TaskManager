import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'

import axios from 'axios'

function SignUp() {
	const [username, setUsername] = useState('')
	const [email, setEmail] = useState('')
	const [password, setPassword] = useState('')

	const handleSignUp = async () => {
		try {
			const response = await axios.post('https://localhost:7219/api/Account/register', {
				username,
				email,
				password,
			})

			if (response.status === 200) {
				console.log('Registraion successful')
			} else {
				console.error('Registtraion failded')
			}
		} catch (error) {
			console.error('error', error)
		}
	}

	return (
		<>
			<div>
				<h2>SignUp</h2>
				<input type='text' placeholder='username' value={username} onChange={e => setUsername(e.target.value)} />
				<input type='email' placeholder='email' value={email} onChange={e => setEmail(e.target.value)} />
				<input type='password' placeholder='password' value={password} onChange={e => setPassword(e.target.value)} />

				<button onClick={handleSignUp}>SignUp</button>
			</div>
		</>
	)
}

export default SignUp
