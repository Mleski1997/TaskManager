import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import { SignUpForm } from '../../components/shared/SignUp/signupForm'
import { useNavigate } from 'react-router-dom'


import { useRegistration } from '../../hooks/useRegistration'

import './signUp.css'

function SignUp() {
	const navigate = useNavigate()
	const {
		username,
		setUsername,
		email,
		setEmail,
		password,
		setPassword,
		checkPassword,
		setCheckPassword,
		registerUser,
		error,
	} = useRegistration()

	const handleRegisterClick = async () => {
		try {
			const success = await registerUser()
			if (success) {
				navigate('/TaskMenager')
			}
		} catch (error) {
			console.log(error)
		}
	}

	return (
		<SignUpForm
			error={error}
			registerUser={registerUser}
			username={username}
			setUsername={setUsername}
			email={email}
			setEmail={setEmail}
			password={password}
			setPassword={setPassword}
			checkPassword={checkPassword}
			setCheckPassword={setCheckPassword}
		/>
	)
}
export default SignUp
