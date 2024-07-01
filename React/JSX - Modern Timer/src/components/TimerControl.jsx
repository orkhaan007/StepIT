import React, { useState, useEffect, useRef } from 'react';

const TimerControl = ({ onTimeUpdate, onStop, onReset }) => {
  const [time, setTime] = useState(0);
  const [isRunning, setIsRunning] = useState(false);
  const timerRef = useRef(null);
  const startStopButtonRef = useRef(null);

  useEffect(() => {
    if (isRunning) {
      timerRef.current = setInterval(() => {
        setTime((prevTime) => {
          const newTime = prevTime + 1;
          onTimeUpdate(newTime);
          return newTime;
        });
      }, 1000);
    } else {
      clearInterval(timerRef.current);
    }
    return () => clearInterval(timerRef.current);
  }, [isRunning, onTimeUpdate]);

  const handleStartStop = () => {
    setIsRunning((prevIsRunning) => {
      if (prevIsRunning) {
        onStop(time);
      }
      return !prevIsRunning;
    });
    startStopButtonRef.current.focus();
  };

  const handleReset = () => {
    setIsRunning(false);
    setTime(0);
    onTimeUpdate(0);
    onReset();
    startStopButtonRef.current.focus();
  };

  return (
    <div>
      <button ref={startStopButtonRef} onClick={handleStartStop}>
        {isRunning ? 'Stop' : 'Start'}
      </button>
      <button onClick={handleReset}>Reset</button>
    </div>
  );
};

export default TimerControl;