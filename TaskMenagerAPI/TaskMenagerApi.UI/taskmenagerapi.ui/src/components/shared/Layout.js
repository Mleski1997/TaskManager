import Container from 'react-bootstrap/Container'
import Nav from 'react-bootstrap/Nav'
import Navbar from 'react-bootstrap/Navbar'
import { Navigate } from 'react-router-dom'




function Layout(props) {
	return (
		<>
			<Navbar bg='dark' data-bs-theme='dark'>
				<Container>
					<Navbar.Brand href='home'>ToDoMenager</Navbar.Brand>
					<Nav className='me-auto'>
						<Nav.Link href='home'>Home</Nav.Link>
						<Nav.Link href='Todo' onClick={()=> Navigate("/todo")}>Todo</Nav.Link>						
					</Nav>
				</Container>
			</Navbar>
            <Container>{props.children}</Container>
		</>
	)
}

export default Layout
