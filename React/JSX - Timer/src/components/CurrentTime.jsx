import React, { Component } from 'react';

class CurrentTime extends Component {
  constructor(props) {
    super(props);
    this.state = {
      currentTime: new Date(),
    };
  }

  componentDidMount() {
    this.intervalID = setInterval(() => this.tick(), 1000);
    console.log('CurrentTime: componentDidMount called');
  }

  componentDidUpdate() {
    console.log('CurrentTime: componentDidUpdate called');
  }

  componentWillUnmount() {
    clearInterval(this.intervalID);
    console.log('CurrentTime: componentWillUnmount called');
  }

  tick() {
    this.setState({ currentTime: new Date() });
  }

  render() {
    return (
      <div className="current-time">
        <h1>{this.state.currentTime.toLocaleTimeString()}</h1>
      </div>
    );
  }
}

export default CurrentTime;