# Build Stage
FROM node:22-alpine

RUN apk add --no-cache bash

WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application files to the working directory
COPY . .

CMD ["npm", "run", "dev", "--", "--host"]
