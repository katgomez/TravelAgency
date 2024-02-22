FROM nginx:alpine
COPY ./dist/web-service /usr/share/nginx/html
ENV APP_URL="http://travelapi:8080"
COPY nginx.conf /etc/nginx/nginx.conf
RUN chown root /usr/share/nginx/html/*
RUN chmod 755 /usr/share/nginx/html/*
CMD ["/usr/sbin/nginx", "-g", "daemon off;"]
