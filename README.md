# CPSC481
Human-computer interaction design project


To run application using dotnet:

1. navigate to the folder CPSC481, or wherever you have saved the project files
2. Run the shell command:
    dotnet watch
3. Open a web browser and enter the URL an port supplied by dotnet:
    https://localhost:5001/


To run application using the docker file:
1. navigate to the folder CPSC481, or wherever you have saved the project files
2. Build the docker
    docker build --no-cache -t burger-kiosk .
3. Run the docker:
    docker run -it --rm -p 80:80 burger-kiosk
3. Open a web browser and enter the URL an port supplied by dotnet:
    http://localhost/
4. Alternative you can access the server from another computer by connecting to the IP address in a web browser
    192.168.x.x
    or 10.x.x.x