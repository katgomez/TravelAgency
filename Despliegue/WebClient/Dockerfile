FROM nginx:latest

COPY ./dist/web-service/browser/ /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf

#RUN chown root /usr/share/nginx/html/*
RUN chmod 755 /usr/share/nginx/html/*

EXPOSE 2000

ENTRYPOINT ["/usr/sbin/nginx", "-g", "daemon off;"]