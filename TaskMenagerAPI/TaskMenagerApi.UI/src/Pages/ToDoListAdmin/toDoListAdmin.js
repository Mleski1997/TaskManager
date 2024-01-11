import React, { useState, useRef } from 'react'

import { updatedSuccess, deleteTodo, addOrUpdateTodo } from '../../services/newtaskservices'

import { TableHeader } from '../../components/shared/Table/tableheader'
import { Sort } from '../../components/shared/Table/sort'

import { sortByDate, sortByStatus, sortById, searchTodo, successTodo, startEditing } from '../../utils/toDoUtils'

import { useTasksAdmin } from '../../hooks/useTasksAdmin'

import format from 'date-fns/format'

import Form from 'react-bootstrap/Form'
import Table from 'react-bootstrap/Table'

import Container from 'react-bootstrap/Container'

import './toDoListAdmin.css'

function ToDoListUser() {
	const { todo, setTodo, originalTodo, completed, setCompleted, setOriginalTodo } = useTasksAdmin()

	const [isEditing, setIsEditing] = useState(false)
	const [editingTask, setEditingTask] = useState(null)
	const [searchResults, setSearchResults] = useState([])
	const [searchTerm, setSearchTerm] = useState('')

	const title = useRef('')
	const description = useRef('')
	const dueDate = useRef('')
	const status = useRef('')

	return <></>
}

export default ToDoListUser
