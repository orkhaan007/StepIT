import amqp from "amqplib";
import dotenv from "dotenv";

dotenv.config();

const RABBITMQ_URL = process.env.RABBITMQ_URL!;
const QUEUE_NAME = process.env.QUEUE_NAME!;

export const sendMessage = async (message: string) => {
  const connection = await amqp.connect(RABBITMQ_URL);
  const channel = await connection.createChannel();
  await channel.assertQueue(QUEUE_NAME, { durable: true });
  channel.sendToQueue(QUEUE_NAME, Buffer.from(message));
  console.log(`Sent: ${message}`);
  await channel.close();
  await connection.close();
};
