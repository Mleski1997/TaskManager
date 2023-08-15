import logo from './logo.svg'
import './App.css'
import Layout from './components/shared/Layout'
import GetAllTodoes from './Pages/Todo'
import { Routes, Route } from 'react-router-dom';

function App() {
	return (
		<Layout>
      <Routes>
    
        <Route path='/todo' element={<GetAllTodoes></GetAllTodoes>} ></Route>

      </Routes>
			
		</Layout>
	)
}

export default App
