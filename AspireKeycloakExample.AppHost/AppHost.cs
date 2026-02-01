using Aspire.Hosting;
using Projects;


var builder = DistributedApplication.CreateBuilder(args);

var keycloak_username = builder.AddParameter("keycloak-username", secret: false);
var keycloak_password = builder.AddParameter("keycloak-password", secret: true);
var keycloak_client_postman_secret = builder.AddParameter("keycloak-postman-secret", secret: true);
var keycloak_client_weatherweb_secret = builder.AddParameter("keycloak-weatherweb-secret", secret: true);
var keycloak = builder.AddKeycloak("keycloak", 8080, keycloak_username, keycloak_password)
  .WithLifetime(ContainerLifetime.Persistent)
  .WithRealmImport("./Keycloak-Realms")
  .WithEnvironment("KEYCLOAK_CLIENT_POSTMAN_SECRET", keycloak_client_postman_secret)
  .WithEnvironment("KEYCLOAK_CLIENT_WEATHERWEB_SECRET", keycloak_client_weatherweb_secret);

var api = builder.AddProject<AspireKeycloakExample_Api>("api")
  .WithReference(keycloak)
  .WaitFor(keycloak);

builder.AddProject<Projects.AspireKeycloakExample_Web>("web")
  .WithReference(keycloak)
  .WithReference(api)
  .WaitFor(keycloak)
  .WaitFor(api);

builder.Build().Run();
