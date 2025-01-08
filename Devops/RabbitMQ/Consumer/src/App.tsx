import React, { useEffect, useState } from "react";
import io from "socket.io-client";
import "./App.css";

const socket = io("http://localhost:5672");

const App: React.FC = () => {
  const [messages, setMessages] = useState<string[]>([]);

  useEffect(() => {
    socket.on("newMessage", (message: string) => {
      setMessages((prev) => [...prev, message]);
    });
  }, []);

  return (
    <div className="container">
      <h1>Message Consumer</h1>
      <div className="message-list">
        {messages.map((msg, index) => (
          <div key={index} className="message">
            {msg}
          </div>
        ))}
      </div>
    </div>
  );
};

export default App;
