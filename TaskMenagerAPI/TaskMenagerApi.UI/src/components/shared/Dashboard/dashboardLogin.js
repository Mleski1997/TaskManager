import { Link } from 'react-router-dom'
import Form from 'react-bootstrap/Form'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faUser } from '@fortawesome/free-solid-svg-icons'
import '../../../styles/buttons.css'

export function DashboardLogin(props) {
	const { username, setUsername, handleKeyDown, password, setPassword, error, handleLoginClick } = props

	return (
		<section id='main'>
			<div className='hero hero-img'>
				<div className='hero-shadow'></div>
				<div className='box-text'>
					<h1 className='hero-title'>TaskManager</h1>
					<p className='hero-text'>Jakis opis </p>
					<Button as={Link} to='/SignUp' variant='outline-light' className='BtnLogin'>
						Sign Up
					</Button>{' '}
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
					<button className='custom-button' onClick={handleLoginClick}>
						Login
					</button>{' '}
				</Form>
			</div>
		</section>
	)
}
