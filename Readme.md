## Attribution
```DockerSqlDatabaseUtilities``` class is taken from George Dangl : https://blog.dangl.me/archive/running-sql-server-integration-tests-in-net-core-projects-via-docker/


## Purpose
The purpose of this repo is to demonstrate running integration tests against a transient Microsoft SQL Server instance hosted inside a docker container. The container is started before all tests are run and cleaned up once all tests are finished. This repo also demonstrates using "Respawn" (https://github.com/jbogard/Respawn) to restore database state between tests without having to destroy and re-seed during setup/teardown.

## System Requirements
- Docker 
- Dotnet 5.0.12 SDK


## Running Tests
- From CLI, execute ```dotnet test```
- From Visual Studio, Test -> Run All Tests
