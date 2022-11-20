# DocumentsApiConsumer

### Prerequisites
* [Visual Studio](https://visualstudio.microsoft.com/vs/) 2022 or later.
* [Docker](https://www.docker.com/)
* RabbitMQ - after docker gets downloaded the RabbitMQ image should be pulled through CMD: <pre>docker pull rabbitmq</pre>
In order to access the admin panel in docker, the following command should be run in CMD: <pre>docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management</pre>
Versions should be checked while pulling latest RabbitMQ image.

### Setup
- items in the prerequsites section should be installed
- project should be downloaded into your local machine

### Resources
* [How to Use RabbitMQ in ASP NET Core](https://www.freecodespot.com/blog/use-rabbitmq-in-asp-net-core/)
* [ASPNET_Core-RabitMQ-Demo](https://github.com/coderbugzz/ASPNET_Core-RabitMQ-Demo)
