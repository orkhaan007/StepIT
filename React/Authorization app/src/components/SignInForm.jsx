import React from 'react';
import '../App.css';

const SignInForm = () => {
    return (
        <form>
            <div>
                <label>Username:</label>
                <input type="text" name="username" required />
            </div>
            <div>
                <label>Password:</label>
                <input type="password" name="password" required />
            </div>
            <div className="checkbox-container">
                <label>
                    <input type="checkbox" name="remember" />
                    Remember me
                </label>
            </div>
            <button type="submit">Sign In</button>
        </form>
    );
};

export default SignInForm;