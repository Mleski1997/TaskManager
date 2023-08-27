import React from 'react'
import './css/Dashboard.css'
import Button from 'react-bootstrap/Button'

import { Link } from 'react-router-dom'

function Dashboard() {

    
	return (
		<>
			<section id='main'>
				<div className='hero-img'>
					<div className='hero-shadow'></div>
					<div className='box-text'>
						<h1 className='hero-title'>TaskManagerAPI</h1>
						<p className='hero-text'>Jakis opis aplikacji</p>
						<Button as={Link} to='/login' variant='outline-light ' className='BtnLogin'>Login</Button>{' '}
					</div>
				</div>
			</section>
		</>
	)
}

export default Dashboard
