import Form from 'react-bootstrap/Form'
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faUser } from '@fortawesome/free-solid-svg-icons'
import { handleLogin } from '../../../services/loginServices'

export function LoginForm(props) {
	const {
		username,
		password,
		setUsername,
		setPassword,
		error,
		handleLoginClick,
	} = props

	const handleKeyDown = event => {
		if (event.key === 'Enter') {
			handleLoginClick()
		}
	}
	
	return (
		<section id='main'>
			<div className='hero hero-img'>
				<div className='hero-shadow'></div>
				<div className='box-text'>
					<h1 className='hero-title'>TaskManager</h1>
					<p className='hero-text'>Jakis opis aplikacji</p>
					<Link to='/SignUp'>
						<Button variant='outline-light' className='BtnSingUp'>
							SignUp
						</Button>
					</Link>
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
					{error && <p className='error'>{error}</p>}
					<a className='custom-button' onClick={handleLoginClick}>
						Login
					</a>{' '}
				</Form>
			</div>
		</section>
	)
}

