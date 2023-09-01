import logo from './logo.svg'
import './App.css'
import Layout from './components/shared/Layout'
import GetAllTodoes from './Pages/Todo'
import { Route, Routes, Router } from 'react-router-dom'
import Dashboard from './Pages/Dashboard'
import Register from './Pages/SignUp'
import Login from './Pages/Login'
import axios from 'axios'

import { useState } from 'react'
import SignUp from './Pages/SignUp'
import TaskList from './Pages/TaskList'
import ToDoListUser from './Pages/ToDoListUser'

function App() {
	const [isAuthenticated, setIsAuthenticated] = useState(!!localStorage.getItem('token'))

	return (
		<Layout isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}>
			<Routes>
				<Route path='/' element={<Dashboard setIsAuthenticated={setIsAuthenticated} />} />
				<Route path='/' element={<Dashboard />} />
				<Route path='/signup' element={<SignUp />} />
				<Route path='/tasklist' element={<TaskList />} />
				<Route path='/todolistuser' element={<ToDoListUser />} />
			</Routes>
		</Layout>
	)
}

export default App
