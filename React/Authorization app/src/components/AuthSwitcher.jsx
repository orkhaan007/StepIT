import React, { useState } from 'react';
import SignInForm from './SignInForm';
import SignUpForm from './SignUpForm';

const AuthSwitcher = () => {
    const [isSignIn, setIsSignIn] = useState(true);

    return (
        <div>
            <div>
                <button onClick={() => setIsSignIn(true)}>Sign In</button>
                <button onClick={() => setIsSignIn(false)}>Sign Up</button>
            </div>
            <div>
                {isSignIn ? <SignInForm /> : <SignUpForm />}
            </div>
        </div>
    );
};

export default AuthSwitcher;