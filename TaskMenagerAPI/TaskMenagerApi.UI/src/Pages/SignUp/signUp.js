import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import { SignUpForm } from '../../components/shared/SignUp/signupForm'

import { useRegistration } from '../../hooks/useRegistration'

import './signUp.css'

function SignUp() {
	const {
		username,
		setUsername,
		email,
		setEmail,
		password,
		setPassword,
		checkPassword,
		setCheckPassword,
		error,
		registerUser,
	} = useRegistration()

	return (
		<SignUpForm
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
