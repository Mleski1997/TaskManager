import React from 'react'
import { Form, Button, Dropdown } from 'react-bootstrap'

function todoPanel({
	title,
	description,
	status,
	dueDate,
	statusEnum,
	isEditing,
	editingTask,
	todo,
	setTodo,
	setIsEditing,
	handleKeyDown,
	sortByDate,
	sortByStatus,
	sortById,
	searchTerm,
	setSearchTerm,
	searchTodo,
	originalTodo,
	setSearchResults,
	addOrUpdateTodo,
}) {
	return (
		<Form className='form-box'>
			<Form.Group className='mb-3 form-group' controlId='title'>
				<Form.Label>Title</Form.Label>
				<Form.Control type='title' placeholder='title' ref={title} />
			</Form.Group>

			<Form.Group className='mb-3 form-group' controlId='description'>
				<Form.Label>Description</Form.Label>
				<Form.Control as='textarea' rows={3} placeholder='description' ref={description} />
			</Form.Group>
			<div className='form-bottom'>
				<Form.Group controlId='status' className='status'>
					<Form.Label>Status</Form.Label>
					<Form.Select ref={status}>
						<option value={statusEnum.InProgress}>InProgress</option>
						<option value={statusEnum.Blocked}>Blocked</option>
					</Form.Select>
				</Form.Group>

				<Form.Group className='date mb-3 form-group' controlId='duedate'>
					<Form.Label>Date</Form.Label>
					<Form.Control type='date' placeholder='description' ref={dueDate} />
				</Form.Group>
			</div>

			<Button
				variant='outline-light'
				className='BtnSubmit mb-3 w-100'
				type='submit'
				onClick={() =>
					addOrUpdateTodo(title, description, dueDate, isEditing, editingTask, todo, setTodo, setIsEditing, status)
				}
				onKeyDown={handleKeyDown}>
				Submit
			</Button>
			<div className='form-button--admin'>
				<Dropdown>
					<Dropdown.Toggle variant='success' className='BtnSort mb-3'>
						Sort
					</Dropdown.Toggle>

					<Dropdown.Menu>
						<Dropdown.Item href='#/action-1' onClick={() => sortByDate(todo, setTodo)}>
							Date
						</Dropdown.Item>
						<Dropdown.Item href='#/action-2' onClick={() => sortByStatus(todo, setTodo)}>
							Status
						</Dropdown.Item>
						<Dropdown.Item href='#/action-3' onClick={() => sortById(todo, setTodo)}>
							UserID
						</Dropdown.Item>
					</Dropdown.Menu>
				</Dropdown>
				<div className='search-box'>
					<Form.Control
						type='text'
						placeholder='search'
						aria-label='Search'
						value={searchTerm}
						onChange={e => setSearchTerm(e.target.value)}></Form.Control>
					<Button
						variant='success'
						className='BtnSearch'
						onClick={() => searchTodo(searchTerm, originalTodo, setSearchResults)}>
						Search
					</Button>
				</div>
			</div>
		</Form>
	)
}

export default todoPanel
