import logo from './logo.svg'
import './App.css'
import Layout from './components/shared/Layout'
import GetAllTodoes from './Pages/Todo';


function App() {
	return (
		<Layout>
			<GetAllTodoes></GetAllTodoes>
		</Layout>
	)
}

export default App;
