import Container from 'react-bootstrap/Container'
import Nav from 'react-bootstrap/Nav'
import Navbar from 'react-bootstrap/Navbar'

function Layout(props) {
	return (
		<>
			<Navbar bg='dark' data-bs-theme='dark'>
				<Container>
					<Navbar.Brand href='#home'>ToDoMenag</Navbar.Brand>
					<Nav className='me-auto'>
						<Nav.Link href='#home'>Home</Nav.Link>
						<Nav.Link href='#Todo'>Todo</Nav.Link>						
					</Nav>
				</Container>
			</Navbar>
            <Container>{props.children}</Container>
		</>
	)
}

export default Layout
