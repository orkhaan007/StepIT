import React from 'react';
import '../App.css';

const SignUpForm = () => {
    return (
        <form>
            <div>
                <label>Username:</label>
                <input type="text" name="username" required />
            </div>
            <div>
                <label>Email:</label>
                <input type="email" name="email" required />
            </div>
            <div>
                <label>Password:</label>
                <input type="password" name="password" required />
            </div>
            <div>
                <label>Confirm Password:</label>
                <input type="password" name="confirmPassword" required />
            </div>
            <div>
                <label>Gender:</label>
                <select name="gender" required>
                    <option value="">Select</option>
                    <option value="male">Male</option>
                    <option value="female">Female</option>
                    <option value="other">Other</option>
                </select>
            </div>
            <div className="checkbox-container">
                <label>
                    <input type="checkbox" name="terms" required />
                    I accept the Terms and Conditions
                </label>
            </div>
            <button type="submit">Sign Up</button>
        </form>
    );
};

export default SignUpForm;
