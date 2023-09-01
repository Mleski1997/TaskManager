import '../shared/Layout.css'
import Container from 'react-bootstrap/Container'
import Nav from 'react-bootstrap/Nav'
import Navbar from 'react-bootstrap/Navbar'
import { Navigate, useNavigate } from 'react-router-dom'
import { LinkContainer } from 'react-router-bootstrap'
import Button from 'react-bootstrap/Button'
import { Link } from 'react-router-dom'

import { Component } from 'react'

function Layout({ isAuthenticated, setIsAuthenticated, children }) {
	const navigate = useNavigate()

	const handleLogout = () => {
		localStorage.removeItem('token')
		setIsAuthenticated(false)
		navigate('/login')
		console.log('Logout success')
	}

	return (
		<>
			<Navbar bg='dark' variant='dark' className='fixed-top'>
				<Container>
					<Navbar.Brand href='#home'>TaskManager</Navbar.Brand>

					{isAuthenticated ? (
						<Button variant='outline-light' onClick={handleLogout}>
							Logout
						</Button>
					) : (
						<>
							<Nav className='me-auto'>
								<Nav.Link href='/'>Home</Nav.Link>
							</Nav>
							<Button as={Link} to='/login' variant='outline-light' className='m-2 BtnNav'>
								Login
							</Button>
							<Button as={Link} to='/signup' variant='outline-light' className='BtnNav'>
								SignUp
							</Button>
						</>
					)}
				</Container>
			</Navbar>

			{children}
		</>
	)
}

export default Layout
