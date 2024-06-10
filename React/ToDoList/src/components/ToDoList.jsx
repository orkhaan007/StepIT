import React, { Component } from 'react';

class ToDoList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      tasks: [],
      newTaskName: ''
    };
  }

  handleTaskNameChange = (event) => {
    this.setState({ newTaskName: event.target.value });
  }

  addTask = () => {
    const { tasks, newTaskName } = this.state;
    if (newTaskName.trim() !== '') {
      this.setState({
        tasks: [...tasks, { id: tasks.length + 1, name: newTaskName }],
        newTaskName: ''
      });
    }
  }

  removeTask = (taskId) => {
    this.setState({
      tasks: this.state.tasks.filter(task => task.id !== taskId)
    });
  }

  render() {
    return (
      <div>
        <input type="text" value={this.state.newTaskName} onChange={this.handleTaskNameChange} />
        <button onClick={this.addTask}>Add Task</button>
        <ul>
          {this.state.tasks.map(task => (
            <li key={task.id}>
              {task.name}
              <button onClick={() => this.removeTask(task.id)}>Remove</button>
            </li>
          ))}
        </ul>
      </div>
    );
  }
}

export default ToDoList;