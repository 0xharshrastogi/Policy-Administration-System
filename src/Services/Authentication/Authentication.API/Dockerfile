# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS BUILD
WORKDIR /Source
COPY . .

RUN dotnet restore ./Authentication.API.csproj --disable-parallel
RUN dotnet publish ./Authentication.API.csproj -c release -o /app --no-restore

# Stage 
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT [ "dotnet" , "Authentication.API.dll" ]

# docker image build --rm -t  theharshrastogi/pas-auth:latest .