FROM alpine:3.12
RUN apk update && apk upgrade
# Install SQLite
RUN apk add --no-cache sqlite
# Copy your SQLite database file to the container (if needed)
COPY AgencyTravel.sql .
# Run SQLite and execute the SQL script
RUN sqlite3 AgencyTravel.db < AgencyTravel.sql
# Expose port for SQLite access (if needed)
EXPOSE 5432
# Start SQLite shell when the container starts
CMD ["sqlite3", "AgencyTravel.db"]