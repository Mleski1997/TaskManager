import axios from 'axios';
import { useEffect, useState } from 'react';
import { getToken, getUser } from '../services/auth';

export const useTasks = () => {
  const [tasks, setTasks] = useState([]);

  const fetchTasks = async () => {
    const token = getToken();
    const userId = getUser();
    try {
      const response = await axios.get(`https://localhost:7219/api/User/${userId}/Todoes`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      if (response.status === 200) {
        setTasks(response.data);
      } else {
        console.log('Error with fetch task');
      }
    } catch (error) {
      console.error('Error fetching tasks:', error);
    }
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  return {tasks, setTasks};
};