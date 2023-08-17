import React, {useState} from "react";
import Form from 'react-bootstrap/Form'

import axios from "axios";

function Login() {
   const [username, setUsername] = useState('');
   const [password, setPassword] = useState('');

    const handleSubmit = async event => {
       event.preventDefault();
       try {
        const response = await axios.post('https://localhost:7219/api/Account/login', {username: username, password})
        const token = response.data.token;
       } catch (error) {
        console.error('Login error', error);
       }
    };



    return (
    <Form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="username">Username:</label>
        <input type="text" id="username" value={username} onChange={(e) => setUsername(e.target.value)} />
      </div>
      <div>
        <label htmlFor="password">Password:</label>
        <input type="password" id="password" value={password} onChange={(e) => setPassword(e.target.value)} />
      </div>
      <button type="submit">Login</button>
    </Form>
  );
};


export default Login;