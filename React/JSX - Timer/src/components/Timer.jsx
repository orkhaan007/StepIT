import React, { Component } from 'react';

class Timer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      timerValue: '',
      countdown: null,
      message: ''
    };
  }

  componentDidUpdate(prevProps, prevState) {
    console.log('Timer: componentDidUpdate called');
  }

  componentWillUnmount() {
    if (this.state.countdown !== null) {
      clearInterval(this.state.countdown);
    }
    console.log('Timer: componentWillUnmount called');
  }

  handleInputChange = (event) => {
    this.setState({ timerValue: event.target.value });
  };

  startTimer = () => {
    if (this.state.countdown !== null) {
      clearInterval(this.state.countdown);
    }
    this.setState({
      countdown: setInterval(this.updateTimer, 1000),
      message: ''
    });
  };

  updateTimer = () => {
    this.setState((prevState) => {
      const newTime = prevState.timerValue - 1;
      if (newTime <= 0) {
        clearInterval(this.state.countdown);
        return { timerValue: '', message: 'Time is up!', countdown: null };
      }
      return { timerValue: newTime };
    });
  };

  resetTimer = () => {
    if (this.state.countdown !== null) {
      clearInterval(this.state.countdown);
    }
    this.setState({ timerValue: '', message: '', countdown: null });
  };

  render() {
    return (
      <div className="timer">
        <input
          type="number"
          value={this.state.timerValue}
          onChange={this.handleInputChange}
          placeholder="Enter seconds"
          className="timer-input"
        />
        <div className="timer-buttons">
          <button onClick={this.startTimer} className="btn btn-start">Start Timer</button>
          <button onClick={this.resetTimer} className="btn btn-reset">Reset Timer</button>
        </div>
        {this.state.timerValue && (
          <h2>Time Remaining: {this.state.timerValue} seconds</h2>
        )}
        {this.state.message && (
          <h2>{this.state.message}</h2>
        )}
      </div>
    );
  }
}

export default Timer;