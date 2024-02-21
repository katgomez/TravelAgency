FROM node:20 as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build
# Stage 2
FROM nginx:alpine
COPY --from=node /app/dist/web-service /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
