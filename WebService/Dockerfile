FROM nginx

EXPOSE 2000

COPY ./dist/web-service /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf

RUN chown root /usr/share/nginx/html/*
RUN chmod 755 /usr/share/nginx/html/*

CMD ["nginx", "-g", "daemon off;"]