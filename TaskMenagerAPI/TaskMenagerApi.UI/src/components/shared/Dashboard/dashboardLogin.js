import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faUser } from '@fortawesome/free-solid-svg-icons'

export function dashboardLogin(props) {
	const { Link, username, setUsername, handleKeyDown, password, setPassword, error, handleLoginClick } = props

	return (
		<section id='main'>
			<div className='hero hero-img'>
				<div className='hero-shadow'></div>
				<div className='box-text'>
					<h1 className='hero-title'>TaskManager</h1>
					<p className='hero-text'>Jakis opis aplikacji</p>
					<Button as={Link} to='/SignUp' variant='outline-light ' className='BtnLogin'>
						Sign In
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
					<Button className='BtnLogin' onClick={handleLoginClick}>
						Login
					</Button>{' '}
				</Form>
			</div>
		</section>
	)
}
