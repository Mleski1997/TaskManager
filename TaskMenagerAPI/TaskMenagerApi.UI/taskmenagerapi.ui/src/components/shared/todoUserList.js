function todoUserList(
	task,
	index,
	completed,
	format,
	Button,
	successTodo,
	todo,
	setTodo,
	updatedSuccess,
	setCompleted,
	statusEnum,
	startEditing,
	setIsEditing,
	setEditingTask,
	title,
	description,
	dueDate,
	status,
	deleteTodo
) {
	return (
		<tr key={task.id}>
			<td>{index + 1}</td>
			<td>{completed.includes(task.id) ? <s>{task.title}</s> : task.title}</td>
			<td className='text'>{task.description}</td>
			<td>{task.status}</td>
			<td>{format(new Date(task.dueDate), 'dd/MM/yyyy')}</td>
			<td className='button-box'>
				<Button
					variant='outline-light'
					className='BtnSuccess Btn'
					onClick={() => successTodo(task.id, todo, setTodo, updatedSuccess, completed, setCompleted, statusEnum)}>
					Success
				</Button>
				<Button
					variant='outline-light'
					className='BtnEdit Btn'
					onClick={() =>
						startEditing(task.id, todo, setIsEditing, setEditingTask, title, description, dueDate, format, status)
					}>
					Edit
				</Button>{' '}
				<Button variant='outline-light' className='BtnDelete Btn' onClick={() => deleteTodo(task.id, todo, setTodo)}>
					Delete
				</Button>
			</td>
		</tr>
	)
}
export default todoUserList
