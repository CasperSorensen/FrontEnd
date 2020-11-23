FROM mcr.microsoft.com/dotnet/core/sdk:3.1
COPY . /front_end_app
WORKDIR /front_end_app
RUN dotnet restore
WORKDIR /front_end_app/src/FrontEndApp
EXPOSE 5001/tcp
ENTRYPOINT [ "dotnet", "run", "--no-restore", "--urls", "http://0.0.0.0:5001"]

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY /src/FrontEndApp/*.csproj ./
# RUN dotnet restore

# # Copy everything else and build
# COPY /src/FrontEndApp ./
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "FrontEndApp.dll"]
