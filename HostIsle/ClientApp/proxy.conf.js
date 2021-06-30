const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/_configuration",
      "/.well-known",
      "/Identity",
      "/connect",
      "/ApplyDatabaseMigrations",
   ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
