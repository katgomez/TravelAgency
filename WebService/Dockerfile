FROM node:14-alpine as builder
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build
FROM nginx:alpine

# Copy SSL/TLS certificates and Nginx configuration
COPY --from=builder /app/nginx/ssl/ /etc/nginx/ssl/
COPY --from=builder /app/nginx/nginx.conf /etc/nginx/nginx.conf

# Copy the built Angular app from the previous stage into the Nginx directory
COPY --from=builder /app/dist/WebServices /usr/share/nginx/html

# Expose HTTPS port
EXPOSE 443

# Start Nginx server
CMD ["nginx", "-g", "daemon off;"]