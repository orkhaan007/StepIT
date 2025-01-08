import React, { useState } from "react";
import axios from "axios";
import "./App.css";

const App: React.FC = () => {
  const [message, setMessage] = useState("");
  const [status, setStatus] = useState("");

  const sendMessage = async () => {
    try {
      await axios.post("http://localhost:5672/send", { message });
      setStatus("Message sent successfully");
      setMessage("");
    } catch (error) {
      setStatus("Failed to send message");
    }
  };

  return (
    <div className="container">
      <h1>Message Producer</h1>
      <input
        type="text"
        placeholder="Enter your message"
        value={message}
        onChange={(e) => setMessage(e.target.value)}
        className="input"
      />
      <button onClick={sendMessage} className="button">
        Send
      </button>
      <p className="status">{status}</p>
    </div>
  );
};

export default App;
