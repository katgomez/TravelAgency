export const environment = {
  production: true,
  countriesEndPoint: process.env["APP_URL"]+"/api/countries",
  flightsSearchEndPoint: process.env["APP_URL"]+"/api/flightsSearch",
  flightsReservationEndPoint: process.env["APP_URL"]+"/api/flightReservations",
  airportsEndPoint: process.env["APP_URL"]+"/api/airports",
  faresEndPoint: process.env["APP_URL"]+"/api/fares",
  userEndPoint: process.env["APP_URL"]+"/api/users",
  authEndPoint: process.env["APP_URL"]+"/api/auth"
};
