import { useNavigate } from 'react-router-dom'
import React, { useState } from 'react'

import { LoginForm } from '../../components/shared/Login/loginForm'
import './dashboard.css'
import { useLogin } from '../../hooks/useLogin'

const Dashboard = ({ setIsAuthenticated }) => {
	const [username, setUsername] = useState('')
	const [password, setPassword] = useState('')

	const navigate = useNavigate()
	const { error, handleLogin } = useLogin()

	const handleLoginClick = async () => {
		try {
			const success = await handleLogin(username, password)

			if (success) {
				setIsAuthenticated(true)
				navigate('/todolistuser')
			}
		} catch (error) {
			console.log(error)
		}
	}

	return (
		<LoginForm
			username={username}
			password={password}
			error={error}
			setUsername={setUsername}
			setPassword={setPassword}
			handleLoginClick={handleLoginClick}
		/>
	)
}

export default Dashboard
