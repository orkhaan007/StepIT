import React from 'react';
import CurrentTime from './components/CurrentTime';
import Timer from './components/Timer';

function App() {
  return (
    <div className="app">
      <div className="container">
        <CurrentTime />
        <Timer />
      </div>
    </div>
  );
}

export default App;