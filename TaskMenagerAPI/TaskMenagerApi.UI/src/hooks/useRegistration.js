import { useState } from 'react'
import axios from 'axios'
import { useNavigate } from 'react-router-dom'
export const useRegistration = () => {
	const [username, setUsername] = useState('')
	const [email, setEmail] = useState('')
	const [password, setPassword] = useState('')
	const [checkPassword, setCheckPassword] = useState('')
	const [error, setError] = useState('')

	const navigate = useNavigate()

	const registerUser = async () => {
		if (password !== checkPassword) {
			setError('Password and Confirm Password do not match')
			return false
		}

		try {
			const response = await axios.post('https://localhost:7219/api/Account/register', {
				username,
				email,
				password,
			})

			if (response.status === 200) {
				navigate('/TaskMenager')
			} else {
				setError('Registration failed')
			}
		} catch (error) {
			if (error.response && error.response.status === 400) {
				setError('Password must have one uppercase letter, one lowercase letter, one special character, and one digit')
			} else {
				setError('Error: ' + error.message)
			}
		}
		return true
	}

	return {
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
	}
}
