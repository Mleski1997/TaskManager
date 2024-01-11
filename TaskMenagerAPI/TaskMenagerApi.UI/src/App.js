import './App.css'
import Layout from './components/shared/Layout/Layout'

import { Route, Routes, Router, Navigate } from 'react-router-dom'
import Dashboard from './Pages/Dashboard/dashboard'
import NewTask from './Pages/NewTask/NewTask'
import ToDoListAdmin from './Pages/ToDoListAdmin/toDoListAdmin'
import UsersListAdmin from './Pages/UsersListAdmin/usersListAdmin'
import SignUp from './Pages/SignUp/signUp'
import TaskList from './Pages/TasksList/TaskList'
import { useState } from 'react'

const User_Types = {
	Public_User: 'Public User',
	Normal_User: 'User',
	Admin_User: 'admin',
}

const current_user_type = localStorage.getItem('roles')

function App() {
	const [isAuthenticated, setIsAuthenticated] = useState(!!localStorage.getItem('token'))

	return (
		<Routes>
			<Route
				path='/TaskMenager'
				element={isAuthenticated ? <Navigate to='/newtask' /> : <Dashboard setIsAuthenticated={setIsAuthenticated} />}
			/>
			<Route
				path='/ToDoListAdmin'
				element={
					current_user_type === User_Types.Admin_User ? (
						<AdminElement>
							<Layout isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}>
								<TaskList />
							</Layout>
						</AdminElement>
					) : (
						<div>You don't have access to this page</div>
					)
				}
			/>
			<Route
				path='/UsersListAdmin'
				element={
					current_user_type === User_Types.Admin_User ? (
						<AdminElement>
							<Layout isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}>
								<UsersListAdmin />
							</Layout>
						</AdminElement>
					) : (
						<div>You don't have access to this page</div>
					)
				}
			/>

			<Route path='/signup' element={<SignUp />} />
			<Route
				path='/newtask'
				element={
					current_user_type === User_Types.Admin_User || current_user_type === User_Types.Normal_User ? (
						<UserElement>
							<Layout isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}>
								<NewTask />
							</Layout>
						</UserElement>
					) : (
						<Navigate to='/newtask' />
					)
				}
			/>
			<Route
				path='/TaskList'
				element={
					current_user_type === User_Types.Admin_User || current_user_type === User_Types.Normal_User ? (
						<UserElement>
							<Layout isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}>
								<TaskList />
							</Layout>
						</UserElement>
					) : (
						<div>You don't have access to this page</div>
					)
				}
			/>
		</Routes>
	)
}

function PublicElement({ children }) {
	return <>{children}</>
}

function UserElement({ children }) {
	if (current_user_type === User_Types.Admin_User || current_user_type === User_Types.Normal_User) {
		return <>{children}</>
	} else {
		return <Navigate to={'/newtask'} />
	}
}

function AdminElement({ children }) {
	if (current_user_type === User_Types.Admin_User) {
		return <>{children}</>
	} else {
		return <div> You dont have acces to this page</div>
	}
}

export default App
