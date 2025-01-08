import express from "express";
import cors from "cors";
import { sendMessage } from "./producer";
import { startConsumer } from "./consumer";
import dotenv from "dotenv";

dotenv.config();

const app = express();
app.use(cors());
app.use(express.json());

const PORT = process.env.PORT || 5000;

app.post("/send", async (req, res) => {
  const { message } = req.body;
  try {
    await sendMessage(message);
    res.status(200).json({ status: "Message sent successfully" });
  } catch (error) {
    res.status(500).json({ error: "Failed to send message" });
  }
});

startConsumer();

app.listen(PORT, () => console.log(`Server running on port ${PORT}`));