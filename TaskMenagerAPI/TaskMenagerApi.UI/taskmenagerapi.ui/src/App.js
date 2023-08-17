import logo from './logo.svg'
import './App.css'
import Layout from './components/shared/Layout'
import GetAllTodoes from './Pages/Todo'
import { Routes, Route } from 'react-router-dom';
import Register from './Pages/Register'
import Login from './Pages/Login';


function App() {
	return (
		<Layout>
      <Routes>
    
        <Route path='/todo' element={<GetAllTodoes></GetAllTodoes>} ></Route>
        <Route path='/Register' element={<Register></Register>}></Route>
        <Route path='/Login' element={<Login></Login>}></Route>

      </Routes>
			
		</Layout>
	)
}

export default App
