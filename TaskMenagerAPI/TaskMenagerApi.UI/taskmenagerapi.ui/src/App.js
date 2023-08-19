import logo from './logo.svg'
import './App.css'
import Layout from './components/shared/Layout'
import GetAllTodoes from './Pages/Todo'
import { Route, Routes, Router } from 'react-router-dom'
import Dashboard from './Dashboard/Dashboard'
import Register from './Pages/SignUp'
import Login from './Pages/Login'
import axios from 'axios'

import { useState } from 'react'
import SignUp from './Pages/SignUp'

function App() {
	const [isAuthenticated, setIsAuthenticated] = useState(!!localStorage.getItem('token'))

	return (
		
			<Layout isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}>
				<Routes>
					<Route path='/login' element={<Login setIsAuthenticated={setIsAuthenticated} />} />
					<Route path='/signup' element={<SignUp />} />
					<Route path='/dashboard' element={<Dashboard />} />
				</Routes>
			</Layout>
		
	)
}

export default App
