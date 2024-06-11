import React from 'react';
import AuthSwitcher from './components/AuthSwitcher';
import './App.css';

const App = () => {
    return (
        <div className="container">
            <h1>Authorization App</h1>
            <AuthSwitcher />
        </div>
    );
};

export default App;