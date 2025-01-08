import amqp from "amqplib";
import dotenv from "dotenv";

dotenv.config();

const RABBITMQ_URL = process.env.RABBITMQ_URL!;
const QUEUE_NAME = process.env.QUEUE_NAME!;

export const startConsumer = async () => {
  const connection = await amqp.connect(RABBITMQ_URL);
  const channel = await connection.createChannel();
  await channel.assertQueue(QUEUE_NAME, { durable: true });
  console.log("Waiting for messages...");

  channel.consume(QUEUE_NAME, (msg) => {
    if (msg) {
      console.log(`Received: ${msg.content.toString()}`);
      channel.ack(msg);
    }
  });
};
