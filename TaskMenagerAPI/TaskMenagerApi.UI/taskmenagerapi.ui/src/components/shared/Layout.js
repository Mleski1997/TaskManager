import Container from 'react-bootstrap/Container'
import Nav from 'react-bootstrap/Nav'
import Navbar from 'react-bootstrap/Navbar'
import { Navigate, useNavigate } from 'react-router-dom'
import { LinkContainer } from 'react-router-bootstrap'
import Button from 'react-bootstrap/Button'
import { Link } from 'react-router-dom'

function Layout({ isAuthenticated, setIsAuthenticated, children }) {
    const navigate = useNavigate();
  
    const handleLogout = () => {
      localStorage.removeItem('token');
      setIsAuthenticated(false);
      navigate('/login');
      console.log('Logout success');
    };
  
    return (
      <>
        <Navbar bg='dark' variant='dark'>
          <Container>
            <Navbar.Brand href='#home'>Navbar</Navbar.Brand>
            <Nav className='me-auto'>
              <Nav.Link href='#home'>Home</Nav.Link>
              <Nav.Link href='#feature'>Features</Nav.Link>
              <Nav.Link href='#pricing'>Pricing</Nav.Link>
            </Nav>
  
            {isAuthenticated ? (
              <Button variant='primary' onClick={handleLogout}>
                Logout
              </Button>
            ) : (
              <>
                <Button as={Link} to='/login' variant='primary'>
                  Login
                </Button>
                <Button as={Link} to='/signup' variant='primary'>
                  SignUp
                </Button>
              </>
            )}
          </Container>
        </Navbar>
        <br />
  
        <Container>{children}</Container>
      </>
    );
  }
  
  export default Layout;