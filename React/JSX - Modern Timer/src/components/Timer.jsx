import React, { useState, useMemo } from 'react';
import TimerControl from './TimerControl';

const Timer = () => {
  const [history, setHistory] = useState([]);
  const [currentTimeMillis, setCurrentTimeMillis] = useState(0);

  const handleTimeUpdate = (time) => {
    setCurrentTimeMillis(time * 1000);
  };

  const handleStop = (time) => {
    setHistory((prevHistory) => [...prevHistory, time * 1000]);
  };

  const handleReset = () => {
    setHistory([]);
    setCurrentTimeMillis(0);
  };

  const totalTime = useMemo(() => {
    return history.reduce((acc, curr) => acc + curr, 0);
  }, [history]);

  const formatTime = (timeInMillis) => {
    const totalSeconds = Math.floor(timeInMillis / 1000);
    const hours = Math.floor(totalSeconds / 3600);
    const minutes = Math.floor((totalSeconds % 3600) / 60);
    const seconds = totalSeconds % 60;

    return `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
  };

  return (
    <div className="container">
      <h1>{formatTime(currentTimeMillis)}</h1>
      <TimerControl onTimeUpdate={handleTimeUpdate} onStop={handleStop} onReset={handleReset} />
      <div className="history">
        <ul>
          {history.map((entry, index) => (
            <li key={index}>{formatTime(entry)}</li>
          ))}
        </ul>
      </div>
      <h3>Total time: {formatTime(totalTime)}</h3>
    </div>
  );
};

export default Timer;
